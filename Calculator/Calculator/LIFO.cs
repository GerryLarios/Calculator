using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class LIFO
    {
        Element top;

        public void Push(Element element)
        {
            if (top == null)
            {
                top = element;
            }
            else
            {
                Element aux = top;
                top = element;
                top.Next = aux;
            }
        }

        public Element Pop()
        {
            Element aux = top;
            top = top.Next;
            return aux;
        }

        public Element Peek()
        {
            return top;
        }
    }
}
