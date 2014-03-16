using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace TelerikWindowsPhoneApp1
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.Uri = new Uri("http://asthmaccurate.cloudapp.net/", UriKind.Absolute);
            browser.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            EmailComposeTask e1 = new EmailComposeTask();
            e1.To = "abhishekde@hotmail.com";
            e1.Cc = "surrealbelongings@outlook.com";
            e1.Subject = "Feedback on mammail";
            e1.Body = Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString();
            e1.Show();
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask web1 = new WebBrowserTask();
            web1.Uri = new Uri("http://asthmaccurate.cloudapp.net/paypal.html", UriKind.Absolute);
            web1.Show();
        }
    }
}
