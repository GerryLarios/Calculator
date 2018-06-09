using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Element
    {
        // Value could be a number (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) or an elementary operation (+, -, *, /) 
        private string _value;
        // The level is a significant number to distinguish the kind of element and his position in the general tree. NOTE: Its not the height or the node level.
        private int level;
        // Every element is a node and has sons.
        private Element left;
        private Element rigth;
        // In the same way, every element is a node in the Linked List
        private Element next;
        private Element previous;

        // To create a 'element' only need to put a 'value' what is a number o a elementary operation
        public Element(string value)
        {
            this._value = value;
        }

        // toString will show the element and the level it receives. Only for didactics situations
        public override string ToString()
        {
            return "[" + level.ToString() + "]" + "\tValue: " + Value;
        }

        public string Value { get => _value; }
        public int Level { get => level; set => level = value; }
        public Element Left { get => left; set => left = value; }
        public Element Rigth { get => rigth; set => rigth = value; }
        public Element Next { get => next; set => next = value; }
        public Element Previous { get => previous; set => previous = value; }
    }
}
