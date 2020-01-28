using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace Lab2PP
{
    class Task1
    {
        static double PI_1()
        {
            bool step = true;
            double sum = 0;
            for (int i = 1; i < 1000000; i += 2)
            {
                if (step)
                    sum += (double)(4.0 / i);
                else
                    sum -= (double)(4.0 / i);
                step = !step;
            }
            return sum;
        }
        //MONTEKARLO
        static double PI_2(int radius, int MaxPoint, ref int correct)
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
        static bool IsCircle(double x, double y, double radius)
        {
            return ((radius * radius) >= (x * x + y * y));

        }
        static double PI_3(int length)
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
}
