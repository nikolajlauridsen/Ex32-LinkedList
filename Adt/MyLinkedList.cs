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
        private Node Tail = null;
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
                Tail = newNode;
                Count += 1;
                return;
            }

            // Set new node to be next
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
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
            if(index > 0 && index < Count) {
                Node oldNode, preNode, newNode;
                newNode = new Node(data);

                oldNode = NodeAt(index);
                preNode = NodeAt(index - 1);

                preNode.Next = newNode;
                newNode.Prev = preNode;

                newNode.Next = oldNode;
                oldNode.Prev = newNode;

                Count++;
            } else if (index == 0) {
                Insert(data);
            } else if (index >= Count) {
                Append(data);
            }
        }

        public void Delete()
        {
            Head = Head.Next;
            Head.Prev = null;
            Count--;
        }

        public void Delete(int index)
        {
            if(index != 0 && index < Count-1) {
                Node preNode, postNode;
                preNode = NodeAt(index-1);
                postNode = NodeAt(index + 1);
                preNode.Next = postNode;
                postNode.Prev = preNode;
                Count--;
            } else if (index <= 0) {
                Delete();
            } else if (index >= Count-1) {
                Tail = Tail.Prev;
                Tail.Next = null;
                Count--;
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

        public void Reverse()
        {
            Node place = Head;
            Node oldNext, oldHead;
            while(place != null) {
                oldNext = place.Next;
                place.Next = place.Prev;
                place.Prev = oldNext;
                place = oldNext;
            }
            oldHead = Head;
            Head = Tail;
            Tail = oldHead;
        }

        public void Swap(int i)
        {
            Node targetNode, postNode, oldNext, oldPrev, preNode;

            targetNode = NodeAt(i);
            postNode = NodeAt(i + 1);
            preNode = NodeAt(i - 1);

            oldNext = postNode.Next;
            oldPrev = targetNode.Prev;

            targetNode.Next = oldNext;
            targetNode.Prev = postNode;

            postNode.Next = targetNode;
            postNode.Prev = oldPrev;

            preNode.Next = postNode;

        }

        public String FremTilbage()
        {
            MyLinkedList fremTilbage = new MyLinkedList();

            for (int i = 0; i < Count; i++) {
                fremTilbage.Insert(ItemAt(i));
            }

            for (int i = Count-2; i >= 0; i--) {
                fremTilbage.Insert(ItemAt(i));
            }

            return fremTilbage.ToString();
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