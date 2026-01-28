using System.Collections.Generic;

namespace StrukturaStos {
    public class Stos<T> : IStos<T> {
        private List<T> _items;
    
        public T Peek => IsEmpty ? throw new StosEmptyException() : _items[_items.Count - 1];
        public int Count => _items.Count;
        public bool IsEmpty => Count == 0;

        public Stos() {
            _items = new List<T>();
        }
    
        public void Push(T value) {
            _items.Add(value);
        }
    
        public T Pop() {
            if (IsEmpty) throw new StosEmptyException();
            T item = _items[_items.Count - 1];
            _items.Remove(item);
            return item;
        }
    
        public void Clear() {
            _items.Clear();
        }

        public T[] ToArray() {
            return _items.ToArray();
        }
    }
}