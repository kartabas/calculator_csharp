using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {

         string[] calc_array = new string[50];
         double[] calc_array_double = new double[50];
         string[] calc_operators = new string[50];
         int t = 0;
         int g = 0;
         int w = 0;
         int wert_opr = 0;

        string calc_opr = " ";



        public Form1()
        {
            InitializeComponent();
        }




        private void btn_numberOne_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();

            calc_opr = "1";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberOne.Text;

            opr(calc_opr);
        }

        private void btn_numberTwo_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "2";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberTwo.Text;

            opr(calc_opr);
        }


        private void btn_numberThree_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "3";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberThree.Text;

            opr(calc_opr);
        }
       

        private void btn_numberFour_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "4";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberFour.Text;

            opr(calc_opr);
        }

        private void btn_numberFive_Click_1(object sender, EventArgs e)
        {
            w++; 
            clear_null();
            calc_opr = "5";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberFive.Text;
            opr(calc_opr);
        }

        private void btn_numberSix_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "6";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberSix.Text;

            opr(calc_opr);
        }

        private void btn_numberSeven_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "7";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberSeven.Text;


            opr(calc_opr);
        }

        private void btn_numberEight_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "8";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberEight.Text;

            opr(calc_opr);
        }

        private void btn_numberNine_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "9";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberNine.Text;

            opr(calc_opr);
        }


        private void btn_numberZero_Click_1(object sender, EventArgs e)
        {
            w++;
            clear_null();
            calc_opr = "0";

            textBox_Screen.Text = textBox_Screen.Text + btn_numberZero.Text;

            opr(calc_opr);
        }





        private void btn_Mal_Click_1(object sender, EventArgs e)
        {

            w = 0; 
            calc_opr = "*";



            textBox_Screen.Text = textBox_Screen.Text + calc_opr;

            //MessageBox.Show(w.ToString(),"Ergebnis");
            opr(calc_opr);
          

        }

        private void btn_Div_Click_1(object sender, EventArgs e)
        {
            w = 0;
            
            calc_opr = "/";


            textBox_Screen.Text = textBox_Screen.Text + calc_opr;


            opr(calc_opr);
        }



        private void btn_Plus_Click_1(object sender, EventArgs e)
        {
            w = 0;
           
            calc_opr = "+";
            textBox_Screen.Text = textBox_Screen.Text + calc_opr;


            opr(calc_opr);
        }

        private void btn_Minus_Click_1(object sender, EventArgs e)
        {
            if (textBox_Screen.Text != "")
            {
                w = 0;


                calc_opr = "-";

                textBox_Screen.Text = textBox_Screen.Text + calc_opr;

                opr(calc_opr);
            }
        }


        //------------------------------------------------------------------//


        private void btn_Reset_Click_1(object sender, EventArgs e)
        {
            textBox_Screen.Clear();
            Array.Clear(calc_array, 0, calc_array.Length);
            Array.Clear(calc_array_double, 0, calc_array_double.Length);
            Array.Clear(calc_operators, 0, calc_operators.Length);
            t = 0;
            w = 0;
            wert_opr = 0;
            calc_opr = " ";
        }


        private void btn_Gleich_Click_1(object sender, EventArgs e)
        {
            calc2();
        }




        private void calc2()
        {


            sort_array_numbers();
            sort_array_operators();

            double result = rechnen(calc_array_double, calc_operators);

            textBox_Screen.Text = result.ToString();



        }



        private double rechnen(double[] calc_array_double, string[] calc_operators)
        {
            double first = calc_array_double[0];

            for (int i = 1, k = 0; i < calc_array_double.Length && k < calc_operators.Length; i++, k++)
            {
                switch (calc_operators[k])
                {
                    case "*":
                        first *= calc_array_double[i];
                        break;
                    case "/":
                        first /= calc_array_double[i];
                        break;
                    case "+":
                        first += calc_array_double[i];
                        break;
                    case "-":
                        first -= calc_array_double[i];
                        break;
                }
            }

            return first;
        }





        private void clear_null()
        {

            if (textBox_Screen.Text == "0")
            {
                textBox_Screen.Text = "";
            }
        }



        private void opr(string calc_opr)
        {

            int Index = t;

            if (w >= 2)
            {

                calc_array[Index-1] += calc_opr;
                t++;
            }
            else {
                calc_array[Index] += calc_opr;
            }
            


            t++;

        }




        private void sort_array_numbers()
        {
            for (int i = 0; i < calc_array.Length; i = i + 2)
            {
                if (calc_array[i] != null)
                {
                    if (double.TryParse(calc_array[i], out double value))
                    {
                        calc_array_double[i] = value;
                    }
                    else
                    {
                        calc_array_double[i] = 0.0;
                    }
                }
                else
                {
                    calc_array_double[i] = 0.0;
                }
            }
        }





        private void sort_array_operators()
        {


            for (int i = 1; i < calc_array.Length; i += 2)
            {
                if (calc_array[i] != null && calc_array[i].Length == 1)
                {
                    calc_operators[i] = calc_array[i];
                }
            }
        }
    


}      ///xxxxxxxx//
    
}