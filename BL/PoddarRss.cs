﻿using System;
using ProjecktPodApp.DL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Pod.Models;
using System.Xml;
using System.IO;

namespace ProjektPodApp.BL
{
    public class PoddarManager //Fungerar som mellanhand mellan DAL och gränssnitt
    {
        //desktop \Podd\ dir
        private string xmlFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "Podd",
        "savedxml.xml" //placeholder
    );
    
    private PodDataAccess PodDataAccess;
    private List<Feed> poddarLista = new List<Feed>();

        public PoddarManager()
        {
            PodDataAccess = new PodDataAccess();
        }

        public List<Feed> HamtaPoddar()
        {
            return PodDataAccess.HamtaPoddar();
        }
        public List<Episode> HamtaEpisoder(string podcastName)
        {
            List<Episode> episodes = new List<Episode>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Sök efter podcast-noden baserat på podcastens namn
            XmlNode podcastNode = xmlDoc.SelectSingleNode($"/Podcasts/Podcast[Name='{podcastName}']");

            if (podcastNode != null)
            {
                // Hämta alla episoder för den valda podcasten
                XmlNodeList episodeNodes = podcastNode.SelectNodes("Episodes/Episode");

                foreach (XmlNode episodeNode in episodeNodes)
                {
                    string title = episodeNode["Title"]?.InnerText;
                    string description = episodeNode["Description"]?.InnerText;
                    DateTime publishDate = DateTime.Parse(episodeNode["PublishDate"]?.InnerText ?? DateTime.MinValue.ToString());

                    // Skapa ett nytt Episode-objekt och lägg till det i listan
                    episodes.Add(new Episode
                    {
                        Title = title,
                        Description = description,
                        PublishedDate = publishDate
                    });
                }
            }

            return episodes;
        }
        public void LaggTillPoddar(Feed nyPoddar)
        {
            PodDataAccess.LaggTillPoddar(nyPoddar);
        }

        public void AndraPoddar(Feed gammalPoddar, Feed nyPoddar)
        {
            PodDataAccess.AndraPoddar(gammalPoddar, nyPoddar);
        }

        public void TaBortPoddar(Feed gammalPoddar)
        {
            PodDataAccess.TaBortPoddar(gammalPoddar);
        }
    }
}

