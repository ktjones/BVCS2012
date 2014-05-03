using KarliCards_Gui.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace KarliCards.Gui
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
          if (args.PreviousExecutionState == ApplicationExecutionState.Running)
          {
            Window.Current.Activate();
            return;
          }

          var rootFrame = new Frame();
          KarliCards.Gui.Common.SuspensionManager.RegisterFrame(rootFrame, "karliCardsFrame");

          if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
          {
            KarliCards.Gui.Common.SuspensionManager.KnownTypes.Add(typeof(GameViewModel));
            await KarliCards.Gui.Common.SuspensionManager.RestoreAsync();
          }

          if (rootFrame.Content == null)
          {
            if (!rootFrame.Navigate(typeof(MainPage)))
            {
              throw new Exception("Failed to create initial page");
            }
          }

          Window.Current.Content = rootFrame;
          Window.Current.Activate();
        }
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
          var deferral = e.SuspendingOperation.GetDeferral();
          KarliCards.Gui.Common.SuspensionManager.KnownTypes.Add(typeof(GameViewModel));
          await KarliCards.Gui.Common.SuspensionManager.SaveAsync();
          deferral.Complete();
        }

    }
}
