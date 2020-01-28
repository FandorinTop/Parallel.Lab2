using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace Lab2PP
{
    class Program
    {
        static void Main(string[] args)
        {
     
            Stopwatch timer = new Stopwatch();



            Console.WriteLine("Number Of Logical Processors: {0}", Environment.ProcessorCount);

            int correct = 0;
            var task2 = new Task2();
            var task3 = new Task3();








            Console.WriteLine("Math PI     " + Math.PI);
            Console.WriteLine("PI3:        " + PI_3(11));
            Console.WriteLine("PI5:        " + PI_5());
            Console.WriteLine("PI 2        " + PI_2(9000, 100000, ref correct));




            //1
            timer.Start();
            Console.WriteLine("Task1: " + PI_1() + "  Time: " + timer.ElapsedMilliseconds);
            timer.Stop();

            //2
            timer.Start();
            Console.WriteLine("Task2: " + task2.DoPI_1() + "  Time: " + timer.ElapsedMilliseconds);
            timer.Stop();

            //3
            timer.Start();

            Console.WriteLine("Task3: " + task3.doPI_1() + "  Time: " + timer.ElapsedMilliseconds);
            timer.Stop();



            //Console.WriteLine(PI_3(10000));

            //Console.WriteLine(PI_5());
            //Console.WriteLine(PI_4());

            //Console.WriteLine(PI_4());

            //Console.WriteLine(PI_2(1000,90000000,ref correct));
            //Console.WriteLine(PI_3(110));


            Console.WriteLine("#######################");
            Console.ReadKey();
        }
        static double PI_1()
        {
            bool step = true;
            int size = 1000000;
            int i = 1;
            int size_now=size/4;


            double sum = 0;

            for (int j = 1; j <= 4; j++)
            {
                double num = 0;
                for (; i <= size_now; i += 2)
                {
                    if (step)
                    {
                        sum += (double)(1.0 / i);
                        num += (double)(1.0 / i);
                    }
                    else
                    {
                        sum -= (double)(1.0 / i);
                        num -= (double)(1.0 / i);
                    }
                    step = !step;
                }
                i = size_now + 1;
                size_now = (size / 4) * (j + 1);
                num = 0;
            }


            return (double)sum*4;
        }
        //MONTEKARLO
        static double PI_2(int radius, int MaxPoint,ref int correct)
        {
            Random randomX = new Random();
            Random randomY = new Random();
            
            for(int i = 0; i < MaxPoint; i++)
            {
                if (IsCircle( randomX.NextDouble()*radius, randomY.NextDouble()*radius,radius))
                    Interlocked.Increment(ref correct);
            }



            double sum = (double)correct*4/MaxPoint;

            return sum;
        }
        static bool IsCircle(double x,double y,double radius)
        {
            return ((radius * radius) >= (x * x + y * y));
             
        }
        static double PI_3(int length)
        {
            double sum = 0;

            for (double i = 0;i<length;i++)
            {
                sum += (double)(1.0 / Math.Pow(16.0,i)) * (

                    (double)(4.0 / (double)(8.0 * i + 1.0))
                    - (double)(2.0 / (double)(8.0 * i + 4.0))
                    - (double)(1.0 / (double)(8.0 * i + 5.0))
                    - (double)(1.0 / (double)(8.0 * i + 6.0)) 

                    );
            }

            return sum;

            double MathPov(double pow, int step)
            {
               
                double result = pow;
                if (step != 0)
                {
                    for (int i = 0; i < step; i++)
                        result *= pow;
                    return result;
                }
                else
                   return 1.0;
            }
        }

        static double PI_4()
        {
            double sum = 0;
            for(double i = 0; i < 1000; i++)
            {
                sum +=  i * i / ((2 * i - 1) * (2 * i + 1));

            }
            return 4 * sum;
        }

        static double PI_5()
        {
            bool step = true;

            double sum = 0;

            for (int i = 1, j = i; i <= 1000000; i ++, j++)
            {
                if (step)
                    sum += (double)(1.0 / (double)i*i);
                else
                    sum -= (double)(1.0 / (double)i * i);
                step = !step;
            }
            return Math.Sqrt((double)sum) * 12;
           
        }
  
    }
   
}
