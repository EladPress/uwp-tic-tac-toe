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
    public sealed partial class Registration : Page
    {
        public Registration()
        {
            this.InitializeComponent();
            backButton.Click += BackButton_Click;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Submit(UNameText.Text, fNameText.Text, lNameText.Text, PWText.Password);
        }
        public async static void Submit(string userName, string firstName, string lastName, string password)
        {
            ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();
            if (userName != "" && firstName != "" && lastName != "" && password != "")
            {
                //ServiceReference1.IsUserExistResponse x = await s.IsUserExistAsync(userName);
                bool a = await s.IsUserExistAsync(userName);
                if (a)
                    Classes.Methods.Dialog("This Username is already taken");
                else
                {
                    await s.InsertAsync(userName, firstName, lastName, password);
                    Classes.Methods.Dialog("Registration successful!");
                    var frame = new Frame();
                    frame.Navigate(typeof(firstPage));
                    Window.Current.Content = frame;
                    Window.Current.Activate();
                }
                    
                //userName =
            }
            else
                Classes.Methods.Dialog("Fields are missing");
        }
    }
}
