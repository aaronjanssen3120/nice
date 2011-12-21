using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// use the Sho libraries:
using ShoNS.Array;
using ShoNS.Visualization;
using ShoNS.MathFunc;  // for the RandomDoubleArray method
using ShoNS.SignalProc;
using ShoNS.Utils;
using ShoNS.Stats;

namespace Seismic
{
        /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TimeSeries
    {
        /// <summary>
        /// The x values
        /// </summary>
        public DoubleArray x;
        /// <summary>
        /// The y values
        /// </summary>
        public DoubleArray y;

        public TimeSeries(DoubleArray x, DoubleArray y)
        {
             //DoubleArray x = x;
             //DoubleArray y=y;
        }

        public void plot()
        {
             IFigure f2 = ShoPlotHelper.Figure();
             DoubleArray pme = ArrayRandom.RandomDoubleArray(50,50);
             ArrayImage.GetArrayImage(pme,-1.0,1.0);
           ShoChart ch = new ShoContourChart(pme, null);

             
        }





        }




    
    
    // Another class definition. This one contains
    // the Main method, the entry point for the program.
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");

                        DoubleArray ee = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray ef = ArrayRandom.RandomDoubleArray(4096);

            TimeSeries myTimeSeries = new TimeSeries(ef,ee);

            TimeSeries myOtherTimeSeries = myTimeSeries;

            myTimeSeries.x = ef;

            myTimeSeries.plot();

            System.Console.WriteLine(myOtherTimeSeries.x);



           // IFigure f2 = ShoPlotHelper.Figure();

            System.Console.WriteLine("Starting Slow");
            System.Console.WriteLine(DateTime.Now);
            ArraySettings.DisableFastMath();
            DoubleArray b = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray a = ArrayRandom.RandomDoubleArray(1024);

            for (int i = 0; i < 100; i++)
            {
                DoubleArray c = ConvComp.Conv(b, a);
                //System.Console.WriteLine(i);
            }
            System.Console.WriteLine(DateTime.Now);


            System.Console.WriteLine("Starting Fast");
            System.Console.WriteLine(DateTime.Now);
            ArraySettings.EnableFastMath();

            CubicSpline cs = new CubicSpline();
            DoubleArray d = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray e = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray g = d.Sort(); cs.Fit(g, e);
            DoubleArray h = cs.Interp(g);
            for (int i = 0; i < 10000; i++)
            {
                //DoubleArray f = ConvComp.Conv(d, e);

          
                //cs.Fit(g, e);
                 h = cs.Interp(g);
            }




            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Bye, World!");

        }
    }
}
