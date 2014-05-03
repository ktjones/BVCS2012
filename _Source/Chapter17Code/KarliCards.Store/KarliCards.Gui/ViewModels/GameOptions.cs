using CardLib;
using System.ComponentModel;
using Windows.Storage;

namespace KarliCards_Gui.ViewModel
{
  public class GameOptions : INotifyPropertyChanged
  {
    private bool _playAgainstComputer = true;
    private int _numberOfPlayers = 4;
    private int _minutedBeforeLoss = 10;
    private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
    private PlayerNames _playerNames = new PlayerNames();

    public GameOptions()
    {
      LoadSettings();
    }

    private bool _computerPlaysWithOpenHand;
    public bool ComputerPlaysWithOpenHand
    {
      get { return _computerPlaysWithOpenHand; }
      set
      {
        _computerPlaysWithOpenHand = value;
        OnPropertyChanged("ComputerPlaysWithOpenHand");
      }
    }

    public PlayerNames PlayerNames
    {
      get
      {
        return _playerNames;
      }
      set
      {
        _playerNames = value;
        OnPropertyChanged("PlayerNames");
      }
    }

    public void AddPlayer(string playerName)
    {
      if (_playerNames.Contains(playerName))
        return;
      _playerNames.Add(playerName);
      OnPropertyChanged("PlayerNames");
    }

    public int NumberOfPlayers
    {
      get { return _numberOfPlayers; }
      set
      {
        _numberOfPlayers = value;
        OnPropertyChanged("NumberOfPlayers");
      }
    }

    public bool PlayAgainstComputer
    {
      get { return _playAgainstComputer; }
      set
      {
        _playAgainstComputer = value;
        OnPropertyChanged("PlayAgainstComputer");
      }
    }

    public int MinutesBeforeLoss
    {
      get { return _minutedBeforeLoss; }
      set
      {
        _minutedBeforeLoss = value;
        OnPropertyChanged("MinutesBeforeLoss");
      }
    }

    public ComputerSkillLevel ComputerSkill
    {
      get { return _computerSkill; }
      set
      {
        _computerSkill = value;
        OnPropertyChanged("ComputerSkill");
      }
    }

    public void Save()
    {
      ApplicationData.Current.LocalSettings.Values["PlayAgainstComputer"] = _playAgainstComputer;
      ApplicationData.Current.LocalSettings.Values["ComputerSkillLevel"] = (int)_computerSkill;
      ApplicationData.Current.LocalSettings.Values["NumberOfPlayers"] = _numberOfPlayers;
      ApplicationData.Current.LocalSettings.Values["ComputerPlaysWithOpenHand"] = _computerPlaysWithOpenHand;
      ApplicationData.Current.LocalSettings.Values["PlayerNames"] = _playerNames.ToString();
    }

    private void LoadSettings()
    {
      if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey("PlayAgainstComputer"))
      {
        _playAgainstComputer = (bool)ApplicationData.Current.LocalSettings.Values["PlayAgainstComputer"];
        _computerSkill = (ComputerSkillLevel)ApplicationData.Current.LocalSettings.Values["ComputerSkillLevel"];
        _numberOfPlayers = (int)ApplicationData.Current.LocalSettings.Values["NumberOfPlayers"];
        _computerPlaysWithOpenHand = (bool)ApplicationData.Current.LocalSettings.Values["ComputerPlaysWithOpenHand"];
        _playerNames = CardLib.PlayerNames.FromString(ApplicationData.Current.LocalSettings.Values["PlayerNames"] as string);
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
