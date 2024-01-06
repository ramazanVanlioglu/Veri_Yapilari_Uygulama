using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariUygulama
{
    internal class Node
    {
        public Node next;
        public Node prev;
        public Ogrenci ogrenci;
        public Node(Ogrenci ogrenci)
        {
            this.ogrenci = ogrenci;
            this.next = null;
            this.prev = null;
        }
    }
}
