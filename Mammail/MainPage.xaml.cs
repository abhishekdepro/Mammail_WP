using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.Browser;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Advertising.Mobile.UI;
using System.Diagnostics;

namespace Mammail
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        EmailComposeTask e1 = new EmailComposeTask();
        public MainPage()
        {
            InitializeComponent();
             

           
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text != "")
            {
                e1.Cc = textBox2.Text;
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter a Subject!", "Error", MessageBoxButton.OK);
                    textBox3.Focus();
                }
                else
                {
                    e1.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select a sender!", "Error", MessageBoxButton.OK);
                textBox4.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            e1.Body = textBox1.Text;
            //textBox1.Opacity = 1;
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            e1.Subject = textBox3.Text;
            //textBox3.Opacity = 1;
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            e1.To = textBox4.Text;
            //textBox4.Opacity = 1;
        }

        private void textBox4_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            if (textBox4.Text == "example@live.com")
            {
                textBox4.Text = "";
            }
        }

        private void textBox2_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            if (textBox2.Text == "example@hotmail.com")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            if (textBox3.Text == "Subject")
            {
                textBox3.Text = "";
            }
        }

        private void textBox1_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            if (textBox1.Text == "Message")
            {
                textBox1.Text = "";
            }
        }

        private void TxtAboutMeBlk_Tap(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AboutMe.xaml", UriKind.Relative));
        }

        private void adControl1_AdRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine("AdControl new ad received");
        }


    }
    
}
