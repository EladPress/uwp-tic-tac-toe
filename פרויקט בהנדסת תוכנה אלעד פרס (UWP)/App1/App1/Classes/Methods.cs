using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace App1.Classes
{
    public class Methods
    {
        public async static void Dialog(String s)
        {
            MessageDialog msgbox = new MessageDialog(s);
            var result = await msgbox.ShowAsync();
        }
        public async static void Update(int ID, string userName, string firstName, string lastName, string password, string prevUserName)
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
                    /*var frame = new Frame();
                    frame.Navigate(typeof(AdminPage));
                    Window.Current.Content = frame;
                    Window.Current.Activate();*/
                }

                //userName =
            }
            else
                Classes.Methods.Dialog("Fields are missing");
        }

    }
}
