﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Repository<T> : IRepository<T> where T : DataLayer<T>
    {
       public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity) 
        { 
            throw new NotImplementedException(); 
        }

    }
}
