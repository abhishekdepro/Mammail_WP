using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Mammail
{
    public partial class AboutMe : PhoneApplicationPage
    {
        public AboutMe()
        {
            InitializeComponent();
        }
       

        

        private void Fb_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("https://m.facebook.com/abhishekde.nasa");
            browser.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("https://twitter.com/abhishekdepro");
            browser.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("https://github.com/abhishekdepro");
            browser.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("http://bitsandbinaries.wordpress.com/");
            browser.Show();
        }


    }
}