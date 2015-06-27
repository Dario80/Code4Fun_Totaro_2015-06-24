using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListUtilities
{
    /// <summary>
    /// Linked list operations interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILinkedListOperations<T>
    {
        T GetNthElementFromLast(SinglyLinkedList<T> singlyLinkedList, int index);
    }

    /// <summary>
    /// Generic ListNode class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
        private ListNode<T> next;
        private T item;
        /// <summary>
        /// Property to hold pointer to next ListNode
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
    }

    /// <summary>
    /// SinglyLinkedList class for generic implementation of LinkedList. 
    /// Using ICollection interface members.  
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
                    return default(T);
                ListNode<T> currentNode = firstNode;
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.Next == null)
                        return default(T);
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
        /// Removes the input item if exists and returns true else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if list contains the input item else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Operation resets the list and clears all its contents
        /// </summary>

        public void Clear()
        {
            throw new NotImplementedException();
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
        /// Not implemented for the exercise
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    

    /// <summary>
    /// Method to retrieve Nth element from slngly linked list from last
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListOperations<T> : ILinkedListOperations<T>
    {
        public T GetNthElementFromLast(SinglyLinkedList<T> singlyLinkedList, int index)
        {
            if (singlyLinkedList != null && !singlyLinkedList.IsEmpty && singlyLinkedList.Count >= index )
            {
                return singlyLinkedList[singlyLinkedList.Count - index];
            }
            return default(T);
        }
    }
}
