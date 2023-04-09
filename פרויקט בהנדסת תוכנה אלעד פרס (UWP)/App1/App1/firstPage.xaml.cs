using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class firstPage : Page
    {
        DispatcherTimer myTimer;
        public Boolean playerExist;
        public static Player XPlayer = new Player();
        public static Player CPlayer = new Player();
        GamePage gamePage = new GamePage();
        public firstPage()
        {
            this.InitializeComponent();
            play.Click += Play_Click;
            myTimer = new DispatcherTimer();
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
            regButton.Click += RegButton_Click;
           
        }

        

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registration));
        }

        private void MyTimer_Tick(object sender, object e)
        {
            //throw new NotImplementedException();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
                if (XUserText.Text == "" || CUserText.Text == "")
                {
                    Classes.Methods.Dialog("Please name the players playing");
                }
                else
                {
                    XPlayer = new Player(XUserText.Text, 0);
                    CPlayer = new Player(CUserText.Text, 0);
                    this.Frame.Navigate(typeof(GamePage));
                }
            
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
            Window.Current.Content = this.Frame;
            Window.Current.Activate();
        }

        
    }
}
