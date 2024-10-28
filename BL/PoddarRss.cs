using System;
using ProjecktPodApp.DL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPodApp.BL
    {
        public class PoddarManager //Fungerar som mellanhand mellan DAL och gränssnitt
        {
            private PodDataAccess PodDataAccess; //fält av typen KategoriDataAccess (DAL-lagret)

            public PoddarManager() //konstruktor som skapar en ny instans av KategoriDataAccess-klassen
            {
            PodDataAccess = new PodDataAccess();
            }

        public List<string> HamtaPoddar() //metodanrop från DAL
        {
            return PodDataAccess.HamtaPoddar();
        }


        public void LaggTillKategori(string nyPoddar)
            {
            PodDataAccess.LaggTillPoddar(nyPoddar); //metod som lägger till nyKategori i Datalagret
            }

            public void AndraPoddar(string gammalPoddar, string nyPoddar)
            {

            PodDataAccess.AndraPoddar(gammalPoddar, nyPoddar);

            }

            public void TaBortPoddar(string gammalPoddar)
            {
            PodDataAccess.TaBortPoddar(gammalPoddar);
        }

        }




    }

