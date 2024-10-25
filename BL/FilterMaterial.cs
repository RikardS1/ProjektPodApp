using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FilterMaterial
    {
        private int minutes;
        public void UpdateFreq(int interval)
        {
            bool again = true;
            while(again)
            {
                again = false;
                switch (interval)
                {
                    case 1:
                        minutes = 1;
                        break;
                    case 5:
                        minutes = 5;
                        break;
                    case 10:
                        minutes = 10;
                        break;
                    case 15:
                        minutes = 15;
                        break;
                    case 60:
                        minutes = 60;
                        break;
                    default:
                        //throw new IndexOutOfRangeException(); //Throw ex?
                        again = true;
                        break;

                }
               
            }
        }
    }
}
