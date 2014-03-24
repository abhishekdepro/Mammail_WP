using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Mammmail_WP8;
using Parse;

namespace Mammail_WP8.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static List<Message> message=new List<Message>();
        public MainViewModel()
        {
            this.Items = new ObservableCollection<Message>();

        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<Message> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {
            // Sample data; replace with real data
            message.Clear();
            try
            {
                var query = ParseObject.GetQuery("message")
                    .WhereEqualTo("uid", ParseUser.CurrentUser.Username);
                IEnumerable<ParseObject> results = await query.FindAsync();

               
                this.Items.Clear();
                
                foreach (ParseObject result in results)
                {
                    string _to = Encryption.encrypt(result.Get<string>("to"));
                    string _cc = Encryption.encrypt(result.Get<string>("cc"));
                    string _sub = Encryption.encrypt(result.Get<string>("subject"));
                    string _body = Encryption.encrypt(result.Get<string>("body"));
                    this.Items.Add(new Message { To = _to, Body = _body, Cc = _cc, Subject = _sub, ObjectId=result.ObjectId });
                    message.Add(new Message { To = _to, Body = _body, Cc = _cc, Subject = _sub, ObjectId=result.ObjectId });
                }

                if (message.Count==0)
                {
                 //   emailPanorama.DefaultItem = emailPanorama.Items[1];
                    MessageBox.Show("You do not have any saved messages. Type a message and click save button below to save it.");
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data could not be fetched!", "Error", MessageBoxButton.OK);
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
