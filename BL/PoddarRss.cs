using System;
using ProjecktPodApp.DL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Pod.Models;

namespace ProjektPodApp.BL
{
    public class PoddarManager //Fungerar som mellanhand mellan DAL och gränssnitt
    {
           
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

