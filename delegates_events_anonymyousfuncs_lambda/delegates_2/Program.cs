using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates_2
{
    public delegate void HelloFunctionDelegate(string msg);

    class Program
    {
        static void Main(string[] args)
        {
            HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);//pass in the function (in constructor) too which you want this delegate to point to
            del("Hello from delegate");
        }
        public static void Hello(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
