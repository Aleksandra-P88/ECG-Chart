using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using rtChart;
using System.IO;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;


namespace ADM
{

    public class Signal
    {


        protected string line;
        protected string[] lines;
        protected string lines_0;
        string lines_P="";
        public int i = 0;
        public List<int> lista = new List<int>();
        protected string sciezka = "C:/Users/user/Desktop/dane2.txt";
      
        public virtual List<int> read_line()
        {

            StreamReader sr = new StreamReader((sciezka));



            while ((line = sr.ReadLine()) != null)
            {

               // lines = line.Split(';');
               // lines_P = lines[0].Remove(0, 1);
                lista.Add(int.Parse(lines_P));

            }

            return lista;
        }





        public virtual double update()
        {



            if (i == 999)
            {
                i = 0;

            }

            double sample_ecg = read_line()[i];

            i++;

            return sample_ecg;


        }


       

    }

    public class Ecg : Signal
    {


        public override List<int> read_line()
        {

            StreamReader sr = new StreamReader((sciezka));



            while ((line = sr.ReadLine()) != null)
            {

                lines = line.Split(';');
                lines_0 = lines[1].Remove(0, 1);
                lista.Add(int.Parse(lines_0));

            }
            return lista;
        }



        public override double update()
        {

            if (i == 999)
            {
                i = 0;

            }


            double sample_ecg = read_line()[i];

            i++;

            return sample_ecg;


        }
    }



}
