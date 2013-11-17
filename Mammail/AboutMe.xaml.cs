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

        private void TxtAbtMe_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("https://twitter.com/abhishekdepro");
            browser.Show();
        }

        private void TxtBlkBlog_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("http://bitsandbinaries.wordpress.com/");
            browser.Show();
        }

        private void TxtBlkGit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();

            browser.Uri = new Uri("https://github.com/abhishekdepro");
            browser.Show();
        }


    }
}