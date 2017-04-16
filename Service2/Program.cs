using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8081"))
            {
                Console.WriteLine("Service2 is running. http://localhost:8081");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}
