using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BusinessLayer<T> : IRepository
    {
        public int ID { get; set; }

        public void GetPodcasts()
        {
            //kanske ska returna en list ist för inget

        }
    }
}
