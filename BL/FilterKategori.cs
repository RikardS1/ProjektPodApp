using System;
using ProjecktPodApp.DL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ProjektPodApp.BL
{
    public class KategoriManager 
    {
        private KategoriDataAccess kategoriDataAccess; //fält av typen KategoriDataAccess 

        public KategoriManager() 
        {
            kategoriDataAccess = new KategoriDataAccess();
        }

        public List<string> HamtaKategorier() //metodanrop 
        {
            return kategoriDataAccess.HamtaAlla();
        }

        public void LaggTillKategori(string nyKategori)
        {
            kategoriDataAccess.LaggTill(nyKategori); 
        }

        public void AndraKategori(string gammalKategori, string nyKategori)
        {

            kategoriDataAccess.Andra(gammalKategori, nyKategori);

        }

        public void TaBortKategori(string gammalKategori)
        {
            kategoriDataAccess.TaBort(gammalKategori);
        }

    }


}
