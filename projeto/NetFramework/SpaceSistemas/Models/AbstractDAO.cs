using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSistemas.Database;

namespace SpaceSistemas.Models
{
    /// <summary>
    ///     Abstract Class para classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class AbstractDAO<T>
    {
        protected Conexao conn = new Conexao();

        public virtual void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> List()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
