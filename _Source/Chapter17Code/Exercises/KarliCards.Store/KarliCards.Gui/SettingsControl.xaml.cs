using KarliCards_Gui.ViewModel;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KarliCards.Gui
{
  public sealed partial class SettingsControl : UserControl
  {
    public SettingsControl()
    {
      this.InitializeComponent();
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
      this.Margin = new Thickness(0, 0, -346, 0);
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
      var context = DataContext as GameOptions;
      context.Save();
      this.Margin = new Thickness(0, 0, -346, 0);
    }
  }
}
