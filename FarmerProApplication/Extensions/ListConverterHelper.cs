using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FarmerProApplication.Extensions
{
    public static class ListConverterHelper
    {
        public static ObservableCollection<T> ToObservable<T>(this IList<T> list)
        {
            var observableCollection = new ObservableCollection<T>();
            foreach (var item in list)
            {
                observableCollection.Add(item);
            }
            return observableCollection;
        }
    }
}
