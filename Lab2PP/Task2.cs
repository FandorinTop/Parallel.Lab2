using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
namespace Lab2PP
{
    class Task2
    {
        static object Console_Free = new object();
        private int ProcessorCount { get; } = Environment.ProcessorCount;

        public double DoPI_1()
        {
        
            var tasks = new Task<double>[ProcessorCount];

            double sum = 0;
            int size = 1000000;
            int start = 1;
            int doFor = size / tasks.Length;
           
            Example[] examples = new Example[ProcessorCount];
            for(int i=1;i<=tasks.Length; i++)
            {

                examples[i - 1] = new Example(doFor,start,size);
                tasks[i-1]= examples[i-1].TaskForPi();

                start = doFor+1;
                doFor = size / tasks.Length * (i+1);

            }

            foreach (var k in tasks)
            {
                //k.Start();
                k.Start();
            }
            Task.WaitAll(tasks);

            foreach (var k in tasks)
            {
                    sum += k.Result;
            }
            return sum;
        }

        double PI_1(int doFor, int start = 1, int maxSize=1000000)
        {
            bool step = doFor%2==1;
            double sum = 0;
            for (int j =start; start < doFor; start += 2,j++)
            {
                if (j%2==1)
                    sum += (double)(1.0 / start);
                else
                    sum -= (double)(1.0 / start);
                step = !step;
            }

            return sum*4;

        }
        //MONTEKARLO
        double PI_2(int radius, int MaxPoint, ref int correct)
        {
            Random randomX = new Random();
            Random randomY = new Random();

            for (int i = 0; i < MaxPoint; i++)
            {
                if (IsCircle(randomX.NextDouble() * radius, randomY.NextDouble() * radius, radius))
                    Interlocked.Increment(ref correct);
            }



            double sum = (double)correct * 4 / MaxPoint;

            return sum;
        }
        bool IsCircle(double x, double y, double radius)
        {
            return ((radius * radius) >= (x * x + y * y));

        }
        double PI_3(int length)
        {
            double sum = 0;

            for (double i = 0; i < length; i++)
            {
                sum += (double)(1.0 / Math.Pow(16.0, i)) * (

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
    }
    class Example
    {
        int doFor;
        int start;
        int maxSize;

        public Example(int dF, int s,int mS)
        {
            doFor = dF;
            start = s;
            maxSize = mS;
        }

        public Task<double> TaskForPi()
        {
            return new Task<double>(() => PI_1(doFor, start, maxSize));
        }
        double PI_1(int doFor, int start = 1, int maxSize = 1000000)
        {
            bool step = doFor % 2 == 1;
            double sum = 0;
            for (int j = start; start < doFor; start += 2, j++)
            {
                if (j % 2 == 1)
                    sum += (double)(1.0 / start);
                else
                    sum -= (double)(1.0 / start);
                step = !step;
            }
            //lock (Console_Free)
            //{
            //Console.WriteLine("doFor: " + start);
            //    Console.WriteLine("Print         " + sum*4);
            //}
            //return 5;

            return sum * 4;

        }
    }
}
