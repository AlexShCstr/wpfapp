using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp.repository
{
    interface IRepository<T> where T : domain.IdentObject
    {
        T FindById(long id);
        ReadOnlyObservableCollection<T> All();
        T Insert(T value);
        void Delete(T value);

    }
}
