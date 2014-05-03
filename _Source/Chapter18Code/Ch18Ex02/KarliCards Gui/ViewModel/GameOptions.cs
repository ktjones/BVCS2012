using CardLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Xml.Serialization;

namespace KarliCards_Gui.ViewModel
{
  [Serializable]
  public class GameOptions : INotifyPropertyChanged
  {
    private bool _playAgainstComputer = true;
    private int _numberOfPlayers = 2;
    private int _minutedBeforeLoss = 10;
    private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
    private ObservableCollection<string> _playerNames = new ObservableCollection<string>();
    public List<string> SelectedPlayers { get; set; }

    public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options", typeof(GameOptions), new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.O, ModifierKeys.Control) }));

    public GameOptions()
    {
      SelectedPlayers = new List<string>();
    }

    public ObservableCollection<string> PlayerNames
    {
      get
      {
        return _playerNames;
      }
      set
      {
        _playerNames = value;
        OnPropertyChanged("PlayerNames");
      }
    }

    public void AddPlayer(string playerName)
    {
      if (_playerNames.Contains(playerName))
        return;
      _playerNames.Add(playerName);
      OnPropertyChanged("PlayerNames");
    }

    public int NumberOfPlayers
    {
      get { return _numberOfPlayers; }
      set
      {
        _numberOfPlayers = value;
        OnPropertyChanged("NumberOfPlayers");
      }
    }

    public bool PlayAgainstComputer
    {
      get { return _playAgainstComputer; }
      set
      {
        _playAgainstComputer = value;
        OnPropertyChanged("PlayAgainstComputer");
      }
    }

    public int MinutesBeforeLoss
    {
      get { return _minutedBeforeLoss; }
      set
      {
        _minutedBeforeLoss = value;
        OnPropertyChanged("MinutesBeforeLoss");
      }
    }

    public ComputerSkillLevel ComputerSkill
    {
      get { return _computerSkill; }
      set
      {
        _computerSkill = value;
        OnPropertyChanged("ComputerSkill");
      }
    }

    public void Save()
    {
      string filename = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameOptions.xml");
      using (var stream = File.Open(filename, FileMode.Create))
      {
        var serializer = new XmlSerializer(typeof(GameOptions));
        serializer.Serialize(stream, this);
      }
    }

    public static GameOptions Create()
    {
      string filename = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameOptions.xml");
      if (File.Exists(filename))
      {
        using (var stream = File.OpenRead(filename))
        {
          var serializer = new XmlSerializer(typeof(GameOptions));
          return serializer.Deserialize(stream) as GameOptions;
        }
      }
      else
        return new GameOptions();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
