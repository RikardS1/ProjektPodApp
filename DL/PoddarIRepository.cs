using DL;
using Pod.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjecktPodApp.DL
{
    public class PodDataAccess : IRepository<Feed>
    {
        private const string PoddFolder = "Podd";
        private string PoddFil;

        public PodDataAccess()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string PoddPath = Path.Combine(desktopPath, PoddFolder);
            PoddFil = Path.Combine(PoddPath, "Podd.xml");

            if (!Directory.Exists(PoddPath))
            {
                Directory.CreateDirectory(PoddPath);
            }
        }

        public List<Feed> HamtaAlla()
        {
            if (!File.Exists(PoddFil))
            {
                return new List<Feed>(); // Returnera en tom lista om filen inte finns
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
            using (FileStream fs = new FileStream(PoddFil, FileMode.Open))
            {
                return (List<Feed>)serializer.Deserialize(fs);
            }
        }

        public void LaggTill(Feed nyPodd)
        {
            var poddar = HamtaAlla();
            if (!string.IsNullOrEmpty(nyPodd.Name) && !string.IsNullOrEmpty(nyPodd.OfficialName))
            {
                poddar.Add(nyPodd);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
            using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
            {
                serializer.Serialize(fs, poddar);
            }
        }

        public void Andra(Feed gammalPodd, Feed nyPodd)
        {
            var poddar = HamtaAlla();
            int index = poddar.FindIndex(p => p.Name == gammalPodd.Name && p.OfficialName == gammalPodd.OfficialName);
            if (index != -1)
            {
                poddar[index] = nyPodd;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
            using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
            {
                serializer.Serialize(fs, poddar);
            }
        }
        public void TaBort(Feed gammalPodd)
        {
            // Load current list of feeds from XML
            var poddar = HamtaAlla();

            // Debug: Display feeds before removal
            Console.WriteLine("Feeds before removal:");
            foreach (var podd in poddar)
            {
                Console.WriteLine($"Feed Name: {podd.Name}, OfficialName: {podd.OfficialName}");
            }

            // Find and remove the specified feed
            int index = poddar.FindIndex(p => p.Name == gammalPodd.Name && p.OfficialName == gammalPodd.OfficialName);
            if (index != -1)
            {
                poddar.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Feed not found, nothing to remove.");
            }

            // Debug: Display feeds after removal
            Console.WriteLine("Feeds after removal:");
            foreach (var podd in poddar)
            {
                Console.WriteLine($"Feed Name: {podd.Name}, OfficialName: {podd.OfficialName}");
            }

            // Serialize updated list back to XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
            using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
            {
                serializer.Serialize(fs, poddar);
            }
        }

        //public void TaBortPoddar(Feed gammalPodd)
        //{
        //    var poddar = HamtaPoddar();
        //    int index = poddar.FindIndex(p => p.Name == gammalPodd.Name && p.OfficialName == gammalPodd.OfficialName);
        //    if (index != -1)
        //    {
        //        poddar.RemoveAt(index);
        //    }

        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
        //    using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
        //    {
        //        serializer.Serialize(fs, poddar);
        //    }
        //}
    }
}
