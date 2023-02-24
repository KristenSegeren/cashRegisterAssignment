using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        private void calculateButton_Click(object sender, EventArgs e)
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
        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            tender = Convert.ToDouble(tenderInput.Text);
            change = tender - total;
            changeOutput.Text = $"{change.ToString("C")}";

        }
        private void printReciptButton_Click(object sender, EventArgs e)
        {
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
        }
    }
}
