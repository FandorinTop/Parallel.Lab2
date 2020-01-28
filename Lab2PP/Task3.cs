using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2PP
{
    class Task3
    {
        int[] arr1 = GetPositiveArrValue(10000000);
        int[] arr2 = GetNegativeArrValue(10000000);
        

        public double doPI_1()
        {

            object locker = new object();
            double sum = 0;
            int size = 10000000;


            Parallel.ForEach(arr1, (i) =>
             {
                 lock (locker)
                 {
                     sum += (double)(1.0 / i);
                 }
             });
            Parallel.ForEach(arr2, (i) =>
            {
                lock (locker)
                {
                    sum -= (double)(1.0 / i);
                }
            });


            return sum*4;
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

            return sum;

        }
        double PII(int start = 1, int doFor=10)
        {
            double sum=0;
            for (int j = start; start < doFor; start += 2, j++)
            {
                if (j % 2 == 1)
                    sum += (double)(1.0 / start);
                else
                    sum -= (double)(1.0 / start);
            }
            return sum;
        }
        //double Pravd(int j)
        //{
        //    double sum=0;
            
        //        if (j % 2 == 1)
        //            sum += (double)(1.0 / start);
        //        else
        //            sum -= (double)(1.0 / start);
        //        //step = !step;
            
        //    return sum;
        //}
        static int[] GetPositiveArrValue(int size)
        {
            int[] arr = new int[size / 4];
            int count=0;
            for(int i = 1; i < size; i++)
            {
                if ((i - 1) % 4 == 0)
                {
                    arr[count++] = i;
                }
               
            }
            return arr;
        }
        static int[] GetNegativeArrValue(int size)
        {
            int[] arr = new int[size / 4];
            int count = 0;
            for (int i = 1; i < size; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    arr[count++] = i;

                }

            }
            return arr;
        }
    }
}
