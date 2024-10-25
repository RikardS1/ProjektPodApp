using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IRepository<T> where T :class
    {
        T GetById(int id);
        void Create(T entity);
        void Update(int index, T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
