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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace KarliCards.Gui
{
  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class StartGame : KarliCards.Gui.Common.LayoutAwarePage
  {
    private GameOptions _options = new GameOptions();
    public StartGame()
    {
      this.InitializeComponent();
      DataContext = _options;
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
    }

    /// <summary>
    /// Preserves state associated with this page in case the application is suspended or the
    /// page is discarded from the navigation cache.  Values must conform to the serialization
    /// requirements of <see cref="SuspensionManager.SessionState"/>.
    /// </summary>
    /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
    }

    private void StartGame_Click(object sender, RoutedEventArgs e)
    {
      var players = new PlayerNames();
      foreach (var player in playersListBox.SelectedItems)
        players.Add(player as string);
      _options.Save();
      Frame.Navigate(typeof(GamePage), players.ToString());
    }

    private void AddPlayer_Clicked(object sender, RoutedEventArgs e)
    {
      if (playerNameTextBox.Text.Length > 0)
      {
        _options.AddPlayer(playerNameTextBox.Text);
        playerNameTextBox.Text = string.Empty;
      }
    }

    private void SelectedPlayersChanged(object sender, SelectionChangedEventArgs e)
    {
      if (playersListBox.SelectedItems.Count == 1 && _options.PlayAgainstComputer)
        startGameButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
      else if (playersListBox.SelectedItems.Count == _options.NumberOfPlayers)
        startGameButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
      else
        startGameButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
    }
  }
}
