using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Service1 is running. http://localhost:8080");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}
