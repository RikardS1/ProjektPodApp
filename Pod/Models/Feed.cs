using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pod.Models
{
    [Serializable]
    public class Feed
    {
        private string name;
        private string rsslink;
        public string Frequency { get; set; }
        public string Category { get; set; }

        public int NumberOfEpisodes { get; set; }
        public double Minutes { get; set; }
        public List<Episode> Episodes { get; set; }
        public Feed(int numberOfEpisodes, string frequency, string category, List<Episode> episodes)
        {

            NumberOfEpisodes = numberOfEpisodes;
            Frequency = frequency;
            Category = category;
            Episodes = episodes;
           
            //Minutes = getFrequencyMinutes(frequency);
        }

        //private int getFrequencyMinutes(string inFrequency)
        //{
        //    int minutes;
        //    switch (inFrequency)
        //    {
        //        case "Var 1:a minut":
        //            minutes = 1;
        //            break;
        //        case "Var 5:e minut":
        //            minutes = 5;
        //            break;
        //        case "Var 10:e minut":
        //            minutes = 10;
        //            break;
        //        case "Var 15:e minut":
        //            minutes = 15;
        //            break;
        //        case "Var 20:e minut":
        //            minutes = 20;
        //            break;
        //        default:
        //            minutes = 10;
        //            break;
        //    }
        //    return minutes;
        //}
    
    public Feed(string name, string rsslink)
    {
        this.name = name;
        this.rsslink = rsslink;
    }
    }
}



