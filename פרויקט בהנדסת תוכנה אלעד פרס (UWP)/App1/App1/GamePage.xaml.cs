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
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Input;
using System.Windows.Input;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public ImageBrush XBrush;
        public Image XImage;
        public ImageBrush CBrush;
        public static int i = 0;
        //Ellipse ellipse = new Ellipse();
        public int[,] myArray = new int[4, 4];//1= X, 2 = C || first digit = rows, second digit = collums.
        public GamePage gamePage;
        DispatcherTimer myTimer;
        DateTime d;
        
        

        public void NewPage()
        {
            Classes.Methods.Dialog("Players are now switched! ");
            this.Frame.Navigate(typeof(GamePage));
            Player tempPlayer = new Player(firstPage.XPlayer.GetName(), firstPage.XPlayer.GetScore());
            firstPage.XPlayer = firstPage.CPlayer;
            firstPage.CPlayer = tempPlayer;
            //XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :(איקס)" + firstPage.XPlayer.GetName();
            //CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :(עיגול)" + firstPage.CPlayer.GetName();
            i = 0;
        }
        public void NewPage(string s)
        {
            Classes.Methods.Dialog(s +  " Players are now switched!");
            this.Frame.Navigate(typeof(GamePage));
            Window.Current.Content = this.Frame;
            Window.Current.Activate();
            Player tempPlayer = new Player(firstPage.XPlayer.GetName(), firstPage.XPlayer.GetScore());
            firstPage.XPlayer = firstPage.CPlayer;
            firstPage.CPlayer = tempPlayer;
            //XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :(איקס)" + firstPage.XPlayer.GetName();
            //CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :(עיגול)" + firstPage.CPlayer.GetName();
            i = 0;
        }
        
        
        
        public void XWon()
        {
            firstPage.XPlayer.win();
            NewPage(firstPage.XPlayer.GetName() + " won!");
            i = 0;
        }
        public void CWon()
        {
            //Dialog(firstPage.CPlayer.GetName() + " won!");
            firstPage.CPlayer.win();
            NewPage(firstPage.XPlayer.GetName() + " won!");
            i = 0;
        }
        public void Tie()
        {
            //Dialog("Tie!");
            NewPage("Tie!");
            i = 0;
        }

        public void NewTurn()
        {
            i++;
            VictoryCheck();
            PlayerInfo();
        }
        
        public void PlayerInfo()
        {
             XScoreLabel.Text = firstPage.XPlayer.GetName() + ": " + firstPage.XPlayer.GetScore();
             CScoreLabel.Text = firstPage.CPlayer.GetName() + ": " + firstPage.CPlayer.GetScore();
        }

        public void VictoryCheck()
        {
            if (myArray[1, 1] == myArray[1, 2] && myArray[1, 2] == myArray[1, 3])//בדיקת שורה ראשונה
            {
                if (myArray[1, 1] == 1)
                {
                    XWon();
                }

                if (myArray[1, 1] == 2)
                {
                    CWon();
                }

            }
            if (myArray[2, 1] == myArray[2, 2] && myArray[2, 2] == myArray[2, 3])// בדיקת שורה שנייה
            {
                if (myArray[2, 2] == 1)
                {
                    XWon();
                }

                if (myArray[2, 2] == 2)
                {
                    CWon();
                }
            }
            if (myArray[3, 1] == myArray[3, 2] && myArray[3, 2] == myArray[3, 3])//בדיקת שורה שלישית
            {
                if (myArray[3, 2] == 1)
                {
                    XWon();
                }
                if (myArray[3, 2] == 2)
                {
                    CWon();
                }
            }
            if (myArray[1, 1] == myArray[2, 1] && myArray[3, 1] == myArray[2, 1])// בדיקת טור ראשון
            {
                if (myArray[1, 1] == 1)
                {
                    XWon();
                }
                if (myArray[1, 1] == 2)
                {
                    CWon();
                }
            }
            if (myArray[1, 2] == myArray[2, 2] && myArray[2, 2] == myArray[3, 2])//בדיקת טור שני
            {
                if (myArray[1, 2] == 1)
                {
                    XWon();
                }
                if (myArray[1, 2] == 2)
                {
                    CWon();
                }

            }
            if (myArray[1, 3] == myArray[2, 3] && myArray[2, 3] == myArray[3, 3])//בדיקת טור שלישי
            {
                if (myArray[1, 3] == 1)
                {
                    XWon();
                }
                if (myArray[1, 3] == 2)
                {
                    CWon();
                }

            }
            if (myArray[1, 1] == myArray[2, 2] && myArray[2, 2] == myArray[3, 3])
            {
                if (myArray[1, 1] == 1)
                {
                    XWon();
                }
                if (myArray[1, 1] == 2)
                {
                    CWon();
                }
            }
            if (myArray[1, 3] == myArray[2, 2] && myArray[2, 2] == myArray[3, 1])
            {
                if (myArray[2, 2] == 1)
                {
                    XWon();
                }
                if (myArray[2, 2] == 2)
                {
                    CWon();
                }
            }
            else
            {
                if (myArray[1, 1] != 0 && myArray[1, 2] != 0 && myArray[1, 3] != 0 && myArray[2, 1] != 0 && myArray[2, 2] != 0 && myArray[2, 3] != 0 && myArray[3, 1] != 0 && myArray[3, 2] != 0 && myArray[3, 3] != 0)
                    Tie();
            }
        }
        public GamePage()
        {
            this.InitializeComponent();
            PlayerInfo();
            
            Uri uri = new Uri("ms-appx:///Assets/image3.PNG");
            
            BitmapImage XImage = new BitmapImage(uri);
            XBrush = new ImageBrush();
            XBrush.ImageSource = XImage;

            Uri uri2 = new Uri("ms-appx:///Assets/circle.PNG");
            BitmapImage CImage = new BitmapImage(uri2);
            CBrush = new ImageBrush();
            CBrush.ImageSource = CImage;

            l1.PointerPressed += L1_PointerPressed;
            l2.PointerPressed += L2_PointerPressed;
            l3.PointerPressed += L3_PointerPressed;
            l4.PointerPressed += L4_PointerPressed;
            l5.PointerPressed += L5_PointerPressed;
            l6.PointerPressed += L6_PointerPressed;
            l7.PointerPressed += L7_PointerPressed;
            l8.PointerPressed += L8_PointerPressed;
            l9.PointerPressed += L9_PointerPressed;
            b1.Click += B1_Click1;
            b2.Click += B2_Click;

            myTimer = new DispatcherTimer();
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
        }

        private void MyTimer_Tick(object sender, object e)
        {
            d = DateTime.Now;
            
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
            i = 0;
        }

        private void B1_Click1(object sender, RoutedEventArgs e)
        {
            NewPage();
        }

        private void L9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l9b.Background = XBrush;
                myArray[3, 3] = 1;
            }
            else
            {
                l9b.Background = CBrush;
                myArray[3, 3] = 2;

            }
            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetName() + " :" + firstPage.XPlayer.GetScore();
            CScoreLabel.Text = firstPage.CPlayer.GetName() + " :" + firstPage.CPlayer.GetScore();*/
            NewTurn();
            l9.PointerPressed -= L9_PointerPressed;
        }

        private void L8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l8b.Background = XBrush;
                myArray[2, 3] = 1;
            }
            else
            {
                l8b.Background = CBrush;
                myArray[2, 3] = 2;

            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l8.PointerPressed -= L8_PointerPressed;
        }

        private void L7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l7b.Background = XBrush;
                myArray[1, 3] = 1;
            }
            else
            {
                l7b.Background = CBrush;
                myArray[1, 3] = 2;

            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l7.PointerPressed -= L7_PointerPressed;
        }

        private void L6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l6b.Background = XBrush;
                myArray[3, 2] = 1;
            }
            else
            {
                l6b.Background = CBrush;
                myArray[3, 2] = 2;

            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l6.PointerPressed -= L6_PointerPressed;
        }

        private void L5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l5b.Background = XBrush;
                myArray[2, 2] = 1;
            }
            else
            {
                l5b.Background = CBrush;
                myArray[2, 2] = 2;

            }

            /* i++;
             VictoryCheck();
             XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
             CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l5.PointerPressed -= L5_PointerPressed;
        }

        private void L4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l4b.Background = XBrush;
                myArray[1, 2] = 1;
            }
            else
            {
                l4b.Background = CBrush;
                myArray[1, 2] = 2;

            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l4.PointerPressed -= L4_PointerPressed;
        }

        private void L3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l3b.Background = XBrush;
                myArray[3, 1] = 1;
            }
            else
            {
                l3b.Background = CBrush;
                myArray[3, 1] = 2;

            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l3.PointerPressed -= L3_PointerPressed;
        }

        private void L2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l2b.Background = XBrush;
                myArray[2, 1] = 1;
            }
            else
            {
                l2b.Background = CBrush;
                myArray[2, 1] = 2;

            }

            /* i++;
             VictoryCheck();
             XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
             CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l2.PointerPressed -= L2_PointerPressed;
        }

        private void L1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                l1b.Background = XBrush;
                myArray[1, 1] = 1;
            }
            else
            {
                l1b.Background = CBrush;
                myArray[1, 1] = 2;
                
            }

            /*i++;
            VictoryCheck();
            XScoreLabel.Text = firstPage.XPlayer.GetScore() + " :" + firstPage.XPlayer.GetName();
            CScoreLabel.Text = firstPage.CPlayer.GetScore() + " :" + firstPage.CPlayer.GetName();*/
            NewTurn();
            l1.PointerPressed -= L1_PointerPressed;
        }

        
    }
}
 