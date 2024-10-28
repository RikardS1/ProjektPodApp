using Pod.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjecktPodApp.DL
{
    public class PodDataAccess
    {
        private const string PoddFolder = "Podd";
        private string PoddFil;

        public PodDataAccess()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string PoddPath = Path.Combine(desktopPath, PoddFolder);
            PoddFil = Path.Combine(PoddPath, "Pod.xml");

            if (!Directory.Exists(PoddPath))
            {
                Directory.CreateDirectory(PoddPath);
            }
        }

        public List<Feed> HamtaPoddar()
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

        public void LaggTillPoddar(Feed nyPodd)
        {
            var poddar = HamtaPoddar();
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

        public void AndraPoddar(Feed gammalPodd, Feed nyPodd)
        {
            var poddar = HamtaPoddar();
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

        public void TaBortPoddar(Feed gammalPodd)
        {
            var poddar = HamtaPoddar();
            int index = poddar.FindIndex(p => p.Name == gammalPodd.Name && p.OfficialName == gammalPodd.OfficialName);
            if (index != -1)
            {
                poddar.RemoveAt(index);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Feed>));
            using (FileStream fs = new FileStream(PoddFil, FileMode.Create))
            {
                serializer.Serialize(fs, poddar);
            }
        }
    }
}
