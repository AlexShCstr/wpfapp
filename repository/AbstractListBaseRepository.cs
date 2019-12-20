using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp.repository
{
    abstract class AbstractListBaseRepository<T> : IRepository<T> where T : domain.IdentObject
    {
        private long idGen = 0;
        private readonly ObservableCollection<T> backList;
        private readonly ReadOnlyObservableCollection<T> readOnlyCollection;

        protected AbstractListBaseRepository()
        {
            backList = new ObservableCollection<T>();
            readOnlyCollection = new ReadOnlyObservableCollection<T>(backList);
        }               

        public ReadOnlyObservableCollection<T> All()
        {
            return readOnlyCollection;
        }
        public void Delete(T value)
        {
            backList.Remove(value);
        }
        public T FindById(long id)
        {
            return backList.ToList().Find(obj => obj.Id == id);
        }

        public T Insert(T value)
        {
            var obj = FindById(value.Id);
            if (obj == null)
            {
                if (value.Id == 0) value.Id = ++idGen;
                backList.Add(value);
            }
            return obj == null ? value : obj;
        }
    }
}
