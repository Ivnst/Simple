using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Collections
{
    /// <summary>
    /// Пример связанного списка
    /// Example of a Linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable<T> where T: IEquatable<T>
    {
        #region <C-tor>

        public LinkedList()
        {
            
        }

        #endregion

        #region <Fields>

        private LinkedListItem<T> head = null;
        private LinkedListItem<T> tail = null; 

        #endregion

        #region <Properties>

        public int Count
        {
            get
            {
                var result = 0;
                foreach (var item in this)
                    result++;
                return result;
            }
        }

        public T this[int idx]
        {
            get
            {
                if(idx < 0) throw new IndexOutOfRangeException();
                var index = 0;
                foreach (var item in this)
                {
                    if (index == idx) return item;
                    index++;
                }

                throw new IndexOutOfRangeException();
            }
        }

        #endregion

        #region <Methods>

        public void AddFirst(T value)
        {
            if (head == null)
            {
                head = new LinkedListItem<T>(value);
                tail = head;
                return;
            }

            var newHead = new LinkedListItem<T>(value) { Next = head };
            head = newHead;
        }

        public void AddLast(T value)
        {
            if (tail == null)
            {
                tail = new LinkedListItem<T>(value);
                head = tail;
                return;
            }

            var newTail = new LinkedListItem<T>(value);
            tail.Next = newTail;
            tail = newTail;
        }

        public void Clear()
        {
            head = tail = null;
        }

        public bool Contains(T value)
        {
            foreach (var item in this)
            {
                if (item.Equals(value)) return true;
            }
            return false;
        }

        public int IndexOf(T value)
        {
            var idx = 0;
            foreach (var item in this)
            {
                if (item.Equals(value)) return idx;
                idx++;
            }
            return -1;
        }

        public T RemoveFirst()
        {
            if(head == null) throw new IndexOutOfRangeException();

            var val = head.Value;

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
            }
            return val;
        }

        public T RemoveLast()
        {
            if (tail == null) throw new IndexOutOfRangeException();

            if (head == tail)
            {
                var val = tail.Value;
                head = tail = null;
                return val;
            }
            else
            {
                var curr = head;
                var prev = head;

                while (curr != null)
                {
                    if (curr.Next == null)
                    {
                        tail = prev;
                        tail.Next = null;
                        return curr.Value;
                    }

                    prev = curr;
                    curr = curr.Next;
                }
            }

            throw new InvalidOperationException();
        }

        public T RemoveAt(int position)
        {
            if (position == 0)
                return RemoveFirst();

            var idx = 0;
            var curr = head;
            var prev = head;

            while (curr != null)
            {
                if (idx == position)
                {
                    prev.Next = curr.Next;
                    if (tail == curr)
                    {
                        tail = prev;
                    }
                    return curr.Value;
                }

                prev = curr;
                curr = curr.Next;
                idx++;
            }

            throw new IndexOutOfRangeException();
        }

        public void Remove(T value)
        {
            var curr = head;
            LinkedListItem<T> prev = null;

            while (curr != null)
            {
                if (curr.Value.Equals(value))
                {
                    if (prev == null)
                    {
                        head = curr.Next;
                        return;
                    }

                    prev.Next = curr.Next;

                    if (curr == tail)
                    {
                        tail = prev;
                    }

                    return;
                }

                prev = curr;
                curr = curr.Next;
            }

        }

        #endregion

        #region <inner item>

        public class LinkedListItem<T>
        {
            internal LinkedListItem(T item)
            {
                this.Value = item;
            }

            public T Value { get; set; }
            public LinkedListItem<T> Next { get; set; }
        }

        #endregion

        #region <IEnumerable>

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(head);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(head);
        }

        #endregion

        #region <IEnumerator>

        public class LinkedListEnumerator<T> : IEnumerator<T>
        {
            public LinkedListEnumerator(LinkedListItem<T> item)
            {
                this.first = item;
            }

            private LinkedListItem<T> first;
            private LinkedListItem<T> current;

            public T Current
            {
                get { return this.current.Value; }
            }

            public void Dispose()
            {
                this.first = this.current = null;
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.current.Value; }
            }

            public bool MoveNext()
            {
                if (first == null) return false;
                
                if (current == null)
                {
                    current = first;
                    return true;
                }

                if (current.Next == null) return false;
                this.current = this.current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = this.first;
            }
        }

        #endregion
    }
}
