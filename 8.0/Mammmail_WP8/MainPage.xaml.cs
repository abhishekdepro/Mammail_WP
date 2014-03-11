﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mammmail_WP8.Resources;
using System.IO.IsolatedStorage;
using Parse;

namespace Mammmail_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public static int login = 0;
        public MainPage()
        {
            InitializeComponent();

            
            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            checkuserlogin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Redirect after login to user home page
            /*try
            {
               
                //if user is already logged in
                if (ParseUser.CurrentUser.Username != "abhishek")
                {
                    string user = ParseUser.CurrentUser.Username;
                    MessageBoxResult result = MessageBox.Show("Welcome " + user, "Welcome Back", MessageBoxButton.OK);
                    this.NavigationService.Navigate(new Uri("/email.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    // show the signup or login screen
                }
            }
            catch (Exception ex)
            {

            }*/
           // base.OnNavigatedTo(e);
        }

        private async void checkuserlogin()
        {
            try
            {
                await ParseUser.LogInAsync(username.Text, password.Password);
                MessageBox.Show("Login was successful.");

                //login = 1;
                //appSettings.Remove("Parse.CurrentUser");
                //appSettings.Add("Parse.CurrentUser", username.Text);
                
                // Login was successful.
            }
            catch (Exception ex)
            {
                // The login failed. Check the error to see why.
                //login = 1;
                MessageBox.Show(ex.Message);
            }
        }

        private async void signupbtn_Click(object sender, RoutedEventArgs e)
        {
            var user = new ParseUser()
            {
                Username = username.Text,
                Password = password.Password,
                Email = email.Text
            };

            // other fields can be set just like with ParseObject
            // user["phone"] = "415-392-0202";

            await user.SignUpAsync();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}