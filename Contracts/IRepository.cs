using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        ICollection<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        void Delete(T t);
    }
}
