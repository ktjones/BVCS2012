using System.Threading.Tasks;
using CardLib;
using KarliCards_Gui.ViewModel;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace KarliCards_Gui
{
  public partial class CardsInHandControl : UserControl
  {
    public CardsInHandControl()
    {
      InitializeComponent();
    }

    public Player Owner
    {
      get { return (Player)GetValue(OwnerProperty); }
      set { SetValue(OwnerProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Owner.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty OwnerProperty =
        DependencyProperty.Register("Owner", typeof(Player), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));

    public GameViewModel Game
    {
      get { return (GameViewModel)GetValue(GameProperty); }
      set { SetValue(GameProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Game.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty GameProperty =
        DependencyProperty.Register("Game", typeof(GameViewModel), typeof(CardsInHandControl), new PropertyMetadata(null));

    public PlayerState PlayerState
    {
      get { return (PlayerState)GetValue(PlayerStateProperty); }
      set { SetValue(PlayerStateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for PlayerState.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PlayerStateProperty =
        DependencyProperty.Register("PlayerState", typeof(PlayerState), typeof(CardsInHandControl), new PropertyMetadata(PlayerState.Inactive, new PropertyChangedCallback(OnPlayerStateChanged)));

    public Orientation PlayerOrientation
    {
      get { return (Orientation)GetValue(PlayerOrientationProperty); }
      set { SetValue(PlayerOrientationProperty, value); }
    }

    // Using a DependencyProperty as the backing store for PlayerOrientation.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PlayerOrientationProperty =
        DependencyProperty.Register("PlayerOrientation", typeof(Orientation), typeof(CardsInHandControl), new PropertyMetadata(Orientation.Horizontal, new PropertyChangedCallback(OnPlayerOrientationChanged)));

    private static void OnOwnerChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
      var control = source as CardsInHandControl;
      control.RedrawCards();
    }

    private static async void OnPlayerStateChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
      var control = source as CardsInHandControl;
      var computerPlayer = control.Owner as ComputerPlayer;

      if (computerPlayer != null && computerPlayer.State == PlayerState.MustDiscard)
      {
        await Task.Delay(1250);
        computerPlayer.PerformDiscard(control.Game.GameDeck);
      }
      else if (computerPlayer != null && computerPlayer.State == PlayerState.Active)
      {
        await Task.Delay(1250);
        computerPlayer.PerformDraw(control.Game.GameDeck, control.Game.CurrentAvailableCard);
      }
      control.RedrawCards();
    }

    private static void OnPlayerOrientationChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
    {
      var control = source as CardsInHandControl;
      control.RedrawCards();
    }

    public ComputerPlayer ComputerPlayer
    {
      get { return (ComputerPlayer)GetValue(ComputerPlayerProperty); }
      set { SetValue(ComputerPlayerProperty, value); }
    }

    public static readonly DependencyProperty ComputerPlayerProperty = DependencyProperty.Register("ComputerPlayer", typeof(ComputerPlayer),
      typeof(CardsInHandControl),
      new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));

    private void RedrawCards()
    {
      CardSurface.Children.Clear();
      if (Owner == null)
      {
        PlayerNameLabel.Text = string.Empty;
        return;
      }
      DrawPlayerName();
      DrawCards();
    }

    private void DrawCards()
    {
      bool isFaceup = (Owner.State != PlayerState.Inactive);

      if (Owner is ComputerPlayer)
        isFaceup = (Owner.State == CardLib.PlayerState.Loser || Owner.State == CardLib.PlayerState.Winner || Game == null ? true : Game.ComputerPlaysWithOpenHand);

      var cards = Owner.GetCards();
      if (cards == null || cards.Count == 0)
        return;

      for (var i = 0; i < cards.Count; i++)
      {
        var cardControl = new CardControl(cards[i]);
        if (PlayerOrientation == Orientation.Horizontal)
          cardControl.Margin = new Thickness(i * 35, 35, 0, 0);
        else
          cardControl.Margin = new Thickness(5, 35 + i * 30, 0, 0);
        cardControl.Tapped += cardControl_Tapped;
        cardControl.IsFaceUp = isFaceup;
        CardSurface.Children.Add(cardControl);
      }
    }

    private void DrawPlayerName()
    {
      if (Owner.State == PlayerState.Winner || Owner.State == PlayerState.Loser)
        PlayerNameLabel.Text = Owner.PlayerName + (Owner.State == PlayerState.Winner ? " is the WINNER" : " has LOST");
      else
        PlayerNameLabel.Text = Owner.PlayerName;
      var isActivePlayer = (Owner.State == CardLib.PlayerState.Active || Owner.State == CardLib.PlayerState.MustDiscard);
      PlayerNameLabel.FontSize = isActivePlayer ? 18 : 14;
      PlayerNameLabel.Foreground = isActivePlayer ? new SolidColorBrush(Colors.Gold) : new SolidColorBrush(Colors.White);
    }

    void cardControl_Tapped(object sender, TappedRoutedEventArgs e)
    {
      var selectedCard = sender as CardControl;
      if (Owner == null)
        return;
      if (Owner.State == PlayerState.MustDiscard)
      {
        Owner.DiscardCard(selectedCard.Card);
      }
      RedrawCards();
    }
  }
}
