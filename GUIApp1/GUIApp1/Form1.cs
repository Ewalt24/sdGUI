using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fgt_sdk;
using fgt_sdk.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;

namespace GUIApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class GlobalVar
        {
            //declaration of variables that are used globally
            public static int arrayWidth;
            public static int arrayHeight;
            public static int DNAsize;
            public static double divNum;
            public static int n = 0;
            public static string DNAString;
            public static int expTime;
            public static int pushString = 0;
            public static int StringLoc;
            public static int valveCount;
            public static int h = 0;
            public static int setPressure;
            public static int setDuration;
            public static int setPressureWash;
            public static int setDurationWash;
            public static int spaceBetween;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            //Shows second form on button click
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            //shows third form on button click
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Saves values from user into respective global vars and changes text boxes to display input values
            label8.Text = comboBox1.SelectedItem.ToString() + "x" + comboBox2.SelectedItem.ToString();
            label10.Text = textBox2.Text;
            label6.Text = textBox1.Text;
            GlobalVar.spaceBetween = int.Parse(textBox1.Text);
            GlobalVar.arrayHeight = comboBox1.SelectedIndex;
            GlobalVar.arrayWidth = comboBox2.SelectedIndex;
            GlobalVar.expTime = int.Parse(textBox2.Text);
            label13.Text = textBox3.Text;
            label15.Text = textBox4.Text;
            GlobalVar.setPressure = int.Parse(textBox3.Text);
            GlobalVar.setDuration = int.Parse(textBox4.Text);
            label20.Text = textBox5.Text;
            label17.Text = textBox6.Text;
            GlobalVar.setPressureWash = int.Parse(textBox3.Text);
            GlobalVar.setDurationWash = int.Parse(textBox4.Text);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
