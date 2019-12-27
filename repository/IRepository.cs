using System.Collections.ObjectModel;
using System.Data;

namespace WpfApp.repository
{
    interface IRepository<T> where T : class
    {
        T Insert(T value);
        T Update(T value);
        void Delete(T value);
        void Clear();

    }
}
