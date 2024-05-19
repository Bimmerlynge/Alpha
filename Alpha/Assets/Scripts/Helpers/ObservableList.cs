using System;
using System.Collections;
using System.Collections.Generic;

namespace Helpers
{
    public interface IItemNotifier<T>
    {
        event Action<T> ItemChanged;
    }

    public interface IObservableList<T>
    {
        event Action<IList<T>> ListChanged;
        int Count { get; }
        void Clear();
        void Add(T item);
        void Remove(T item);
    }

    public class ObservableList<T> : IObservableList<T>
    {
        private readonly IList<T> _list;
        public event Action<IList<T>> ListChanged = delegate { };

        public ObservableList(IList<T> initList = null)
        {
            _list = initList ?? new List<T>();
        }
        
        public T this[int index]
        {
            get => _list[index];
            set
            {
                _list[index] = value;
                Invoke();
            }
        }

        public int Count { get; }
        public bool IsReadOnly { get; }

        public void Invoke() => ListChanged.Invoke(_list);
        
        public void Add(T item)
        {
            _list.Add(item);
            Invoke();
        }
        
        public void Remove(T item)
        {
            var result = _list.Remove(item);
            if (result)
            {
                Invoke();
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
        
    }
}