using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Helpers
{
    public interface IObservableDictionary<T, U>
    {
        event Action<T> AnyValueChanged;

        bool UpdateItem(T item);
    }

    public class ObservableDictionary<T, U> : IObservableDictionary<T, U>
    {
        private readonly IDictionary<T, U> _dict;
        public event Action<T> AnyValueChanged = delegate { };

        public ObservableDictionary(IDictionary<T, U> initDict = null)
        {
            _dict = initDict ?? new Dictionary<T, U>();
        }
        
        public bool UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}