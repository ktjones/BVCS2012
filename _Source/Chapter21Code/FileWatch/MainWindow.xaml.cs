using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace FileWatch
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      // File System Watcher object.
      private FileSystemWatcher watcher;

      public MainWindow()
      {
         InitializeComponent();

         watcher = new FileSystemWatcher();
         watcher.Deleted += (s, e) =>
            AddMessage("File: {0} Deleted", e.FullPath);
         watcher.Renamed += (s, e) =>
            AddMessage("File renamed from {0} to {1}",
               e.OldName, e.FullPath);
         watcher.Changed += (s, e) =>
            AddMessage("File: {0} {1}", e.FullPath,
               e.ChangeType.ToString());
         watcher.Created += (s, e) =>
            AddMessage("File: {0} Created", e.FullPath);
      }

      private void AddMessage(string formatString,
         params string[] parameters)
      {
         Dispatcher.BeginInvoke(new Action(
            () => WatchOutput.Items.Insert(
               0, string.Format(formatString, parameters))));
      }

      private void BrowseButton_Click(object sender, RoutedEventArgs e)
      {
         OpenFileDialog dialog = new OpenFileDialog();
         if (dialog.ShowDialog(this) == true)
         {
            LocationBox.Text = dialog.FileName;
         }
      }

      private void LocationBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         WatchButton.IsEnabled = !string.IsNullOrEmpty(LocationBox.Text);
      }

      private void WatchButton_Click(object sender, RoutedEventArgs e)
      {
         watcher.Path = System.IO.Path.GetDirectoryName(LocationBox.Text);
         watcher.Filter = System.IO.Path.GetFileName(LocationBox.Text);
         watcher.NotifyFilter = NotifyFilters.LastWrite |
            NotifyFilters.FileName | NotifyFilters.Size;
         AddMessage("Watching " + LocationBox.Text);

         // Begin watching.
         watcher.EnableRaisingEvents = true;
      }
   }
}
