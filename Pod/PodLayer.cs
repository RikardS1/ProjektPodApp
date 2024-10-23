using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pod
{
    public class PodLayer
    {
        //todo allt en podd ska innehålla ska vara här =)
        public short ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }


        public PodLayer()
        {
            //här var det tomt
        }

        public PodLayer(short iD, string title, string description, string category)
        {
            ID = iD;
            Title = title;
            Description = description;
            Category = category;

        }

    }
}
