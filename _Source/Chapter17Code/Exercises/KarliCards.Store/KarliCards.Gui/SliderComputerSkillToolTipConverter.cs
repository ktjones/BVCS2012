using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace KarliCards.Gui
{
  public class SliderComputerSkillToolTipConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      var currentValue = (double)value;
      if (currentValue == 0)
        return "Dumb";
      if (currentValue == 1)
        return "Good";
      return "Cheats";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      string currentValue = value as string;
      if (currentValue == null || string.IsNullOrWhiteSpace(currentValue))
        return DependencyProperty.UnsetValue;
      if (currentValue.ToLower() == "dumb")
        return 0D;
      if (currentValue.ToLower() == "good")
        return 1D;
      return 2D;
    }
  }
}
