
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    namespace ProjecktPodApp.DL
    {
        public class PodDataAccess //datalagret har här färdiga kategorier som ligger inom metoden HamtaKategorier.
        {

            private const string PoddFolder = "Podd"; //Filnamn för XML filen
            private string PoddFil;

            public PodDataAccess()
            {
                // Hämta sökvägen till skrivbordet och kombinera med mappens namn
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string PoddPath = Path.Combine(desktopPath, PoddFolder);

                // Sätt sökvägen till filen
                PoddFil = Path.Combine(PoddPath, "Poddar.xml");

                // Kontrollera och skapa mappen om den inte finns
                if (!Directory.Exists(PoddPath))
                {
                    Directory.CreateDirectory(PoddPath);
                }
            }



            public List<string> HamtaPoddar() //returnerar en lista med kategorier
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); //Skapa en xmlSerializer som hanterar listan

                using (FileStream fs = new FileStream(PoddFil, FileMode.Open)) //Öppnar xml-filen för att läsa in data

                {
                    return (List<string>)serializer.Deserialize(fs); //Deseriaiserar xml innehållet till en lista med Strings (Kategorier), den retuneras sedan
                }

            }

            public void LaggTillPoddar(string nyPoddar) //lägger till ny kategori i listan
            {
                var poddar = HamtaPoddar();


                if (!string.IsNullOrEmpty(nyPoddar))
                {
                    poddar.Add(nyPoddar);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<string>)); //Skapa en xmlSerializer som hanterar listan

                using (FileStream fs = new FileStream(PoddFil, FileMode.Create)) //Öppnar xml-filen för att läsa in data

                {
                    serializer.Serialize(fs, poddar);
                }
            }



            public void AndraPoddar(string gammalPoddar, string nyPoddar)

            {
                var poddar = HamtaPoddar();
                int index = poddar.IndexOf(gammalPoddar); 
                if (index != -1)
                {
                    poddar[index] = nyPoddar;
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
                {
                    serializer.Serialize(fs, poddar);
                }
            }

            public void TaBortPoddar(string gammalPoddar)
            {
                var poddar = HamtaPoddar();
                int index = poddar.IndexOf(gammalPoddar); // Räknar i listan efter gammalkategori
                if (index != -1)
                {
                    poddar.RemoveAt(index);
                } //lägg till kod för xml och serialisera, se chat. men ev gör interface av det
            }
        }
    }


