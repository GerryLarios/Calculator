using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Analyzer analyzer;

        public Form1()
        {
            analyzer = new Analyzer();
            InitializeComponent();
        }

        // This Gonna helps of to Check if it's a number
        private bool isNumber(string str)
        {
            if (str == "0" || str == "1" || str == "2" || str == "3" || str == "4" || str == "5" || str == "6" || str == "7" || str == "8" || str == "9")
            {
                return true;
            }
            return false;
        }
        // This Gonna helps of to Check if it's a operator (*, /)
        private bool isMultiDiv(string str)
        {
            if (str == "/" || str == "*")
            {
                return true;
            }
            return false;
        }
        // This Gonna helps of to Check if it's a operator (+, -)
        private bool isSumRest(string str)
        {
            if (str == "+" || str == "-")
            {
                return true;
            }
            return false;
        }
        // We can't work with another operator or letters, so we need to check every element in the operation.
        private bool isArithmeticOperation(string str)
        {
            bool errorEncountered = false;

            // The following while check the elements
            int i = 0;
            while (i < str.Length && errorEncountered == false)
            {
                // if the element in the string is one of these, no problem
                if (isNumber(str[i].ToString()) || isSumRest(str[i].ToString()) || isMultiDiv(str[i].ToString()))
                {
                    i++;
                }
                else
                {
                    // but if isn't a number, sum, rest, multi or div, we have an error
                    errorEncountered = true;
                }
            }
            // If errorEncountered is true return false, else return true
            return errorEncountered ? false : true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // We need to check the operation. e.g " 5+4-3*2+8*3/6/2+6*2 || 3-6*3/95+*2-3*4/6 "
            if (isArithmeticOperation(txtOperation.Text) == true)
            {
                // We send the operation as parameter in the function.
                analyzer.AnalyzeOperation(txtOperation.Text);

                txtPostOrder.Text = analyzer.PrintTreePostOrder();
                txtPreOrder.Text = analyzer.PrintTreePreOrder();

                txtPreOrderResult.Text = analyzer.PrintPreOrderResult().ToString();
                txtPostOrderResult.Text = analyzer.PrintPostOrderResult().ToString();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
