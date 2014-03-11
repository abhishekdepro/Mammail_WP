using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mammail
{
    public class Information
    {
        private string _to, _cc, _subject, _body;

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

    }
}