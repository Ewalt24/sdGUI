using fgt_sdk.Enums;
using fgt_sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using static GUIApp1.Form1;
using System.Threading.Tasks;
using System.Threading;

namespace GUIApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void printFunc()
        {
            //function that cycles through the printing process
            int IL = GlobalVar.arrayWidth;
            int JL = GlobalVar.arrayHeight;
            double StrngIter = (GlobalVar.DNAsize + ((GlobalVar.divNum - 1) * 15)) / GlobalVar.divNum;
            int StrngIterRU = (int)Math.Ceiling(StrngIter);
            
            //cycles through for iterations equal to the amount of layers * 8
            //this is because we have 8 actions for each layer 4 nucleotides to print and 4 wash cycles
            for (int o = 0; o < StrngIterRU * 8; o++)
            {
                //color selection initialize
                Color[] colors = new Color[] { Color.White, Color.Black };
                Random random = new Random();

                int index = 0;

                index = (index == 0) ? 1 : 0;

                //flip var to keep track of which side of the double helix we are on
                int flip = 0;

                //main double for loop for cycling through each array spot to determine what to print
                for (int i = 0; i < IL; i++)
                {
                    for (int j = 0; j < JL; j++)
                    {
                        //identifies what label we are changing
                        string lblName = "label" + ((i * IL + j + 1).ToString());
                        Label lbl2chng = (Label)Controls.Find(lblName, true)[0];

                        //keeps track of location within the string
                        if (i + j == 0)
                        {
                            GlobalVar.StringLoc = GlobalVar.pushString;
                        }
                        else
                        {
                            //shifts location by stack length * what stack we are printing
                            GlobalVar.StringLoc = GlobalVar.pushString + (StrngIterRU * (i + j));
                        }

                        //Shows what nucleotide is being printed inside bubble (for testing purposes)
                        //lbl2chng.Text = GlobalVar.DNAString[GlobalVar.StringLoc].ToString();                    

                        //if we are on an even array location, flip nucleotides
                        if (flip % 2 == 0)
                        {
                            if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'a' && GlobalVar.n % 8 == 1)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'g' && GlobalVar.n % 8 == 3)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 't' && GlobalVar.n % 8 == 5)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'c' && GlobalVar.n % 8 == 7)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                        }
                        else
                        {
                            if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'a' && GlobalVar.n % 8 == 5)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'g' && GlobalVar.n % 8 == 7)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 't' && GlobalVar.n % 8 == 1)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                            else if (GlobalVar.DNAString[GlobalVar.StringLoc] == 'c' && GlobalVar.n % 8 == 3)
                            {
                                lbl2chng.BackColor = Color.White;
                            }
                        }
                        //if we are on a wash cycle, change all to black
                        if (GlobalVar.n % 2 == 0)
                        {
                            lbl2chng.BackColor = Color.Black;
                        }
                        //iterate flip
                        flip = flip + 1;
                    }
                }

                //exposure time wait if statement
                if (GlobalVar.n % 2 == 1)
                {
                    await Task.Delay(GlobalVar.expTime);
                }

                //wash process
                if (GlobalVar.n % 2 == 0)
                {
                    await Task.Delay(500);      //Buffer

                    //change to wash valve
                    for (uint valveIndex = 0U; valveIndex < GlobalVar.valveCount; valveIndex++)
                    {
                        fgtSdk.Fgt_set_valvePosition(valveIndex, 7);
                    }
                    await Task.Delay(2000);
                    //Increase Pressure Here to specified pressure
                    fgtSdk.Fgt_set_pressure(0, GlobalVar.setPressureWash);
                    await Task.Delay(GlobalVar.setDurationWash);
                    //decrease to 0
                    fgtSdk.Fgt_set_pressure(0, 0);
                    //sleep until done
                    await Task.Delay(1000);

                    //if we are on an a print cycle
                    if (GlobalVar.h % 4 == 0)
                    {
                        for (uint valveIndex = 0U; valveIndex < GlobalVar.valveCount; valveIndex++)
                        {
                            fgtSdk.Fgt_set_valvePosition(valveIndex, 0);        //sets valve pos to '1' (a)
                        }
                        await Task.Delay(2000);
                        //Increase Pressure
                        fgtSdk.Fgt_set_pressure(0, GlobalVar.setPressure);
                        await Task.Delay(GlobalVar.setDuration);
                        //decrease to 0
                        fgtSdk.Fgt_set_pressure(0, 0);
                        //sleep until done
                        await Task.Delay(1000);
                    }
                    if (GlobalVar.h % 4 == 1)
                    {
                        for (uint valveIndex = 0U; valveIndex < GlobalVar.valveCount; valveIndex++)
                        {
                            fgtSdk.Fgt_set_valvePosition(valveIndex, 1);        //sets valve pos to '1' (g)
                        }
                        await Task.Delay(2000);
                        //increase pressure to fill array with 'g'
                        fgtSdk.Fgt_set_pressure(0, GlobalVar.setPressure);
                        await Task.Delay(GlobalVar.setDuration);
                        //decrease to 0
                        fgtSdk.Fgt_set_pressure(0, 0);
                        //sleep until done
                        await Task.Delay(1000);
                    }
                    if (GlobalVar.h % 4 == 2)
                    {
                        for (uint valveIndex = 0U; valveIndex < GlobalVar.valveCount; valveIndex++)
                        {
                            fgtSdk.Fgt_set_valvePosition(valveIndex, 2);        //sets valve pos to '1' (t)
                        }
                        await Task.Delay(2000);
                        //increase pressure to fill array with 't'
                        fgtSdk.Fgt_set_pressure(0, GlobalVar.setPressure);
                        await Task.Delay(GlobalVar.setDuration);
                        //decrease to 0
                        fgtSdk.Fgt_set_pressure(0, 0);
                        //sleep until done
                        await Task.Delay(1000);
                    }
                    if (GlobalVar.h % 4 == 3)
                    {
                        for (uint valveIndex = 0U; valveIndex < GlobalVar.valveCount; valveIndex++)
                        {
                            fgtSdk.Fgt_set_valvePosition(valveIndex, 3);        //sets valve pos to '1' (c)
                        }
                        await Task.Delay(2000);
                        //increase pressure to fill array with 'c'
                        fgtSdk.Fgt_set_pressure(0, GlobalVar.setPressure);
                        await Task.Delay(GlobalVar.setDuration);
                        //decrease to 0
                        fgtSdk.Fgt_set_pressure(0, 0);
                        //sleep until done
                        await Task.Delay(1000);
                    }

                    //iterare h to keep track of what nucleotide we are printing
                    GlobalVar.h += 1;
                }

                //iterate n to keet track of wash vs print cycles
                GlobalVar.n = GlobalVar.n + 1;

                //after a full print/wash cycle - move one place over in the string
                if (GlobalVar.n % 8 == 0)
                {
                    GlobalVar.pushString += 1;
                }
                //progress bar at 100% is = StringIterRU so we can use it to keep track
                progressBar1.Value = GlobalVar.pushString;
            }
            //close fluid flow session
            fgtSdk.Fgt_close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double StrngIter = (GlobalVar.DNAsize + ((GlobalVar.divNum - 1) * 15)) / GlobalVar.divNum;
            int StrngIterRU = (int)Math.Ceiling(StrngIter);

            fgt_ERROR_CODE errCode;

            // Initialize session with all detected Fluigent instrument(s)
            errCode = fgtSdk.Fgt_init();

            if (errCode == fgt_ERROR_CODE.OK)
            {
                // Get number of valves
                (_, GlobalVar.valveCount) = fgtSdk.Fgt_get_valveChannelCount();

            }

            //make the button go away and progress bar visible
            button1.Visible = false;
            progressBar1.Visible = true;

            //Code for progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = StrngIterRU;
            progressBar1.Step = 1;

            int IL = GlobalVar.arrayWidth;
            int JL = GlobalVar.arrayHeight;

            GlobalVar.n = 0;                                                                  // iterative var for deciding between a black screen.

            int k = 250;
            int l = 250;
            int StringLoc1 = 0;

            //creates label arrray
            for (int i = 0; i < IL; i++)
            {
                for (int j = 0; j < JL; j++)
                {
                    string lblName = "label" + ((i * IL + j + 1).ToString());

                    Label lbltitleF = new Label();

                    //label style
                    lbltitleF.Size = new System.Drawing.Size(10, 10);
                    lbltitleF.BackColor = System.Drawing.Color.Black;
                    lbltitleF.Name = lblName;
                    //uncomment this back in for testing purposes - shows nucleotide inside of label
                    //lbltitleF.Text = GlobalVar.DNAString[StringLoc1].ToString();
                    lbltitleF.Location = new System.Drawing.Point(k, l);


                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(lbltitleF.ClientRectangle);

                    Region region = new Region(path);
                    lbltitleF.Region = region;


                    Controls.Add(lbltitleF);

                    StringLoc1 += StrngIterRU;
                    l += GlobalVar.spaceBetween; // iterate x axis
                }

                l = 250; // reset x axis
                k += GlobalVar.spaceBetween; // iterate y axis

            }

            k = 250; // reset both iterations
            l = 250;


            printFunc();

        }
    }
}
