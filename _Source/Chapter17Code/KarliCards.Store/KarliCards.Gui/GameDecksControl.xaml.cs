using System.Threading.Tasks;
using CardLib;
using KarliCards_Gui.ViewModel;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;
using System.Linq;

namespace KarliCards_Gui
{
  public partial class GameDecksControl : UserControl
  {
    public GameDecksControl()
    {
      InitializeComponent();
    }

    public bool GameStarted
    {
      get { return (bool)GetValue(GameStartedProperty); }
      set { SetValue(GameStartedProperty, value); }
    }

    // Using a DependencyProperty as the backing store for GameStarted.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty GameStartedProperty =
        DependencyProperty.Register("GameStarted", typeof(bool), typeof(GameDecksControl), new PropertyMetadata(false, new PropertyChangedCallback(OnGameStarted)));

    public Player CurrentPlayer
    {
      get { return (Player)GetValue(CurrentPlayerProperty); }
      set { SetValue(CurrentPlayerProperty, value); }
    }

    // Using a DependencyProperty as the backing store for CurrentPlayer.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CurrentPlayerProperty =
        DependencyProperty.Register("CurrentPlayer", typeof(Player), typeof(GameDecksControl), new PropertyMetadata(null, new PropertyChangedCallback(OnPlayerChanged)));

    public Deck Deck
    {
      get { return (Deck)GetValue(DeckProperty); }
      set { SetValue(DeckProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Deck.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DeckProperty =
        DependencyProperty.Register("Deck", typeof(Deck), typeof(GameDecksControl), new PropertyMetadata(null, new PropertyChangedCallback(OnDeckChanged)));

    public Card AvailableCard
    {
      get { return (Card)GetValue(AvailableCardProperty); }
      set { SetValue(AvailableCardProperty, value); }
    }

    // Using a DependencyProperty as the backing store for AvailableCard.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty AvailableCardProperty =
        DependencyProperty.Register("AvailableCard", typeof(Card), typeof(GameDecksControl), new PropertyMetadata(null, new PropertyChangedCallback(OnAvailableCardChanged)));

    private static void OnGameStarted(DependencyObject source,
DependencyPropertyChangedEventArgs e)
    {
      var control = source as GameDecksControl;
      control.DrawDecks();
    }

    private static void OnPlayerChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
      var control = source as GameDecksControl;
      if (control.CurrentPlayer == null)
        return;

      control.CurrentPlayer.OnCardDiscarded += control.CurrentPlayer_OnCardDiscarded;
      control.DrawDecks();
    }

    private void CurrentPlayer_OnCardDiscarded(object sender, CardEventArgs e)
    {
      AvailableCard = e.Card;
      DrawDecks();
    }

    private static void OnDeckChanged(DependencyObject source,
DependencyPropertyChangedEventArgs e)
    {
      var control = source as GameDecksControl;
      control.DrawDecks();
    }

    private static void OnAvailableCardChanged(DependencyObject source,
DependencyPropertyChangedEventArgs e)
    {
      var control = source as GameDecksControl;
      control.DrawDecks();
    }

    private void DrawDecks()
    {
      controlCanvas.Children.Clear();

      if (CurrentPlayer == null || Deck == null | !GameStarted)
        return;


      List<CardControl> stackedCards = new List<CardControl>();
      for (int i = 0; i < Deck.CardsInDeck; i++)
        stackedCards.Add(new CardControl(Deck.GetCard(i)) { Margin = new Thickness(150 + (i * 1.25), 25 - (i * 1.25), 0, 0), IsFaceUp = false });

      if (stackedCards.Count > 0)
        stackedCards.Last().Tapped += GameDecksControl_Tapped;
      if (AvailableCard != null)
      {
        var availableCard = new CardControl(AvailableCard) { Margin = new Thickness(0, 25, 0, 0) };
        availableCard.Tapped += availableCard_Tapped;
        controlCanvas.Children.Add(availableCard);
      }
      foreach (var card in stackedCards)
        controlCanvas.Children.Add(card);
    }

    void availableCard_Tapped(object sender, TappedRoutedEventArgs e)
    {
      if (CurrentPlayer.State != PlayerState.Active)
        return;

      var control = sender as CardControl;
      CurrentPlayer.AddCard(control.Card);
      AvailableCard = null;
      DrawDecks();
    }

    void GameDecksControl_Tapped(object sender, TappedRoutedEventArgs e)
    {
      if (CurrentPlayer.State != PlayerState.Active)
        return;

      CurrentPlayer.DrawCard(Deck);
      DrawDecks();
    }
  }
}
