﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adt
{
    public class MyLinkedList
    {
        private Node Head = null;
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Count = 0;
        }

        public void Append(Object data)
        {
            // Create the new node
            Node newNode = new Node(data);

            // Is it the first element)?
            if(Head == null) {
                Head = newNode;
                Count += 1;
                return;
            }

            // Find the end of the list
            Node last = FindLast();

            last.Next = newNode;
            Count++;
        }

        public void Insert(Object data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        public void Insert(Object data, int index)
        {
            if(index != 0) {
                Node prevNode, targetPointer, newNode;
                newNode = new Node(data);
                prevNode = NodeAt(index);
                targetPointer = NodeAt(index - 1);
                newNode.Next = prevNode;
                targetPointer.Next = newNode;
                Count++;
            } else {
                Insert(data);
            }
        }

        public void Delete()
        {
            Head = Head.Next;
            Count--;
        }

        public void Delete(int index)
        {
            if(index != 0) {
                Node preNode, postNode;
                preNode = NodeAt(index-1);
                postNode = NodeAt(index + 1);
                preNode.Next = postNode;
                Count--;
            } else {
                Delete();
            }
        }

        public Object ItemAt(int index)
        {
            Node target = NodeAt(index);
            return target.Data;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Node place = Head;
            while (place != null) {
                builder.Append(place.Data.ToString());
                builder.Append("\n");
                place = place.Next;
            }
            return builder.ToString();
        }

        private Node FindLast()
        {
            if (Head == null) {
                return null;
            }
            bool searching = true;
            Node place = Head;
            while (searching) {
                if (place.Next == null) {
                    searching = false;
                } else {
                    place = place.Next;
                }
            }
            return place;
        }

        private Node NodeAt(int targetIndex)
        {

            int index = 0;
            Node place = Head;
            while (index < targetIndex) {
                place = place.Next;
                index++;
            }
            return place;
        }
    }
}