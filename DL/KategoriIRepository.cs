using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DL;

namespace ProjecktPodApp.DL
{
    public class KategoriDataAccess : IRepository<string> 
    {

        private const string KategoriFolder = "Kategorier"; 
        private string KategoriFil;

        public KategoriDataAccess()
        {
            
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string kategorierPath = Path.Combine(desktopPath, KategoriFolder);

            // Sätt sökvägen till filen
            KategoriFil = Path.Combine(kategorierPath, "kategorier.xml");

            
            if (!Directory.Exists(kategorierPath))
            {
                Directory.CreateDirectory(kategorierPath);
            }
        }



        public List<string> HamtaAlla() //Hämtar Kategorier
        {
            if (!File.Exists(KategoriFil))
            {
                return new List<string> { "Humor", "Hälsa","Sport ", "Utbildning", "True crime", "Historia" ,"Musik"};
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); 
            using (FileStream fs = new FileStream(KategoriFil, FileMode.Open)) 

            {
                return (List<string>)serializer.Deserialize(fs); 
            }

        }

        public void LaggTill(string nyKategori) //lägger Till
        {
            var kategorier = HamtaAlla();


            if (!string.IsNullOrEmpty(nyKategori))
            {
                kategorier.Add(nyKategori);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); 

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Create)) 

            {
                serializer.Serialize(fs, kategorier);
            }
        }



        public void Andra(string gammalKategori, string nyKategori)//Ändrar

        {
            var kategorier = HamtaAlla();
            int index = kategorier.IndexOf(gammalKategori); 
            if (index != -1)
            {
                kategorier[index] = nyKategori; 
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Create))
            {
                serializer.Serialize(fs, kategorier);
            }
        }

        public void TaBort(string gammalKategori)// taBort
        {
            var kategorier = HamtaAlla();
            int index = kategorier.IndexOf(gammalKategori); 
            if (index != -1)
            {
                kategorier.RemoveAt(index);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Create))
            {
                serializer.Serialize(fs, kategorier);
            }
        }
    }
}
