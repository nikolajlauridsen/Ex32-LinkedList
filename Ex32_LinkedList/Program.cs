using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adt;

namespace Ex32_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();
            ClubMember nik = new ClubMember(0, "Nikolaj", "Lauridsen", 24);
            ClubMember mad = new ClubMember(1, "Mads", "Lauridsen", 30);
            list.Append(nik);
            list.Append(mad);
            list.Delete();
            Console.WriteLine(list.ToString());
        }
    }
}
