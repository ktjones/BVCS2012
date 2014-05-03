using System;
using System.IO;
using System.Runtime.Serialization;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ch17Ex01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
          var data = new AppData
          {
            State = AppStates.Started,
            TheAnswer = 42,
            StateData = new AppStateData { Data = "The data is being saved" }
          };
          var fileSavePicker = new FileSavePicker
          {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            DefaultFileExtension = ".xml",
          };
          fileSavePicker.FileTypeChoices.Add("XML file", new[] { ".xml" });
          var file = await fileSavePicker.PickSaveFileAsync();
          if (file != null)
          {
            var stream = await file.OpenStreamForWriteAsync();
            var serializer = new DataContractSerializer(typeof(AppData));
            serializer.WriteObject(stream, data);
          }
        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
          var fileOpenPicker = new FileOpenPicker
          {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            ViewMode = PickerViewMode.Thumbnail
          };
          fileOpenPicker.FileTypeFilter.Add(".xml");
          var file = await fileOpenPicker.PickSingleFileAsync();
          if (file != null)
          {
            var stream = await file.OpenStreamForReadAsync();
            var serializer = new DataContractSerializer(typeof(AppData));
            var data = serializer.ReadObject(stream);
          }
        }


    }
}
