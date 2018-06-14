using System;
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

        double preOrderResult;
        double postOrderResult;

        public Analyzer()
        {
            list = new LinkedList();
            tree = new Tree();
        }

        public void AnalyzeOperation(string str)
        {
            AddElements(str, list);
            AddLevels(list.LastElement);

            BuildNodesByLevels(list);
            BuildTree(list.LastElement, 1);
            BuildTree(list.LastElement, 2);

            preOrder = tree.PreOrder();
            Console.WriteLine(preOrder);
            postOrder = tree.PostOrder();

            preOrderResult = CalculateResult(preOrder);
            postOrderResult = CalculateResult(postOrder);
        }

        private void AddElements(string str, LinkedList list)
        {
            for (int i = 0; i < str.Length; i++)
            {
                list.Add(new Element(str[i].ToString()));
            }
        }

        private void AddLevels(Element aux)
        {
            int level = 2;
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

        private void BuildNodesByLevels(LinkedList list)
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

        private void BuildTree(Element aux, int level)
        {
            while (aux != null)
            {
                if (aux.Level == level)
                {
                    tree.Add(aux);
                }
                aux = aux.Previous;
            }
        }

        private double CalculateResult(string order)
        {
            LIFO stack = new LIFO();
            if (IsNumber(order[0].ToString()) == true)
            {
                for (int i = 0; i < order.Length; i++)
                {
                    BuildStack(ref stack, order[i].ToString());
                }
            }
            else
            {
                for (int i = order.Length - 1; i >= 0; i--)
                {
                    BuildStack(ref stack, order[i].ToString());
                }
            }

            return Convert.ToDouble(stack.Pop().Value);
        }

        private void BuildStack(ref LIFO stack, string str)
        {
            if (IsNumber(str.ToString()) == true)
            {
                stack.Push(new Element(str));
            }
            else
            {
                stack.Push(MakeOperation(stack.Pop().Value, stack.Pop().Value, str.ToString()));
            }
        }

        private Element MakeOperation(string firstValue, string secondValue, string operation)
        {
            Element result;
            double value;

            switch (operation)
            {
                case "+":
                    value = Convert.ToDouble(firstValue) + Convert.ToDouble(secondValue);
                    result = new Element(Convert.ToString(value));
                    break;
                case "-":
                    value = Convert.ToDouble(firstValue) - Convert.ToDouble(secondValue);
                    result = new Element(Convert.ToString(value));
                    break;
                case "*":
                    value = Convert.ToDouble(firstValue) * Convert.ToDouble(secondValue);
                    result = new Element(Convert.ToString(value));
                    break;
                case "/":
                    value = Convert.ToDouble(firstValue) / Convert.ToDouble(secondValue);
                    result = new Element(Convert.ToString(value));
                    break;
                default:
                    result = null;
                    break;
            }
            
            return result;
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

        public double PrintPreOrderResult()
        {
            return preOrderResult;
        }

        public double PrintPostOrderResult()
        {
            return postOrderResult;
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

        private bool IsNumber(string value)
        {
            if (value == "0" || value == "1" || value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9")
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
