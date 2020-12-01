using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Program
    {
        delegate double F2Delegate(double x1, double x2);

        private static double Func(double x1, double x2)
        {
            double a, b;
            a = Math.Pow(Math.Cos(x1), 3) + 45 + x2   ;
            b = Math.Pow(x1, 13) + Math.Cos(x2);
            return a/b;

        }

        private static double Acc(double init, double y)
        {
            return init + Math.Sin(y);
        }


        private static void EnterData(out double X1min, out double X1max, out double X2min, out double X2max, out double dx1, out double dx2)
        {
            Console.Write(" X1 min : ");
            X1min = double.Parse(Console.ReadLine());

            Console.Write(" X1 max : ");
            X1max = double.Parse(Console.ReadLine());

            Console.Write(" X2 min : ");
            X2min = double.Parse(Console.ReadLine());

            Console.Write(" X2 max : ");
            X2max = double.Parse(Console.ReadLine());

            Console.Write(" dx1 : ");
            dx1 = double.Parse(Console.ReadLine());

            Console.Write(" dx2 : ");
            dx2 = double.Parse(Console.ReadLine());

        }

        private static void Tabulate(double X1min, double X1max, double X2min, double X2max, double dx1, double dx2, double init, F2Delegate func, F2Delegate acc)
        {
            double a = X1min;
            Console.WriteLine("Tabulate function");
            while (a <= X1max)
            {
                double b = X2min;
                double x1 = a;
                while (b <= X2max)
                {
                    double x2 = b;
                    double y = func(x1, x2);
                    Console.WriteLine("x1={0:f3}\t\tx2={1:f3}\t\ty={2}", a, b, y);

                    if (a > X1min && a < X1max && Math.Sin(y) > 0)
                    {
                        init = acc(init, y);
                    }
                    b += dx2;
                }
                a += dx1;

            }
            Console.WriteLine("===================");
            if (acc != null)
            {
                Console.WriteLine("Middle results of unsigned sin:");
                Console.WriteLine(init);
                Console.WriteLine("================");
            }

        }

        static void Main(string[] args)
        {
            EnterData(out double X1min, out double X1max, out double X2min, out double X2max, out double dx1, out double dx2);
            Tabulate(X1min, X1max, X2min, X2max, dx1, dx2, 0, Func, Acc);
            Console.ReadKey();
        }
    }
}