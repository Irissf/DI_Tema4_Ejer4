using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejer4
{
    public delegate double Delegado(double num1, double num2);
    public partial class Form1 : Form
    {

        Delegado delOperacion;
        double num1 = 0;
        double num2 = 0;
        int seg = 0;
        int min = 0;
        Hashtable operacion = new Hashtable();
        RadioButton rdb;

        public Form1()
        {
            InitializeComponent();
            operacion.Add("sumar", new Delegado((num1, num2) => { return num1 + num2; }));
            operacion.Add("restar", new Delegado((num1, num2) => { return num1 - num2; }));
            operacion.Add("multiplicar", new Delegado((num1, num2) => { return num1 * num2; }));
            operacion.Add("dividir", new Delegado((num1, num2) =>
            {
                if (num2 == 0)
                {
                    MessageBox.Show("Una división entre cero, da cero");
                    return 0;
                }
                else
                {
                    return num1 / num2;
                }
            }));

            timer1.Enabled = true;

            radioButton1.Tag = "+";
            radioButton2.Tag = "-";
            radioButton3.Tag = "*";
            radioButton4.Tag = "/";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                try
                {
                    num1 = Convert.ToDouble(textBox1.Text);
                    num2 = Convert.ToDouble(textBox2.Text);
                    label2.Text = String.Format("Resultado {0:0.###}", delOperacion(num1, num2))  ;
                }
                catch (FormatException)
                {
                    MessageBox.Show("formato incorrecto");
                }

            }
            else
            {
                label2.Text = "Introduce 2 números";
            }




        }

        private void check(object sender, EventArgs e)
        {
            rdb = (RadioButton)sender;
            delOperacion = (Delegado)operacion[rdb.Text]; //asignamos el delegado de tipo Delegado al delegado delOperacion
            label1.Text =Convert.ToString( rdb.Tag);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //esto pasa cada 1000 milisegundos que es lo que le indicamos
            seg++;
            if (seg == 60)
            {
                seg = 0;
                min++;
            }
            this.Text = String.Format("{0:00}:{1:00}", min, seg);

        }
    }
}
