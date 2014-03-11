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
using System.IO.IsolatedStorage;
using System.IO;

namespace Mammail
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public int count = 0;
        IsolatedStorageFileStream data;
        EmailComposeTask e1 = new EmailComposeTask();
        public MainPage()
        {
            InitializeComponent();

            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            data = myIsolatedStorage.OpenFile("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);     
            
           
                
            
            //create new file
            
                try
                {
                    //IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("myFile.txt", FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {    //Visualize the text data in a TextBlock text
                        count = Convert.ToInt32(reader.ReadLine());
                    }
                }
                catch (IsolatedStorageException e)
                {
                    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.OpenOrCreate, FileAccess.Write, myIsolatedStorage)))
                    {
                        string someTextData = (count + 1).ToString();
                        writeFile.WriteLine(someTextData);
                        writeFile.Close();
                    }
                }
            
            if (count%4==0 && count>0)
            {
                MessageBoxResult result = MessageBox.Show("We'd really love to hear from you. Press OK for rating us or CANCEL for feedback.", "Did you like me?", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.Open, FileAccess.Write, myIsolatedStorage)))
                    {
                        string someTextData = "-999";
                        writeFile.WriteLine(someTextData);
                        writeFile.Close();
                    }
                    MarketplaceReviewTask review = new MarketplaceReviewTask();
                    review.Show();
                }
                else {
                    MessageBoxResult result1 = MessageBox.Show("Press OK for feedback and CANCEL to return","Feedback",MessageBoxButton.OKCancel);
                    if (result1 == MessageBoxResult.OK)
                    {
                        textBox4.Text = "abhishekde@hotmail.com";
                        textBox3.Text = "Feedback on Mammail";
                        textBox1.Text = "===========================Device Status:"+Microsoft.Phone.Info.DeviceStatus.DeviceName;
                        textBox2.Text = "";
                    }
                    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.Open, FileAccess.Write, myIsolatedStorage)))
                    {
                        string someTextData = "0";
                        writeFile.WriteLine(someTextData);
                        writeFile.Close();
                    }
                }
               
            }
            else {
                
                using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.Open, FileAccess.Write, myIsolatedStorage)))
                {
                    string someTextData = (count+1).ToString();
                    writeFile.WriteLine(someTextData);
                    writeFile.Close();
                }
                
            }
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

        
            

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AboutMe.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            textBox4.Text = "abhishekde@hotmail.com";
            textBox3.Text = "Feedback on Mammail";
            textBox1.Text = "===========================Device Status:" + Microsoft.Phone.Info.DeviceStatus.DeviceName;
                    
            textBox2.Text = "";
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("We'd really love to hear from you. Press OK for rating us or CANCEL for feedback.", "Did you like me?", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MarketplaceReviewTask review = new MarketplaceReviewTask();
                review.Show();
            }
            else
            {
                MessageBoxResult result1 = MessageBox.Show("Press OK for feedback and CANCEL to return", "Feedback", MessageBoxButton.OKCancel);
                if (result1 == MessageBoxResult.OK)
                {
                    textBox4.Text = "abhishekde@hotmail.com";
                    textBox3.Text = "Feedback on Mammail";
                    textBox1.Text = "===========================Device Status:" + Microsoft.Phone.Info.DeviceStatus.DeviceName;
                    
                    textBox2.Text = "";
                }
            }
                
        }

        private void ApplicationBarIconButton_Click_4(object sender, EventArgs e)
        {
            Information info = new Information();
            info.To = textBox4.Text;
            info.Cc = textBox2.Text;
            info.Subject = textBox3.Text;
            XmlCreate.create(info, data);
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            Information info=XmlCreate.Deserialize(data);
            textBox2.Text = info.Cc;
            textBox3.Text = info.Subject;
            textBox4.Text = info.To;
        }
        

        


    }
    
}
