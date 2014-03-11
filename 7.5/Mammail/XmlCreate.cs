using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;

namespace Mammail
{
    public class XmlCreate
    {
        public static void create(object obj, IsolatedStorageFileStream filename) {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextReader read = new StreamReader(filename);
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();

        }

        public static Information Deserialize(IsolatedStorageFileStream filename) {
            XmlSerializer sr = new XmlSerializer(typeof(Information));
            TextReader read = new StreamReader(filename);
            Information feedback = (Information)sr.Deserialize(filename);
            return feedback;
        }
    }
}
