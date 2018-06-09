using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Tree
    {
        Element root;
        string postOrder;
        string preOrder;
        public void Add(Element element)
        {
            if (root == null)
            {
                root = element;
            }
            else
            {
                Add(element, root);
            }
        }

        private void Add(Element element, Element r)
        {
            if (element.Level == 1)
            {
                if (r.Left == null)
                {
                    r.Left = element;
                }
                else
                {
                    Add(element, r.Left);
                }
            }
            else if (element.Level == 2)
            {
                if (r.Rigth == null)
                {
                    r.Rigth = element;
                }
                else
                {
                    Add(element, r.Left);
                }
            }
        }

        public string PreOrder()
        {
            if (root == null)
            {
                return "The tree has no elements";
            }

            if (String.IsNullOrEmpty(preOrder))
            {
                preOrder = PreOrder(root);
            }
            return preOrder;
        }

        private string PreOrder(Element aux)
        {
            string str = "";
            str += aux.Value;
            if (aux.Left != null)
            {
                str += PreOrder(aux.Left);
            }

            if (aux.Rigth != null)
            {
                str += PreOrder(aux.Rigth);
            }

            return str;
        }

        public string PostOrder()
        {
            if (root == null)
            {
                return "The tree has no elements";
            }

            if (String.IsNullOrEmpty(postOrder))
            {
                postOrder = PostOrder(root);
            }
            return postOrder;
        }


        private string PostOrder(Element aux)
        {
            string str = "";
            if (aux.Left != null)
            {
                str += PostOrder(aux.Left);
            }

            if (aux.Rigth != null)
            {
                str += PostOrder(aux.Rigth);
            }

            return str += aux.Value;
        }

        public Element Root { get => root; }
    }
}
