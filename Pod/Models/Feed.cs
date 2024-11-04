using System;
using Pod;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pod.Models
{
    [Serializable]
    public class Feed
    {

        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Category { get; set; }
        public List<Episode> Episodes { get; set; }


        public Feed() { }
        public Feed(string name, string officialName, string category, List<Episode> episodes)
        {
            Name = name;
            OfficialName = officialName;
            Category = category;
            Episodes = episodes;
            
        }
    }

}




