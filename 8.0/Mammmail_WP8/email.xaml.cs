using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Parse;
using System.Windows.Data;
using Microsoft.Phone.Tasks;
using Mammail_WP8.ViewModels;
using Microsoft.Phone.Controls.LocalizedResources;

namespace Mammmail_WP8
{
    public partial class email : PhoneApplicationPage
    {
        int index;
        public email()
        {
            InitializeComponent();
            emailPanorama.Title = ParseUser.CurrentUser.Username;
            DataContext = App.ViewModel;


            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            
        }

        

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
                
            }
            
        }
        

        
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
        }

        private async void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            if (to.Text != "")
            {
                if (sub.Text != "")
                {
                    ParseObject msg = new ParseObject("message");
                    msg["uid"] = ParseUser.CurrentUser.Username;
                    msg["to"] = to.Text;
                    msg["cc"] = cc.Text;
                    msg["subject"] = sub.Text;
                    msg["body"] = body.Text;
                    await msg.SaveAsync();
                    MessageBox.Show("Message saved","Success",MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Must have a Subject!");
                }
            }
            else
            {
                MessageBox.Show("Must have a sender!");
            }
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (to.Text != "")
            {
                if (sub.Text != "")
                {
                    EmailComposeTask e1 = new EmailComposeTask();
                    e1.To = to.Text;
                    e1.Cc = cc.Text;
                    e1.Subject = sub.Text;
                    e1.Body = body.Text;
                    e1.Show();
                }
                else
                {
                    MessageBox.Show("Must have a Subject!");
                }
            }
            else
            {
                MessageBox.Show("Must have a sender!");
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            index = msg.SelectedIndex;

            Message p=MainViewModel.message[index];
            to.Text = p.To;
            cc.Text = p.Cc;
            sub.Text = p.Subject;
            body.Text = p.Body;

            
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            ParseUser.LogOut();
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

      
    }
}   