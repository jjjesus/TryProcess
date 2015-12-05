using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TryProcess
{
    public class IPMIClient
    {
        private IPMIAgent _ipmiAgent;

        public IPMIClient()
        {
            _ipmiAgent = new IPMIAgent();
        }

        public void DoIPMICommand(string cmd)
        {
            _ipmiAgent.DoIPMICommand(cmd, 
                (result, errorResult, error) =>
                {
                    if (error != null)
                    {
                        Console.WriteLine("Error on cmd:" + cmd);
                        Console.WriteLine(error.Message);
                        return;
                    }
                    Console.WriteLine("RESULTS");
                    Console.WriteLine("======");
                    Console.WriteLine(result);
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("ERROR RESULTS");
                    Console.WriteLine("======");
                    Console.WriteLine(errorResult);
                }
            );
        }
    }
}
