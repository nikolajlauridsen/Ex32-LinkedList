using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adt
{
    class Node
    {
        public Node Next;
        public object Data;

        public Node(object data)
        {
            Data = data;
        }
    }
}
