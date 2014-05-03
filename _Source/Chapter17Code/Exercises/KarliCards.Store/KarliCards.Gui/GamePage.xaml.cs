using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CardLib;
using KarliCards_Gui.ViewModel;
using Windows.UI.ApplicationSettings;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace KarliCards.Gui
{
  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class GamePage : KarliCards.Gui.Common.LayoutAwarePage
  {
    public GamePage()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Populates the page with content passed during navigation.  Any saved state is also
    /// provided when recreating a page from a prior session.
    /// </summary>
    /// <param name="navigationParameter">The parameter value passed to
    /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    /// </param>
    /// <param name="pageState">A dictionary of state preserved by this page during an earlier
    /// session.  This will be null the first time a page is visited.</param>
    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
      if (pageState != null && pageState["CurrentGame"] != null)
      {
        var context = pageState["CurrentGame"] as GameViewModel;
        if (context != null)
        {
          this.DataContext = context;
          context.ContinueGame();
        }
      }
      else if (navigationParameter != null)
      {
        var players = navigationParameter as string;
        var newGame = new GameViewModel();
        newGame.StartNewGame(PlayerNames.FromString(players));
        DataContext = newGame;
      }
      SettingsPane.GetForCurrentView().CommandsRequested += GamePage_CommandsRequested;
    }

    /// <summary>
    /// Preserves state associated with this page in case the application is suspended or the
    /// page is discarded from the navigation cache.  Values must conform to the serialization
    /// requirements of <see cref="SuspensionManager.SessionState"/>.
    /// </summary>
    /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
      pageState["CurrentGame"] = DataContext as GameViewModel;
      SettingsPane.GetForCurrentView().CommandsRequested -= GamePage_CommandsRequested;
    }

    private void GotoSettings(object sender, RoutedEventArgs e)
    {
      Windows.UI.ApplicationSettings.SettingsPane.Show();
    }

    protected override void OnPointerPressed(PointerRoutedEventArgs e)
    {
      var position = e.GetCurrentPoint(GameSettingsPane).Position.X < 0;
      if (GameSettingsPane.Margin.Right == 0 && position)
      {
        GameSettingsPane.Margin = new Thickness(0, 0, -346, 0);
      }
      base.OnPointerPressed(e);
    }

    void GamePage_CommandsRequested(SettingsPane sender,
SettingsPaneCommandsRequestedEventArgs args)
    {
      SettingsCommand cmd = new SettingsCommand("KarliCardsSettings",
"Game Options", (x) =>
{
  GameSettingsPane.DataContext = new GameOptions();
  GameSettingsPane.Height = Window.Current.Bounds.Height;
  GameSettingsPane.Margin = new Thickness(0, 0, 0, 0);
});
      args.Request.ApplicationCommands.Add(cmd);
    }

  }
}
