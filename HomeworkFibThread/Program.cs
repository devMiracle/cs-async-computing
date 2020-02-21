using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFibThread
{
    class Program
    {
        private delegate UInt64 AsyncFibDelegate(UInt64 n);
        static void Main(string[] args)
        {
            AsyncFibDelegate del = Fib;
            IAsyncResult ar1 = del.BeginInvoke(40, EndSum, del);
            IAsyncResult ar2 = del.BeginInvoke(35, EndSum, del);
            IAsyncResult ar3 = del.BeginInvoke(30, EndSum, del);


            Console.ReadKey();
        }
        //метод вычисления ряда Фибоначчи
        private static UInt64 Fib(UInt64 counter)
        {
            return counter == 0 || counter == 1 ? counter : Fib(counter - 1) + Fib(counter - 2);
        }
        //
        private static void EndSum(IAsyncResult ar)
        {
            AsyncFibDelegate del = (AsyncFibDelegate)ar.AsyncState;
            UInt64 result = del.EndInvoke(ar);
            Console.WriteLine("Fib : " + result);
        }
    }
}
