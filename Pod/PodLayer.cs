﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pod;

namespace Pod
{
    [Serializable]
    public class PodLayer
    {
        private string name;
        private string rsslink;

        //todo allt en podd ska innehålla ska vara här =)
        public short ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }


        public PodLayer() { }

        public PodLayer(short iD, string title, string description, string category)
        {
            ID = iD;
            Title = title;
            Description = description;
            Category = category;

        }

        public PodLayer(string name, string rsslink)
        {
            this.name = name;
            this.rsslink = rsslink;
        }
    }
}
