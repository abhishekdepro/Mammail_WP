using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammmail_WP8
{
    public class Message : INotifyPropertyChanged
    {
        private string _to, _cc, _sub, _body,_objectid;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        /// 
        public string ObjectId
        {
            get
            {
                return _objectid;
            }
            set
            {
                if (value != _objectid)
                {
                    _objectid = value;
                    NotifyPropertyChanged("ObjectId");
                }
            }
        }
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                if (value != _to)
                {
                    _to = value;
                    NotifyPropertyChanged("To");
                }
            }
        }

        public string Cc
        {
            get
            {
                return _cc;
            }
            set
            {
                if (value != _cc)
                {
                    _cc = value;
                    NotifyPropertyChanged("Cc");
                }
            }
        }

        public string Subject
        {
            get
            {
                return _sub;
            }
            set
            {
                if (value != _sub)
                {
                    _sub = value;
                    NotifyPropertyChanged("Sub");
                }
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                if (value != _body)
                {
                    _body = value;
                    NotifyPropertyChanged("Body");
                }
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
