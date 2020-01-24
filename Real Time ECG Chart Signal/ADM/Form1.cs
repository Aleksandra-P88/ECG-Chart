using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using rtChart;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace ADM
{
   


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

      
        Ecg ecg = new Ecg();

         

  
        public static List<int> readlines(Signal signal)
        {


           return  signal.read_line();
           
        }



        public  double updates()
        {
           
            
            return ecg.update();
        }


      



        private void Form1_Load(object sender, EventArgs e)
        {

 
            Func<double> del1 = updates;

            kayChart ecg1 = new kayChart(chart1, 1000);

           
            // kayChart imp = new kayChart(chart1, 1000);
            //kayChart time = new kayChart(chart3, 1000);

            Task.Factory.StartNew(() =>
            {

                ecg1.updateChart(updates, 40);
                // imp.updateChart(upadateImp, 40);
                // time.updateChart(upadateTime, 40);


            }
            );




            int[] nr_linii = readlines(ecg).ToArray();


            foreach (int item in nr_linii)
            {

                listBox1.Items.Add(item);

                


            }

           


           
            chart1.ChartAreas[0].AxisX.Maximum = 1000;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = readlines(ecg).Max();
            chart1.ChartAreas[0].AxisY.Minimum = readlines(ecg).Min();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;


            


        }



        




    }
}
