using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IRepository<T>
    {
        List<T> HamtaAlla();
        void LaggTill(T nyObjekt);
        void Andra(T gammaltObjekt, T nyttObjekt);
        void TaBort(T objekt);
    }
}
