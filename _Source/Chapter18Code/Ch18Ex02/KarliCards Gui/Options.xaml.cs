using CardLib;
using KarliCards_Gui.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace KarliCards_Gui
{
  /// <summary>
  /// Interaction logic for Options.xaml
  /// </summary>
  public partial class Options : Window
  {
    private GameOptions _gameOptions;

    public Options()
    {
      _gameOptions = GameOptions.Create();
      DataContext = _gameOptions;
      InitializeComponent();
    }

    private void dumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
    }

    private void goodAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Good;
    }

    private void cheatingAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
    }

    private void timeAllowedTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      timeAllowedTextBox.SelectAll();
    }

    private void timeAllowedTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var control = sender as TextBox;
      if (control == null)
        return;

      Keyboard.Focus(control);
      e.Handled = true;
    }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
      _gameOptions.Save();
      this.Close();
    }

    private void cancelButton_Click(object sender, RoutedEventArgs e)
    {
      _gameOptions = null;
      this.Close();
    }
  }
}
