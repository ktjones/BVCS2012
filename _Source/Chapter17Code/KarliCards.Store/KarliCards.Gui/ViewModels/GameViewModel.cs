using CardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarliCards_Gui.ViewModel
{
  [DataContract]
  [KnownType(typeof(ComputerPlayer))]
  [KnownType(typeof(ComputerSkillLevel))]
  [KnownType(typeof(ComputerPlayer))]
  [KnownType(typeof(PlayerState))]
  public class GameViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    [DataMember]
    private Player _currentPlayer;
    public Player CurrentPlayer
    {
      get { return _currentPlayer; }
      set
      {
        _currentPlayer = value;
        OnPropertyChanged("CurrentPlayer");
      }
    }

    [DataMember]
    private List<Player> _players;
    public List<Player> Players
    {
      get { return _players; }
      set
      {
        _players = value;
        OnPropertyChanged("Players");
      }
    }

    [DataMember]
    private Card _availableCard;
    public Card CurrentAvailableCard
    {
      get { return _availableCard; }
      set
      {
        _availableCard = value;
        OnPropertyChanged("CurrentAvailableCard");
      }
    }

    [DataMember]
    private Deck _deck;
    public Deck GameDeck
    {
      get { return _deck; }
      set
      {
        _deck = value;
        OnPropertyChanged("GameDeck");
      }
    }

    [DataMember]
    private bool _gameStarted;
    public bool GameStarted
    {
      get { return _gameStarted; }
      set
      {
        _gameStarted = value;
        OnPropertyChanged("GameStarted");
      }
    }

    private int _currentPlayerIndex;
    [DataMember]
    public bool ComputerPlaysWithOpenHand { get; set; }
    [DataMember]
    public int NumberOfPlayers { get; set; }
    [DataMember]
    public ComputerSkillLevel ComputerSkill { get; set; }

    private GameOptions _gameOptions;

    public void StartNewGame(PlayerNames playernNames)
    {
      if (playernNames == null || playernNames.Count == 0)
        return;
      
      _gameOptions = new GameOptions();
      NumberOfPlayers = _gameOptions.NumberOfPlayers;
      ComputerPlaysWithOpenHand = _gameOptions.ComputerPlaysWithOpenHand;
      ComputerSkill = _gameOptions.ComputerSkill;

      CreateGameDeck();
      CreatePlayers(playernNames);
      InitializeGame();
      GameStarted = true;
    }

    public void ContinueGame()
    {
      foreach (var player in Players)
      {
        player.OnCardDiscarded += player_OnCardDiscarded;
        player.OnPlayerHasWon += player_OnPlayerHasWon;
      }
      CurrentPlayer = Players[_currentPlayerIndex];
    }


    private void InitializeGame()
    {
      AssignCurrentPlayer(0);
      CurrentAvailableCard = GameDeck.Draw();
    }

    private void AssignCurrentPlayer(int index)
    {
      CurrentPlayer = Players[index];
      _currentPlayerIndex = index;
      if (!Players.Any(x => x.State == PlayerState.Winner))
        foreach (var player in Players)
          player.State = (player == CurrentPlayer ? PlayerState.Active : PlayerState.Inactive);
    }

    private void InitializePlayer(Player player)
    {
      player.DrawNewHand(GameDeck);
      player.OnCardDiscarded += player_OnCardDiscarded;
      player.OnPlayerHasWon += player_OnPlayerHasWon;
      Players.Add(player);
    }

    private void CreateGameDeck()
    {
      GameDeck = new CardLib.Deck();
      GameDeck.Shuffle();
    }

    private void CreatePlayers(PlayerNames players)
    {
      Players = new List<Player>();
      for (var i = 0; i < _gameOptions.NumberOfPlayers; i++)
      {
        if (i < players.Count)
          InitializePlayer(new Player { Index = i, PlayerName = players[i] });
        else
          InitializePlayer(new ComputerPlayer { Index = i, Skill = _gameOptions.ComputerSkill });
      }
    }

    void player_OnPlayerHasWon(object sender, PlayerEventArgs e)
    {
      foreach (var player in Players)
        player.State = (player == e.Player ? PlayerState.Winner : PlayerState.Loser);
    }

    void player_OnCardDiscarded(object sender, CardEventArgs e)
    {
      CurrentAvailableCard = e.Card;

      var nextIndex = CurrentPlayer.Index + 1 >= _gameOptions.NumberOfPlayers ? 0 : CurrentPlayer.Index + 1;

      if (GameDeck.CardsInDeck == 0)
      {
        var cardsInPlay = new List<Card>();
        foreach (var player in Players)
          cardsInPlay.AddRange(player.GetCards());
        cardsInPlay.Add(CurrentAvailableCard);
        GameDeck.ReshuffleDiscarded(cardsInPlay);
      }
      AssignCurrentPlayer(nextIndex);
    }
  }
}
