﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pod.Models
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }

        public Episode() { }
        public Episode(string title, string description, DateTime publishedDate)
        {
            Title = title;
            Description = description;
            PublishedDate = publishedDate;
        }

        public override string ToString()
        {
            return Title;
        }
        ////OldMan.old
        ////public string Name { get; set; }
        ////public string Summary { get; set; }
        ////public string PublishedDate { get; set; }

        ////public Episode(string name, string summary, string publishedDate)
        ////{

        ////    Name = name;
        ////    Summary = summary;
        ////    PublishedDate = publishedDate;
        ////}
    }
}
