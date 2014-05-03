using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CardLib
{
  public class PlayerNames : ObservableCollection<string>
  {
    public PlayerNames()
      : base()
    {
    }

    public PlayerNames(List<string> names)
    {
      foreach (var name in names)
        Add(name);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var player in Items)
      {
        if (sb.Length == 0)
          sb.Append(player);
        else
          sb.AppendFormat("¤{0}", player);
      }
      return sb.ToString();
    }

    public static PlayerNames FromString(string players)
    {
      var collection = new PlayerNames();
      var playerSplit = players.Split("¤".ToCharArray());
      foreach (var player in playerSplit)
        collection.Add(player);
      return collection;
    }
  }
}
