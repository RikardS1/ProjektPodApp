using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Repository<T> : IRepository<T> where T :class
    {
        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
