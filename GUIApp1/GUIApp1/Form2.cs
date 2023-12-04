using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUIApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //stores DNA string to its global var
            Form1.GlobalVar.DNAString = textBox1.Text;
            label3.Text = Form1.GlobalVar.DNAString.Length.ToString();

            //calls function DNAAnalyzer to see what array size to use and stores to result
            string result = DNAAnalyzer.CompareDNAStringToConstraints(Form1.GlobalVar.DNAString.Length);
            label3.Text = result;
        }
        public class DNAAnalyzer
        {
            public static string CompareDNAStringToConstraints(int size)
            {
                //these constraints correlate to max and min values cartain array sized can handle
                //we want the printed strings to be within 80-100 nucleotides
                //so, top constraint for 10x10 is = 100 * 100 - (15 * (100-1)) = 8515
                //bottom of 10x10 has overlap with 9x9 so top constraint for 9x9 is used as lower limit
                //max is a 10x10, min is a 3x3
                string[] constraints = new string[]
                {
                        "8515-6901", "6900-5456", "5455-4181", "4180-3201",
                        "3200-3076", "3075-2341", "2340-2141", "2140-1641",
                        "1640-1374", "1375-1056", "1055-1036", "1035-796",
                        "795-781", "780-600"
                };

                for (int i = 0; i < constraints.Length; i++)
                {
                    //parses the constraint list into two seperate vars
                    string[] range = constraints[i].Split('-');
                    int min = int.Parse(range[1]);
                    int max = int.Parse(range[0]);

                    //compares size of string to constraints and returns the reccomended size
                    if (size >= min && size < max)
                    {
                        switch (i)
                        {
                            case 0:
                                Form1.GlobalVar.divNum = 100;
                                return "10x10";

                            case 1:
                                Form1.GlobalVar.divNum = 81;
                                return "9x9";

                            case 2:
                                Form1.GlobalVar.divNum = 64;
                                return "8x8";

                            case 3:
                                Form1.GlobalVar.divNum = 49;
                                return "7x7";

                            case 4:
                                Form1.GlobalVar.divNum = 42;
                                return "6x7";

                            case 5:
                                Form1.GlobalVar.divNum = 36;
                                return "6x6";

                            case 6:
                                Form1.GlobalVar.divNum = 30;
                                return "6x5";

                            case 7:
                                Form1.GlobalVar.divNum = 25;
                                return "5x5";

                            case 8:
                                Form1.GlobalVar.divNum = 20;
                                return "5x4";

                            case 9:
                                Form1.GlobalVar.divNum = 16;
                                return "4x4";

                            case 10:
                                Form1.GlobalVar.divNum = 15;
                                return "5x3";

                            case 11:
                                Form1.GlobalVar.divNum = 12;
                                return "4x3";

                            case 12:
                                Form1.GlobalVar.divNum = 10;
                                return "5x2";

                            case 13:
                                Form1.GlobalVar.divNum = 9;
                                return "3x3";

                            default:
                                return "Value " + size + " is within an undefined constraint.";
                        }
                    }
                }

                return "Value " + size + " does not match any constraint.";
            }
        }
    }
}
