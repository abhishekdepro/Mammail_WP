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
                    msg["to"] = Encryption.encrypt(to.Text);
                    msg["cc"] = Encryption.encrypt(cc.Text);
                    msg["subject"] = Encryption.encrypt(sub.Text);
                    msg["body"] = Encryption.encrypt(body.Text);
                    await msg.SaveAsync();
                    MessageBox.Show("Message saved","Success",MessageBoxButton.OK);
                    saveTile(sub.Text,to.Text);
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

        private void saveTile(string sub,string to)
        {
             ShellTile oTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("flip".ToString()));
 
 
            if (oTile != null && oTile.NavigationUri.ToString().Contains("flip"))
            {
                FlipTileData oFliptile = new FlipTileData();
                oFliptile.Title = "Mammail 3.0";
                //oFliptile.Count = 11;
                oFliptile.BackTitle = "Saved Messages";
 
                oFliptile.BackContent = sub;
                oFliptile.WideBackContent = to;

                oFliptile.SmallBackgroundImage = new Uri("Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
                oFliptile.BackgroundImage = new Uri("Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative);
                oFliptile.WideBackgroundImage = new Uri("Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative);
 
                oTile.Update(oFliptile);
                //MessageBox.Show("Flip Tile Data successfully update.");
            }
            else
            {
                // once it is created flip tile
                Uri tileUri = new Uri("/MainPage.xaml?tile=flip", UriKind.Relative);
                ShellTileData tileData = this.CreateFlipTileData();
                ShellTile.Create(tileUri, tileData, true);
            }
        }
 
        private ShellTileData CreateFlipTileData()
        {
            return new FlipTileData()
            {
                Title = "Mammail 3.0",
                BackTitle = "Mail.Easy.Fast",
                BackContent = "Messages",
                WideBackContent = "Messages",
                
                SmallBackgroundImage = new Uri("/Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative),
                BackgroundImage = new Uri("/Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative),
                WideBackgroundImage = new Uri("/Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative),
            };
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
                    e1.Body = body.Text+Environment.NewLine+"Sent from Mammail 3.0 for Windows Phone";
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

        private void to_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (to.Text == "To:")
            {
                to.Text = "";
            }
        }

      
    }
}   