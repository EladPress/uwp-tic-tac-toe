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
using System.Xml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        private List<Classes.Users> userList;
        public int ID;
        public string userName;
        public string firstName;
        public string lastName;
        public string password;
        public AdminPage()
        {
            this.InitializeComponent();
            back.Click += Back_Click;
            GetData();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
            Window.Current.Content = this.Frame;
            Window.Current.Activate();
        }

        public async void GetData()
        {
            ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.GetTableResponseGetTableResult r = await s.GetTableAsync();
            userList = new List<Classes.Users>();
            Classes.Users user = null;
            XmlReader xr = r.Any1.CreateReader();
            XmlDocument document = new XmlDocument();
            document.Load(xr);
            XmlNodeList xml_Users_list = document.GetElementsByTagName("Users");
            foreach(XmlElement item in xml_Users_list)
            {
                user = new Classes.Users();
                foreach(XmlNode node in item.ChildNodes)
                {
                    switch(node.Name)
                    {
                        case "ID": user.ID = int.Parse(node.InnerText); break;
                        case "userName": user.UserName = node.InnerText; break;
                        case "firstName": user.FirstName = node.InnerText; break;
                        case "lastName": user.LastName = node.InnerText; break;
                        case "password": user.Password = node.InnerText; break;
                        case "score": user.Score = int.Parse(node.InnerText); break;
                        case "isAdmin": user.IsAdmin = Boolean.Parse(node.InnerText); break;
                        default: break;
                    }
                }
                userList.Add(user);
            }
            grid1.ItemsSource = userList;
        }

        private void Grid1_ItemClick(object sender, ItemClickEventArgs e)
        {
            userNameLabel.Visibility = Visibility.Visible;
            userNameText.Visibility = Visibility.Visible;
            firstNameLabel.Visibility = Visibility.Visible;
            firstNameText.Visibility = Visibility.Visible;
            lastNameLabel.Visibility = Visibility.Visible;
            lastNameText.Visibility = Visibility.Visible;
            PasswordLabel.Visibility = Visibility.Visible;
            PasswordText.Visibility = Visibility.Visible;
            updateButton.Visibility = Visibility.Visible;
            var user = (Classes.Users)e.ClickedItem;
            ID = user.ID;
            userName = user.UserName;
            firstName = user.FirstName;
            lastName = user.LastName;
            password = user.Password;
            userNameText.Text = userName;
            firstNameText.Text = firstName;
            lastNameText.Text = lastName;
            PasswordText.Text = password;
        }
        
        

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        /*public async static void Update(int ID, string userName, string firstName, string lastName, string password, string prevUserName)
        {
            ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();
            if (userName != "" && firstName != "" && lastName != "" && password != "")
            {
                //ServiceReference1.IsUserExistResponse x = await s.IsUserExistAsync(userName);
                bool a = await s.IsUserExistAsync(userName);
                if (a && userName != prevUserName)
                    Classes.Methods.Dialog("This Username is already taken");
                else
                {
                    await s.UpdateAsync(ID, userName, firstName, lastName, password);
                    Classes.Methods.Dialog("update successful!");
                    var frame = new Frame();
                    frame.Navigate(typeof(AdminPage));
                    Window.Current.Content = frame;
                    Window.Current.Activate();
                }

                //userName =
            }
            else
                Classes.Methods.Dialog("Fields are missing");
        }*/

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Methods.Update(ID, userNameText.Text, firstNameText.Text, lastNameText.Text, PasswordText.Text, userName);
        }
    }
}
