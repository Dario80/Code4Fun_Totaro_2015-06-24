using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListUtilities
{
    public interface ILinkedListOperations<T>
    {
        T GetNthElementFromLast(SinglyLinkedList<T> singlyLinkedList, int index);
    }

    /// <summary>
    /// Generic ListNode class - avoiding boxing unboxing here by using generic implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
        private ListNode<T> next;
        private T item;
        /// <summary>
        /// Property to hold pointer to next ListNode - Self containing object
        /// </summary>

        public ListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Property to hold value into the Node
        /// </summary>

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        /// Constructor with item init
        /// </summary>
        /// <param name="item"></param>

        public ListNode(T item)
            : this(item, null)
        {
        }

        /// <summary>
        /// Constructor with item and the next node specified
        /// </summary>
        /// <param name="item"></param>
        /// <param name="next"></param>

        public ListNode(T item, ListNode<T> next)
        {
            this.item = item;
            this.next = next;
        }

        /// <summary>
        /// Overriding ToString to return a string value for the item in the node
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            if (item == null)
                return string.Empty;
            return item.ToString();
        }
    }

    /// <summary>
    /// SinglyLinkedList class for generic implementation of LinkedList. 
    /// Again, avoiding boxing unboxing here and using ICollection interface members. 
    /// Believe this can be useful when applying other 
    /// operations such as sorting, searching etc. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region private variables
        private ListNode<T> firstNode;
        private ListNode<T> lastNode;
        private int count;
        #endregion

        /// <summary>
        /// Property to hold first node in the list
        /// </summary>

        public ListNode<T> FirstNode
        {
            get { return firstNode; }
        }

        /// <summary>
        /// Property to hold last node in the list
        /// </summary>

        public ListNode<T> LastNode
        {
            get { return lastNode; }
        }

        /// <summary>
        /// Indexer to iterate through the list and fetch the item
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException();
                ListNode<T> currentNode = firstNode;
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.Next == null)
                        throw new ArgumentOutOfRangeException();
                    currentNode = currentNode.Next;
                }
                return currentNode.Item;
            }
        }

        /// <summary>
        /// Property to hold count of items in the list
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Property to determine if the list is empty or contains any item
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return firstNode == null;
                }
            }
        }

        /// <summary>
        /// Constructor initializing list with a provided list name
        /// </summary>
        /// <param name="strListName"></param>
        public SinglyLinkedList()
        {
            count = 0;
            firstNode = lastNode = null;
        }

        /// <summary>
        /// Operation inserts item at the front of the list
        /// </summary>
        /// <param name="item"></param>

        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    firstNode = new ListNode<T>(item, firstNode);
                count++;
            }
        }

        /// <summary>
        /// Operation inserts item at the back of the list
        /// </summary>
        /// <param name="item"></param>

        public void InsertAtBack(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    lastNode = lastNode.Next = new ListNode<T>(item);
                count++;
            }
        }

        /// <summary>
        /// Operation removes item from the front of the list
        /// </summary>
        /// <returns></returns>

        public object RemoveFromFront()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = firstNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                    firstNode = firstNode.Next;
                count--;
                return removedData;
            }
        }

        /// <summary>
        /// Operation removes item from the back of the list
        /// </summary>
        /// <returns></returns>

        public object RemoveFromBack()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = lastNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                {
                    ListNode<T> currentNode = firstNode;
                    while (currentNode.Next != lastNode)
                        currentNode = currentNode.Next;
                    lastNode = currentNode;
                    currentNode.Next = null;
                }
                count--;
                return removedData;
            }
        }



        /// <summary>
        /// Removes the input item if exists and returns true else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Remove(T item)
        {
            if (firstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            else if (lastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            else
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Item.ToString().Equals(item.ToString()))
                    {
                        currentNode.Next = currentNode.Next.Next;
                        count--;
                        if (currentNode.Next == null)
                            lastNode = currentNode;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if list contains the input item else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Contains(T item)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Item.ToString().Equals(item.ToString()))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        /// <summary>
        /// Operation resets the list and clears all its contents
        /// </summary>

        public void Clear()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        #region ICollection<T> Members

        /// <summary>
        /// Add to the back of the list. Acts as an append operation
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            InsertAtBack(item);
        }

        /// <summary>
        /// Interface member not implemented as of now
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Irrelevant for now
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Custom GetEnumerator method to traverse through the list and yield the current value
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    public class LinkedListOperations<T> : ILinkedListOperations<T>
    {
        public SinglyLinkedList<T> _sLinkedList { get; set; }

        

        public T GetNthElementFromLast(SinglyLinkedList<T> singlyLinkedList, int index)
        {
            return default(T);
        }
    }
}
