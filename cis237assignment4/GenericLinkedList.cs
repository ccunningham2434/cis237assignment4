using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericLinkedList<T>
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
        public GenericLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }


        // >Enqueue a new node containing the passed in data to the list.
        public void Add(T passedData)
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

        // >RemoveAt a node at the input i.
        public void RemoveAt(int position)
        {
            // >If the i is 0 we need to remove the node that the head points to.
            if (position == 0)
            {
                // >Make the head reference the same as it's next property.
                // >This will leave the node that head used to point to...
                // >...without anything pointing to it.
                _head = _head.Next;

                // >If the head is null it means that there was only one item in the list.
                // >The list is now empty so the tail is null.
                if (_head == null)
                {
                    _tail = null;
                }
            }
            else// >If the i is not zero.
            {
                GenericNode<T> currentNode = _head;// >The node reference that we are currently on. Start at the first node in the list(head).
                GenericNode<T> lagNode = null;// >Follows one node 'behind' the current node.

                int nodeCounter = 0;// >Counter to tell what node we are on in the list.

                // >Loop until the current node is null, which means we are at the end.
                while (currentNode != null)
                {
                    // >If the counter matches the input i, then we have found the node to delete.
                    if (nodeCounter == position)
                    {
                        // >Set the lagging node's next to the current node's next, effectivly 'skipping' the current node.
                        // >This will leave the current node without anything pointing to it, so the garbage collector...
                        // >...will take care of it.
                        lagNode.Next = currentNode.Next;

                        // >Check if the node we are deleteing is the last in the list.
                        if (currentNode.Next == null)
                        {
                            // >Set tail to the lagNode, which is the new end of the list.
                            _tail = lagNode;
                        }

                        // >Decrease the list's node count.
                        _count--;
                    }
                    // >Move the lagging node 'forward' in the list by making it the same as the current node.
                    lagNode = currentNode;
                    // >>Move the current node 'forward' in the list by making it the same as it's next property.
                    currentNode = currentNode.Next;

                    // >Increase the node counter.
                    nodeCounter++;
                }
            }
        }










        public T Retrieve(int position)
        {
            // Used as a temporary pointer to a spot within the linked list.
            GenericNode<T> tempNode = _head;
            // Used to hold the newNode at the index indicated by the passd in i.
            GenericNode<T> returnNode = null;
            // Counter to see where we are in the list.
            int count = 0;

            // While our currentNode is not at the end of the list.
            while (tempNode != null)
            {
                // If the nodeCounter and the i match. This means that it wil be
                // zero based. If we wanted it to be 1 based, we would neet to subtract
                // 1 from the i.
                if (count == position)
                {
                    // Set the returnNode var to the currentNode, which is the on we are looking for.
                    returnNode = tempNode;
                }
                // Increment the nodeCounter so that we actually move through the list.
                count++;
                // Set the currentNode to currentNode's next property, which will move us to the next
                // newNode in the linked list.
                tempNode = tempNode.Next;
            }
            // We are going to use a ternary operater to do a small version of an if.
            // This could easily be written as an if/else. Essentially the part in the ()
            // is the test, and the part between the ? and the : is what will happen if true.
            // The part after the : is what will happen when false.
            // The default(T) part is going to determine what the default value for 
            // type T is, and then return that. Most of the time it will probably
            // be null, but in case it isn't this will handle it. Putting just null
            // makes the IDE complain, so we have to use this.
            return (returnNode != null) ? returnNode.Data : default(T);
        }

        

        public void AddToFront(T content)
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

        public T RemoveFromFront()
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
