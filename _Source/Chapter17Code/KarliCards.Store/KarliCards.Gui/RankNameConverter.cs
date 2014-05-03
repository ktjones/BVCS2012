using System;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace KarliCards_Gui
{
  public class RankNameConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      int source = (int)value;
      if (source == 1 || source > 10)
      {
        switch (source)
        {
          case 1:
            return "Ace";
          case 11:
            return "Jack";
          case 12:
            return "Queen";
          case 13:
            return "King";
          default:
            return DependencyProperty.UnsetValue;
        }
      }
      else
        return source.ToString();
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      return DependencyProperty.UnsetValue;
    }
  }
}
