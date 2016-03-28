using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericStack<T>
    {
         protected GenericNode<T> _head;// >The node at the begining of the list.
        protected GenericNode<T> _tail;// >The node at the end of the list.

        protected int _count;// >The number of nodes in the list.


        public GenericNode<T> Head
        {
            get { return _head; }
        }
        public GenericNode<T> Tail
        {
            get { return _tail; }
        }
        public int Count
        {
            get { return _count;}
        }

        //Constructor. Just initalize the properties to null
        public GenericStack()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        
        // >Push something onto the stack.
        public void Push(T content)
        {
            // Just make another pointer that points to the first newNode in the linked list.
            GenericNode<T> oldFirst = _head;
            // Overwrite head with a new Generic Node.
            _head = new GenericNode<T>();
            // Set the data on the newNode.
            _head.Data = content;
            // Make Head's Next point to the old First.
            _head.Next = oldFirst;

            // >Increase the list's node count.
            _count++;
        }

        // >Pop something off of the stack.
        public T Pop()
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
