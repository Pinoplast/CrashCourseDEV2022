using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IService<T>
    {
        void Add(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void SaveChanges();
    }
}
