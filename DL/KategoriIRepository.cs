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
    public class KategoriDataAccess : IRepository<string> //datalagret har här färdiga kategorier som ligger inom metoden HamtaKategorier.
    {

        private const string KategoriFolder = "Kategorier"; //Filnamn för XML filen
        private string KategoriFil;

        public KategoriDataAccess()
        {
            // Hämta sökvägen till skrivbordet och kombinera med mappens namn
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string kategorierPath = Path.Combine(desktopPath, KategoriFolder);

            // Sätt sökvägen till filen
            KategoriFil = Path.Combine(kategorierPath, "kategorier.xml");

            // Kontrollera och skapa mappen om den inte finns
            if (!Directory.Exists(kategorierPath))
            {
                Directory.CreateDirectory(kategorierPath);
            }
        }



        public List<string> HamtaAlla() //returnerar en lista med kategorier
        {
            if (!File.Exists(KategoriFil))
            {
                return new List<string> { "Humor", "Hälsa", "Utbildning", "True crime", "Historia" };
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); //Skapa en xmlSerializer som hanterar listan

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Open)) //Öppnar xml-filen för att läsa in data

            {
                return (List<string>)serializer.Deserialize(fs); //Deseriaiserar xml innehållet till en lista med Strings (Kategorier), den retuneras sedan
            }

        }

        public void LaggTill(string nyKategori) //lägger till ny kategori i listan
        {
            var kategorier = HamtaAlla();


            if (!string.IsNullOrEmpty(nyKategori))
            {
                kategorier.Add(nyKategori);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); //Skapa en xmlSerializer som hanterar listan

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Create)) //Öppnar xml-filen för att läsa in data

            {
                serializer.Serialize(fs, kategorier);
            }
        }



        public void Andra(string gammalKategori, string nyKategori)

        {
            var kategorier = HamtaAlla();
            int index = kategorier.IndexOf(gammalKategori); // Räknar i listan efter gammalkategori
            if (index != -1)
            {
                kategorier[index] = nyKategori; // Ändra namnet
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

            using (FileStream fs = new FileStream(KategoriFil, FileMode.Create))
            {
                serializer.Serialize(fs, kategorier);
            }
        }

        public void TaBort(string gammalKategori)
        {
            var kategorier = HamtaAlla();
            int index = kategorier.IndexOf(gammalKategori); // Räknar i listan efter gammalkategori
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
