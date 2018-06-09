using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class LinkedList
    {
        // This Linked list need the first element as reference
        private Element first;
        // The Analizer needs the last element of the list for a few operations
        private Element last;

        // This public function add a element in this list.
        public void Add (Element element)
        {
            // If we dont have elements in the list...
            if (first == null)
            {
                // then the new element is the first of the list.
                first = element;
                // and is the last element of this list.
                last = element;
            }
            else // We add the element in the end of the list
            {
                Add(first, element);
                last = element; // and now the element is the last of the list.
            }
        }

        // This recursive function add the element in the end of the list.
        private void Add (Element aux, Element element)
        {
            // If the next element of this element is null...
            if (aux.Next == null)
            {
                aux.Next = element; // The next element will be the new element.
                aux.Next.Previous = aux; // Notice that now the aux.Next isn't null, so the previous will be the current element. 
            }
            else
            {
                // If aux.Next != null means that we are not in the end of the list.
                Add(aux.Next, element); // We send the next element of this list and the element that we want to add in the end.
            }
        }

        public string ToList()
        {
            // If we don't have first element that means that we are not adding elements.
            if (first == null)
            {
                // We return a string which says...
                return "The list has no elements.";
            }

            // But, if we have element(s) then return the result of our recursive function...
            return ToList(first, "");
        }

        // This recursive function concatenates every toString of our elements in the list.
        private string ToList(Element aux, string str)
        {
            // If this element isn't null means that we can get his toString...
            if (aux != null)
            {
                // The function concatenates the toString with 'str' parameter.
                str += aux.ToString() + Environment.NewLine;
            }
            else // If aux == null means that we need to return the concatenated string.
            {
                return str;
            }

            // We send the parameters to get every toString in the list and the concatenated string with the result to concatenate the next element of the list.
            return ToList(aux.Next, str);
        }

        public Element FirstElement { get => first; set => first = value; }
        public Element LastElement { get => last; set => first = value; }
    }
}
