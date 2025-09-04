using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListHadasim
{
    /// <summary>
    /// Represents a singly linked list with utility methods.
    /// </summary>
    internal class LinkedList
    {
        private Node head;
        private Node tail;
        private Node max;
        private Node min;

        public LinkedList(Node head,Node tail)
        {
            this.head = head;
            this.tail = tail;
            this.max = this.FindMax();
            this.min = this.FindMin();
        }
        /// <summary>
        /// Finds the node with the maximum value.
        /// </summary>
        /// <returns>The node with the maximum value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        private Node FindMax()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            Node maxNode = head;
            Node current = head;
            while (current != null)
            {
                if (current.Value > maxNode.Value)
                    maxNode = current;
                current = current.Next; 
            }
            return maxNode;
        }
        /// <summary>
        /// Finds the node with the minimum value.
        /// </summary>
        /// <returns>The node with the minimum value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        private Node FindMin()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            Node minNode = head;
            Node current = head;
            while (current != null)
            {
                if (current.Value < minNode.Value)
                    minNode = current;

                current = current.Next; 
            }
            return minNode;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedList"/> class.
        /// </summary>
        public LinkedList()
        {
            this.head=null;
            this.tail=null;
            this.max=null;
            this.min=null;
        }
        /// <summary>
        /// Adds a new node at the beginning of the list.
        /// </summary>
        /// <param name="value">The value of the new node.</param>
        public void Prepend(int value)
        {
            if (head == null) 
            {
                Node node = new Node(value, null);
                head = tail = max = min = node;
                return;
            }
            Node newNode=new Node(value,head);
            head=newNode;
            if (value>max.Value)
                max=head;
            if (value<min.Value) 
                min=newNode;
        }
        /// <summary>
        /// Removes the last node in the list and returns its value.
        /// </summary>
        /// <returns>The value of the removed node.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public int Pop()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            if (head == tail)
            {
                int val = head.Value;
                head = tail = null;
                return val;
            }

            bool maxFlag =false, minFlag=false;
            if (max==tail)
                maxFlag=true;
            if (min==tail)
                minFlag=true;
            Node beforeTail = head;
            while (beforeTail.Next.Next!=null)
            {
                beforeTail = beforeTail.Next;
            }
            int lastValue = beforeTail.Next.Value;
            beforeTail.Next=null;
            tail=beforeTail;
            if (maxFlag)
                max=FindMax();
            if (minFlag)
                min=FindMin();
            return lastValue;
        }
        /// <summary>
        /// Adds a new node at the end of the list.
        /// </summary>
        /// <param name="value">The value of the new node.</param>
        public void Append(int value)
        {
            if (head == null)
            {
                Node newNode = new Node(value, null);
                head = tail = max = min = newNode;
                return;
            }
            Node LastNode=new Node(value, null);
            tail.Next=LastNode;
            tail=LastNode;
            if (value<min.Value)
                min=LastNode;
            if(value>max.Value)
                max = LastNode;
        }
        /// <summary>
        /// Removes the first node in the list and returns its value.
        /// </summary>
        /// <returns>The value of the removed node.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public int Unqueue()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            Node oldHead=head;
            head=head.Next;
            if (max==oldHead)
                max=FindMax();
            if (min==oldHead)
                min=FindMin();
            return oldHead.Value;
        }
        /// <summary>
        /// Converts the list into an enumerable of integers.
        /// </summary>
        /// <returns>An enumerable containing the values of the nodes in the list.</returns>
        public IEnumerable<int> ToList()
        {
            Node node = head;
            while(node!=null)
            {
                yield return node.Value;    
                node = node.Next;
            }
        }
        /// <summary>
        /// Determines whether the list contains a cycle.
        /// </summary>
        /// <returns><c>true</c> if the list is circular; otherwise, <c>false</c>.</returns>
        public bool IsCircular()
        {
            if (head == null)
                return false;
            Node fast=head;
            Node slow=head;
            while(fast != null && fast.Next != null)
            {
                fast=fast.Next.Next;
                slow=slow.Next;
                if (fast==slow)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Sorts the linked list in ascending order.
        /// </summary>
        public void Sort()
        {
            if (head == null) 
                return;
            Node newHead=this.SortHelper(this.head);
            this.head=newHead;
            Node newTail = head;
            while (newTail.Next!=null)
            {
                newTail = newTail.Next;
            }
            this.tail=newTail;
        }
        /// <summary>
        /// Helper method that recursively sorts a list using merge sort.
        /// </summary>
        /// <param name="head">The head of the sublist to sort.</param>
        /// <returns>The head of the sorted sublist.</returns>
        private Node SortHelper(Node head)
        {
            if (head == null || head.Next == null)
                return head;
            Node slow = head;
            Node fast = head.Next; 
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            Node rightHead = slow.Next;
            slow.Next = null; 
            Node left = SortHelper(head);
            Node right = SortHelper(rightHead);
            return Merge(left, right);
        }

        /// <summary>
        /// Merges two sorted linked lists into one sorted list.
        /// </summary>
        /// <param name="left">The head of the left sublist.</param>
        /// <param name="right">The head of the right sublist.</param>
        /// <returns>The head of the merged sorted list.</returns>
        private Node Merge(Node left, Node right)
        {
            Node dummy = new Node(0, null);
            Node curr = dummy;
            while (left!=null&&right!=null)
            {
                if (left.Value<=right.Value)
                {
                    curr.Next=left;
                    left=left.Next;
                }
                else
                {
                    curr.Next=right;
                    right=right.Next;
                }
                curr=curr.Next;
            }
            if (left!=null)
            {
                curr.Next=left;
            }
            if (right!=null)
            {
                curr.Next=right;
            }
            return dummy.Next;
        }
        /// <summary>
        /// Gets the node that currently holds the maximum value (tracked).
        /// </summary>
        /// <returns>The node with the maximum value.</returns>
        public Node GetMaxNode() { return max; }

        /// <summary>
        /// Gets the node that currently holds the minimum value (tracked).
        /// </summary>
        /// <returns>The node with the minimum value.</returns>
        public Node GetMinNode() { return min; } 

    }
}
