using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepository<T> where T : BusinessLayer
    {
        T GetById(int id);
        void Create(T  entity);
        void Update(T  entity);
        void Delete(T  entity);
    }
}
