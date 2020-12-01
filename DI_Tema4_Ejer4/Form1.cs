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
        bool divi = false;
        int seg = 0;
        int min = 0;
        Hashtable operacion = new Hashtable();

        public Form1()
        {
            InitializeComponent();
            operacion.Add("sumar", new Delegado((num1, num2) => { return num1 + num2; }));
            operacion.Add("restar", new Delegado((num1, num2) => { return num1 - num2; }));
            operacion.Add("multiplicar", new Delegado((num1, num2) => { return num1 * num2; }));
            operacion.Add("dividir", new Delegado((num1, num2) => { return num1 / num2; }));

            timer1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = Convert.ToDouble(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("formato incorrecto");
            }
            if (divi && (num1 == 0 || num2 == 0))
            {
                label2.Text = "Divison entre 0 mal";
                divi = false;
            }
            else
            {
                label2.Text = "Resultado " + delOperacion(num1, num2);

            }



        }

        private void check(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb == radioButton1)
            {
                delOperacion = (Delegado)operacion[radioButton1.Text]; //asignamos el delegado de tipo Delegado al delegado delOperacion
                label1.Text = "+";

            }
            else if (rdb == radioButton2)
            {
                delOperacion = (Delegado)operacion[radioButton2.Text]; //asignamos el delegado de tipo Delegado al delegado delOperacion
                label1.Text = "-";

            }
            else if (rdb == radioButton3)
            {
                delOperacion = (Delegado)operacion[radioButton3.Text]; //asignamos el delegado de tipo Delegado al delegado delOperacion
                label1.Text = "*";

            }
            else if (rdb == radioButton4)
            {
                delOperacion = (Delegado)operacion[radioButton4.Text]; //asignamos el delegado de tipo Delegado al delegado delOperacion
                label1.Text = "/";
                divi = true;

            }
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
