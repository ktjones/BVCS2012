using CardLib;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace KarliCards_Gui
{
  public partial class CardControl : UserControl
  {
    public static DependencyProperty SuitProperty = DependencyProperty.Register(
       "Suit",
       typeof(CardLib.Suit),
       typeof(CardControl),
       new PropertyMetadata(CardLib.Suit.Club, new PropertyChangedCallback(OnSuitChanged)));

    public static DependencyProperty RankProperty = DependencyProperty.Register(
       "Rank",
       typeof(CardLib.Rank),
       typeof(CardControl),
       new PropertyMetadata(CardLib.Rank.Ace));

    public static DependencyProperty IsFaceUpProperty = DependencyProperty.Register(
   "IsFaceUp",
   typeof(bool),
   typeof(CardControl),
   new PropertyMetadata(true, new PropertyChangedCallback(OnIsFaceUpChanged)));

    private CardLib.Card _card;
    public CardLib.Card Card
    {
      get { return _card; }
      private set { _card = value; Suit = _card.suit; Rank = _card.rank; }
    }

    public CardControl()
    {
      InitializeComponent();
    }

    public CardControl(Card card)
    {
      InitializeComponent();

      Card = card;
      VisualStateManager.GoToState(this, Suit.ToString(), false);
    }

    public bool IsFaceUp
    {
      get { return (bool)GetValue(IsFaceUpProperty); }
      set { SetValue(IsFaceUpProperty, value); }
    }

    public CardLib.Suit Suit
    {
      get { return (CardLib.Suit)GetValue(SuitProperty); }
      set { SetValue(SuitProperty, value); }
    }

    public CardLib.Rank Rank
    {
      get { return (CardLib.Rank)GetValue(RankProperty); }
      set { SetValue(RankProperty, value); }
    }

    public static void OnSuitChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
    {
      var control = source as CardControl;
      VisualStateManager.GoToState(control, control.Suit.ToString(), false);
    }

    private static void OnIsFaceUpChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
    {
      var control = source as CardControl;
      control.RankLabel.Visibility = control.SuitLabel.Visibility = control.RankLabelInverted.Visibility =
        control.TopRightImage.Visibility = control.BottomLeftImage.Visibility = control.IsFaceUp ? Visibility.Visible : Visibility.Collapsed;
    }
  }
}
