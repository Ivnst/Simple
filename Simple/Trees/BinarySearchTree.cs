using System;
using System.Collections.Generic;

namespace Simple.Trees
{
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        #region <Fields>

        private BinarySearchTreeItem topItem;

        #endregion

        #region <Properties>

        public BinarySearchTreeItem TopItem { get { return topItem; } }

        #endregion

        #region <Methods>

        /// <summary>
        /// Add new key value item
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(TKey key, TValue value)
        {
            var item = new BinarySearchTreeItem(key, value);

            if (topItem == null)
            {
                topItem = item;
            }
            else
            {
                topItem.AddSubItem(item);
            }
        }

        /// <summary>
        /// Returns the value of the record with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Find(TKey key)
        {
            var item = FindItem(topItem, key);
            if(item == null) throw new KeyNotFoundException();
            return item.Value;
        }

        /// <summary>
        /// Returns the instance of BinarySearchTreeItem with record with specified key
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private BinarySearchTreeItem FindItem(BinarySearchTreeItem item, TKey key)
        {
            if (item == null) return null;

            if (item.Key.CompareTo(key) == 0)
                return item;

            return FindItem(item.Key.CompareTo(key) > 0 ? item.Left : item.Right, key);
        }


        /// <summary>
        /// Checks whether a record with specified key exists in the Tree
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return FindItem(topItem, key) != null;
        }

        /// <summary>
        /// Removes a record with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Remove(TKey key)
        {
            var item = FindItem(topItem, key);
            if (item == null) throw new KeyNotFoundException();
            Remove(item);
        }

        private void Remove(BinarySearchTreeItem item)
        {
            //0 subitems
            if (item.HasNoSubItems())
            {
                if (item.Parent == null)
                {
                    topItem = null;
                    return;
                }
                item.Parent.RemoveSubItem(item);
                return;
            }

            //1 subitem
            if (item.HasOneSubItem())
            {
                if (item.Left != null)
                {
                    if (item.Parent == null)
                    {
                        topItem = item.Left;
                        topItem.Parent = null;
                    }
                    else
                    {
                        item.Remove();
                    }
                }
                else
                {
                    if (item.Parent == null)
                    {
                        topItem = item.Right;
                        topItem.Parent = null;
                    }
                    else
                    {
                        item.Remove();
                    }
                }
                return;
            }

            //2 subitems
            if (item.HasBothSubItems())
            {
                var prevValueItem = item.Left.FindMaxItem();

                item.SwapKeyValueWith(prevValueItem);
                Remove(prevValueItem);
            }

        }

        #endregion

        #region <Binary Search Tree Item>

        public class BinarySearchTreeItem
        {
            #region <C-tors>

            internal BinarySearchTreeItem(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            #endregion

            #region <Properties>

            public TKey Key { get; private set; }
            public TValue Value { get; private set; }

            public BinarySearchTreeItem Left { get; internal set; }
            public BinarySearchTreeItem Right { get; internal set; }
            public BinarySearchTreeItem Parent { get; internal set; }

            #endregion

            #region <Methods>

            internal bool HasNoSubItems()
            {
                return Left == null && Right == null;
            }

            internal bool HasOneSubItem()
            {
                return !HasBothSubItems() && !HasNoSubItems();
            }

            internal bool HasBothSubItems()
            {
                return Left != null && Right != null;
            }

            internal BinarySearchTreeItem GetOneSubItem()
            {
                return Left ?? Right;
            }

            internal void AddSubItem(BinarySearchTreeItem item)
            {
                if(item == null) throw new ArgumentNullException();

                if (this.Key.CompareTo(item.Key) == 0)
                {
                    this.Value = item.Value;
                    return;
                }

                if (this.Key.CompareTo(item.Key) > 0)
                {
                    if (this.Left != null)
                    {
                        this.Left.AddSubItem(item);
                        return;
                    }
                    this.Left = item;
                    item.Parent = this;
                }
                else
                {
                    if (this.Right != null)
                    {
                        this.Right.AddSubItem(item);
                        return;
                    }
                    this.Right = item;
                    item.Parent = this;
                }
            }

            internal void RemoveSubItem(BinarySearchTreeItem subItem)
            {
                if (this.Left == subItem)
                {
                    this.Left = null;
                }

                if (this.Right == subItem)
                {
                    this.Right = null;
                }
            }

            internal BinarySearchTreeItem FindMaxItem()
            {
                return Right == null ? this : Right.FindMaxItem();
            }

            internal BinarySearchTreeItem FindMinItem()
            {
                return Left == null ? this : Left.FindMinItem();
            }

            internal void SwapKeyValueWith(BinarySearchTreeItem item)
            {
                var key = item.Key;
                item.Key = this.Key;
                this.Key = key;

                var value = item.Value;
                item.Value = this.Value;
                this.Value = value;
            }

            /// <summary>
            /// Only if has parent and one child
            /// </summary>
            internal void Remove()
            {
                if(this.Parent == null) throw new InvalidOperationException();
                if(!HasOneSubItem()) throw new InvalidOperationException();

                var subItem = GetOneSubItem();

                if (this.Parent.Left == this)
                {
                    this.Parent.Left = subItem;
                    subItem.Parent = this.Parent;
                }
                else
                {
                    this.Parent.Right = subItem;
                    subItem.Parent = this.Parent;
                }
            }

            #endregion

        }

        #endregion
    }
}
