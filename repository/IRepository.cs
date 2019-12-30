using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace WpfApp.repository
{
    interface IRepository<T> where T : class
    {
        T Insert(T value);
        T Update(T value);
        void Delete(T value);
        void Clear();

        Task<IEnumerable<T>> All();

    }
}
