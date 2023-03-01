using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cashRegisterAssignment
{
    public partial class CounterfeitMarks : Form
    {
        public CounterfeitMarks()
        {
            InitializeComponent();
        }
        //Variables set up
        int levis = 95;
        int wrangler = 70;
        int silver = 103;
        double numOfLevis, numOfWrangler, numOfSilver, subTotal, taxTotal, total, tender, change;



        double finalLevis;
        double finalWranglers;
        double finalSilver;
        bool receipt = false;
        bool calculate = false;


        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //input
                numOfLevis = Convert.ToDouble(levisInput.Text);
                numOfWrangler = Convert.ToDouble(wranglersInput.Text);
                numOfSilver = Convert.ToDouble(silversInput.Text);

                //calculations
                finalLevis = levis * numOfLevis;
                finalWranglers = wrangler * numOfWrangler;
                finalSilver = silver * numOfSilver;

                subTotal = finalLevis + finalWranglers + finalSilver;
                taxTotal = subTotal * 0.13;
                total = subTotal + taxTotal;

                //output
                subTotalOutput.Text = $"{subTotal.ToString("C")}";
                taxTotalOutput.Text = $"{taxTotal.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";
            }
            catch
            {
                subTotalOutput.Text = $"please ";
                taxTotalOutput.Text = $"insert";
                totalOutput.Text = $"numbers";
            }

            calculate = true;
        }
        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            if (calculate == true)
            {
                tender = Convert.ToDouble(tenderInput.Text);
                change = tender - total;
                changeOutput.Text = $"{change.ToString("C")}";
                receipt = true;
            }
        }
        private void printReciptButton_Click(object sender, EventArgs e)
        {
            if (receipt == true)
            {

                SoundPlayer printerPlayer = new SoundPlayer(Properties.Resources.printerNoise);
                printerPlayer.Play();


                reciptLabel.Text = $"The Denim Shop\n\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"You bought...\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"{numOfLevis} Levis                        @${levis}\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"{numOfSilver} Silvers                      @${silver}\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"{numOfWrangler} Wranglers                @${wrangler}\n\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"for a total of...\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"${total}\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"you paid...\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"${tender} \n\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"You will recieve {change.ToString("C")} in change\n\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"Thank You For Shopping at Counterfeit Marks\n";
                Thread.Sleep(800);
                Refresh();
                reciptLabel.Text += $"Have A Wonderful Day:)\n";
                Thread.Sleep(800);
                Refresh();

                printerPlayer.Stop();
            }

        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            reciptLabel.Text = "";
            subTotalOutput.Text = "";
            taxTotalOutput.Text = "";
            totalOutput.Text = "";
            changeOutput.Text = "";
            tenderInput.Text = "";
            levisInput.Text = "";
            wranglersInput.Text = "";
            silversInput.Text = "";

            numOfLevis = 0;
            numOfWrangler = 0;
            numOfSilver = 0;
            subTotal = 0;
            taxTotal = 0;
            total = 0;
            tender = 0;
            change = 0;


            receipt = false;
            calculate = false;
        }
    }
}

