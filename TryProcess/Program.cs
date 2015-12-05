using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            IPMIClient ipmiClient = new IPMIClient();
            string cmd = @"c:\Program Files\Java\jdk1.8.0_51\bin\java.exe";
            ipmiClient.DoIPMICommand(cmd);
            Console.WriteLine("Hit ENTER to continue");
            Console.ReadLine();
        }
    }
}
