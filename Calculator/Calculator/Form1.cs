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
    public partial class Calculator : Form
    {
        enum Operation
        {
            Sum,
            Substr,
            Div,
            Multipl,
            None,
            Power,
            gcd,
            Mod
        }
        public double memory = 0;
        Operation oper = Operation.None;
        public static bool op = false;
        public static bool text = false;
        public static double temp;
        public static string temporary;

        public Calculator()
        {
            InitializeComponent();
        }

        private void number_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (textBox1.Text == "0" || text == false)
            {
                textBox1.Text = btn.Text;
                text = true;
            }
            else
                textBox1.Text = textBox1.Text + btn.Text;

            temporary = textBox1.Text;
        }

        private void oper_Clicked(object sender, EventArgs e)
        {
            if (op == true && text == true)
            {
                if (oper == Operation.Div)
                {
                    textBox1.Text = (temp / double.Parse(textBox1.Text)).ToString();
                }
                if (oper == Operation.Multipl)
                {
                    textBox1.Text = (temp * double.Parse(textBox1.Text)).ToString();
                }
                if (oper == Operation.Substr)
                {
                    textBox1.Text = (temp - double.Parse(textBox1.Text)).ToString();
                }
                if (oper == Operation.Sum)
                {
                    textBox1.Text = (temp + double.Parse(textBox1.Text)).ToString();
                }
                if (oper == Operation.Power)
                {
                    textBox1.Text = Math.Pow(temp, double.Parse(textBox1.Text)).ToString();
                }
                if (oper == Operation.gcd)
                {
                    double tempo = double.Parse(textBox1.Text);
                    while (temp != 0 && tempo != 0)
                    {
                        if (temp > tempo)
                            temp %= tempo;
                        else
                            tempo %= temp;
                    }
                    textBox1.Text = (temp == 0 ? tempo : temp).ToString();
                }
                if (oper == Operation.Mod)
                {
                    textBox1.Text = (temp % double.Parse(textBox1.Text)).ToString();
                }
            }

            temp = double.Parse(textBox1.Text);
            Button btn = sender as Button;

            if (btn.Text == "+")
            {
                oper = Operation.Sum;
            }

            if (btn.Text == "-")
            {
                oper = Operation.Substr;
            }

            if (btn.Text == "*")
            {
                oper = Operation.Multipl;
            }

            if (btn.Text == "/")
            {
                oper = Operation.Div;
            }

            if (btn.Text == "x^y")
            {
                oper = Operation.Power;
            }
            if (btn.Text == "gcd")
            {
                oper = Operation.gcd;
            }
            if (btn.Text == "mod")
            {
                oper = Operation.Mod;
            }
            op = true;
            text = false;
            if (btn.Text == "-" && double.Parse(textBox1.Text) < 0)
                label1.Text += temporary + " + " + " ";
            else if (btn.Text == "+" && double.Parse(textBox1.Text) < 0)
                label1.Text += temporary + " - " + " ";
            else
                label1.Text += temporary + btn.Text + " ";
        }

        private void result_Clicked(object sender, EventArgs e)
        {
            label1.Text = "";
            if (oper == Operation.Div)
            {
                textBox1.Text = (temp / double.Parse(textBox1.Text)).ToString();
            }
            if (oper == Operation.Multipl)
            {
                textBox1.Text = (temp * double.Parse(textBox1.Text)).ToString();
            }
            if (oper == Operation.Substr)
            {
                textBox1.Text = (temp - double.Parse(textBox1.Text)).ToString();
            }
            if (oper == Operation.Sum)
            {
                textBox1.Text = (temp + double.Parse(textBox1.Text)).ToString();
            }
            if (oper == Operation.Power)
            {
                textBox1.Text = Math.Pow(temp, double.Parse(textBox1.Text)).ToString();
            }
            if (oper == Operation.gcd)
            {
                double tempo = double.Parse(textBox1.Text);
                while (temp != 0 && tempo != 0)
                {
                    if (temp > tempo)
                        temp %= tempo;
                    else
                        tempo %= temp;
                }
                textBox1.Text = (temp == 0 ? tempo : temp).ToString();
            }
            if (oper == Operation.Mod)
            {
                textBox1.Text = (temp % double.Parse(textBox1.Text)).ToString();
            }
            op = false;
            text = false;
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Text = "0";
            temp = 0;
            op = false;
            text = false;
        }

        private void CE_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void BS_Clicked(object sender, EventArgs e)
        {
            string temp_txt = "";

            if (textBox1.Text.Length == 1)
            {
                temp_txt = "0";
            }

            else
                for (int i = 0; i < textBox1.Text.Length - 1; i++)
                {
                    temp_txt += textBox1.Text[i];
                }
            textBox1.Text = temp_txt;
        }

        private void sqrt_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Sqrt(double.Parse(textBox1.Text))).ToString();
        }

        private void power2_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) * double.Parse(textBox1.Text)).ToString();
        }

        private void DivByOne_Clicked(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "Error";
            }
            else
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
        }

        private void ValueSign_Clicked(object sender, EventArgs e)
        {  
            textBox1.Text = (double.Parse(textBox1.Text) * -1).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Double_Clicked(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
            temporary = textBox1.Text;
            op = false;
        }

        private void bin_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(int.Parse(textBox1.Text), 2);
        }

        private void hex_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(int.Parse(textBox1.Text), 16);
        }

        private void Oct_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(int.Parse(textBox1.Text), 8);
        }

        private void Sinx_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Math.Sin(int.Parse(textBox1.Text)).ToString();
        }

        private void Cosx_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Math.Cos(int.Parse(textBox1.Text)).ToString();
        }

        private void Tgx_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = Math.Tan(int.Parse(textBox1.Text)).ToString();
        }


        private void Proc_Clicked(object sender, EventArgs e)
        {

        }

        private void MAdd_Clicked(object sender, EventArgs e)
        {
            if (memory == 0)
            {
                memory = double.Parse(textBox1.Text);
            }
            else
            {
                memory += double.Parse(textBox1.Text);
            }
        }

        private void MMAdd_Clicked(object sender, EventArgs e)
        {
            if (memory == 0)
            {
                memory = (-1 * double.Parse(textBox1.Text));
            }
            else
            {
                memory -= double.Parse(textBox1.Text);
            }
        }

        private void MS_Clicked(object sender, EventArgs e)
        {
            memory = double.Parse(textBox1.Text);
        }

        private void MR_Clicked(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void MC_Clicked(object sender, EventArgs e)
        {
            memory = 0;
        }
    }
}
