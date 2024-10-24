using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DL
{
    public class DataLayer<T> // om flytta serial + deserial, ta bort <T>
    {
        public int ID { get; set; } //ha kvar pls
        private string PlaceHolder;


        // TODO lägg serialisering och deserialisering i egen klass??

        //Serialiserarklassen
        public void XmlSer(List<T> poddar, string filepath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            {
                xs.Serialize(fs, poddar);
            }

        }

        //Deserialiserarklassen
        public List<T> XmlDeSer(string filepath)
        {
            //Kollar om det finns en fil, om inte skapar den en ny
            if (!File.Exists(filepath))
            {
                return new List<T>();
            }

            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            using (StreamReader sr = new StreamReader(filepath))
            {
                return (List<T>)xs.Deserialize(sr);
            }
        }


    }

}
