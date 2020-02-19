using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_async_computing
{
    class Program
    {
        private delegate UInt64 AsyncSumDel(UInt64 n);
        static void Main(string[] args)
        {
            AsyncSumDel del = Sum;
            // AsyncSumDel del = new AsyncSumDel(Sum);
            IAsyncResult ar =
                del.BeginInvoke(1000000000, EndSum, del);
            while (!ar.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }

        // v1
        public static UInt64 Sum(UInt64 n)
        {
            UInt64 sum = 1;
            for (UInt64 i = 2; i < n; ++i)
                sum += i;
            return sum;
        }

        private static void EndSum(IAsyncResult ar)
        {
            AsyncSumDel del = (AsyncSumDel)ar.AsyncState;
            UInt64 res = del.EndInvoke(ar);
            Console.WriteLine("Сумма = " + res);
        }
        
    }
}
