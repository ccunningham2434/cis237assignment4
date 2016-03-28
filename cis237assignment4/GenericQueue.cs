using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericQueue<T>
    {
        protected GenericNode<T> _head;// >The node at the begining of the list.
        protected GenericNode<T> _tail;// >The node at the end of the list.

        protected int _count;// >The number of nodes in the list.


        // >Properties
        //
        public int Count
        {
            get { return _count;}
        }


        //Constructors
        //
        public GenericQueue()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }


        // >Enqueue a new node containing the passed in data to the end of the queue.
        public void Enqueue(T passedData)
        {
            // >Make a new node.
            GenericNode<T> newNode = new GenericNode<T>();

            // >Set the new node's data the data that was passed in.
            newNode.Data = passedData;

            // >If the head is null it means that the list is empty and...
            // >...we are adding the first item.
            if (_head == null)
            {
                // >Make the head the same as the new node.
                _head = newNode;
            }
            else
            {
                // >The tail's next is null, by making it the same as the new node, we...
                // >...are 'adding' a node to the end of the list.
                _tail.Next = newNode;
            }
            // >Make the tail reference the same as the new node, so once again it is...
            // >...the last in the list.
            _tail = newNode;

            // >Increase the nodeCounter.
            _count++;
        }


        // >Take the item at the front of the queue.
        public T Dequeue()
        {
            // Make a return newNode and set it to the Head, which is the first newNode in the
            // linked list.
            GenericNode<T> returnNode = _head;
            // Move the head to the Next newNode in the linked list.
            _head = _head.Next;
            // Check to see if Head is null, if so, set Tail to null as well. List is empty.
            if (_head == null)
            {
                _tail = null;
            }
            // >Decrease the list's node count.
            _count--;

            // return the data.
            return returnNode.Data;
        }
    }
}
