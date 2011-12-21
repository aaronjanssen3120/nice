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
    // Class definition.
    public class MyCustomClass
    {
        // Class members:
        // Property.
        public int Number { get; set; }

        // Method.
        public int Multiply(int num)
        {
            return num * Number;
        }

        // Instance Constructor.
        public MyCustomClass()
        {
            Number = 0;
        }
    }
    // Another class definition. This one contains
    // the Main method, the entry point for the program.
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");

            
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
            DoubleArray d = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray e = ArrayRandom.RandomDoubleArray(4096);
            CubicSpline cs = new CubicSpline();
            d = ArrayRandom.RandomDoubleArray(4096);
            DoubleArray g = d.Sort(); cs.Fit(g, e);
            DoubleArray h = cs.Interp(g);
            for (int i = 0; i < 10000; i++)
            {
                //DoubleArray f = ConvComp.Conv(d, e);

          
                cs.Fit(g, e);
                 h = cs.Interp(g);
            }




            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Bye, World!");

        }
    }
}
