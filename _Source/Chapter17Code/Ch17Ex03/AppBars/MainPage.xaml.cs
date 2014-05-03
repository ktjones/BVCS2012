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
using Windows.UI.ApplicationSettings;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AppBars
{
  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class MainPage : AppBars.Common.LayoutAwarePage
  {
    public MainPage()
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
      SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
    }

    /// <summary>
    /// Preserves state associated with this page in case the application is suspended or the
    /// page is discarded from the navigation cache.  Values must conform to the serialization
    /// requirements of <see cref="SuspensionManager.SessionState"/>.
    /// </summary>
    /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
      SettingsPane.GetForCurrentView().CommandsRequested -= MainPage_CommandsRequested;
    }

    private void StartGame_Click(object sender, RoutedEventArgs e)
    {

    }

    private void GotoSettings(object sender, RoutedEventArgs e)
    {
      Windows.UI.ApplicationSettings.SettingsPane.Show();
    }

    private void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
      SettingsCommand cmd = new SettingsCommand("KarliCardsSettings", "Game Options", (x) =>
      {
        SettingsPanel.Height = Window.Current.Bounds.Height;
        SettingsPanel.Margin = new Thickness(0, 0, 0, 0);
      });
      args.Request.ApplicationCommands.Add(cmd);
    }

    protected override void OnPointerPressed(PointerRoutedEventArgs e)
    {
      var position = e.GetCurrentPoint(SettingsPanel).Position.X < 0;
      if (SettingsPanel.Margin.Right == 0 && position)
        SettingsPanel.Margin = new Thickness(0, 0, -346, 0);
      base.OnPointerPressed(e);
    }

  }
}
