using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TryProcess
{
    public class IPMIAgent
    {
        public void DoIPMICommand(string cmd, Action<string, string, Exception> callback)
        {
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardOutput = true;
            //process.OutputDataReceived += (sender, args) => Console.WriteLine("received output: {0}", args.Data);
            //process.Start();
            //process.BeginOutputReadLine();

            //
            // Setup the process with the ProcessStartInfo class.
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = cmd;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            //
            // Start the process.
            //
            try
            {
                using (Process process = Process.Start(start))
                {
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    using (StreamReader reader = process.StandardOutput)
                    {
                        using (StreamReader errorReader = process.StandardError)
                        {
                            string result = reader.ReadToEnd();
                            string errorResult = errorReader.ReadToEnd();
                            callback(result, errorResult, null);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                callback(null, null, e);
            }
        }
    }
}
