﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Analyzer
    {
        LinkedList list;
        Tree tree;
        string preOrder;
        string postOrder;

        public Analyzer()
        {
            list = new LinkedList();
            tree = new Tree();
        }

        public void AnalyzeOperation(string str)
        {
            AddElements(str);
            AddLevels();

            BuildNodesByLevels();
            BuildTree();

            preOrder = tree.PreOrder();
            postOrder = tree.PostOrder();
        }

        private void AddElements(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                list.Add(new Element(str[i].ToString()));
            }
        }

        private void AddLevels()
        {
            int level = 2;
            Element aux = list.LastElement;
            while (aux != null)
            {
                if (IsNumber(aux) == false)
                {
                    if (IsSumRest(aux) == true)
                    {
                        level = 2;
                        aux.Level = 1;
                        aux = aux.Previous;
                    }
                    else
                    {
                        aux.Level = level;
                        level++;
                        aux = aux.Previous;
                    }
                }
                else
                {
                    aux = aux.Previous;
                }
            }
        }

        private void BuildNodesByLevels()
        {
            Element aux = list.FirstElement;
            while (aux != null)
            {
                if (aux.Level == 0 || aux.Level == 1)
                {
                    aux = aux.Next;
                }
                else
                {
                    if (aux.Level >= 2)
                    {
                        if (aux.Previous.Previous == null || aux.Previous.Previous.Level == 1)
                        {
                            aux.Left = aux.Previous;
                        }
                        else
                        {
                            aux.Left = aux.Previous.Previous;
                        }
                        aux.Rigth = aux.Next;

                        aux = aux.Next;
                    }
                }
            }

            aux = list.FirstElement;
            bool isInserted = false;
            while(aux != null && isInserted == false)
            {
                if (aux.Level == 1)
                {
                    aux.Left = aux.Previous;
                    if (aux.Next.Next.Level == 1)
                    {
                        aux.Rigth = aux.Next;
                    }
                    isInserted = true;
                }
                else
                {
                    aux = aux.Next;
                }
            }
        }

        private void BuildTree()
        {
            Element aux = list.LastElement;

            while (aux != null)
            {
                if (aux.Level == 1)
                {
                    tree.Add(aux);
                }
                aux = aux.Previous;
            }

            aux = list.LastElement;
            while (aux != null)
            {
                if (aux.Level == 2)
                {
                    tree.Add(aux);
                }
                aux = aux.Previous;
            }
        }

        private void CalculateResultByPreOrder()
        {

        }

        public string PrintElements()
        {
            return list.ToList();
        }

        public string PrintTree()
        {
            return tree.Root.ToString();
        }

        public string PrintTreePreOrder()
        {
            if (String.IsNullOrEmpty(preOrder))
            {
                preOrder = tree.PreOrder();
            }

            return preOrder;
        }

        public string PrintTreePostOrder()
        {
            if (String.IsNullOrEmpty(postOrder))
            {
                postOrder = tree.PostOrder();
            }

            return postOrder;
        }
        
        private bool IsNumber(Element aux)
        {
            if (aux.Value == "0" || aux.Value == "1" || aux.Value == "2" || aux.Value == "3" || aux.Value == "4" || aux.Value == "5" || aux.Value == "6" || aux.Value == "7" || aux.Value == "8" || aux.Value == "9")
            {
                return true;
            }
            return false;
        }

        private bool IsSumRest(Element aux)
        {
            if (aux.Value == "+" || aux.Value == "-")
            {
                return true;
            }
            return false;
        }

        private bool IsMultiDiv(Element aux)
        {
            if (aux.Value == "*" || aux.Value == "/")
            {
                return true;
            }
            return false;
        }
    }
}