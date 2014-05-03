using System;
using CardLib;
using Windows.UI.Xaml.Data;

namespace KarliCards.Gui
{
  public class ComputerSkillValueConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter,
                          string language)
    {
      return (double)(int)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
                              string language)
    {
      return (ComputerSkillLevel)System.Convert.ToInt32(value);
    }
  }
}
