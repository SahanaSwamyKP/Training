using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	/*Delegates:
     * Delegates are like function pointers of C/c++
     * They are like reference types that represent funcyions instead of data types.
     * This help in passing functions are args.Imagine,they are like callback function that are used in programming language like python,Javascrit
     * 
     */
	
	internal class Ex03DelegateExample

    {
		delegate double Operation(double v1, double v2);
        //purpose :TO replace traditional math operation methods with function pointers where we can pass the function 
        delegate void LogMessageDelegate(string message);

		static void PerfomeMathOperation(double v1, double v2, Operation method)
        {
            var res = method(v1, v2);
            Console.WriteLine("The Result is " + res);
        }
        static void LogInfo(LogMessageDelegate message)
        {
            message("Error Occured while reading the record");
        }
        //static void PrintMess(Message method)
        //{
        //    method.
        static void LogToConsole(string message)
        {
            string time = DateTime.Now.ToString("HH-mm-ss");
        }

        static void LogToFile(string message)
            {
       
        
                string DirName = @"C:\Training";
                if (!Directory.Exists(DirName))
                {
                    Directory.CreateDirectory(DirName);
                }
                string time = DateTime.Now.ToString("HH-mm-ss");
                var msg = $"[{time}]:{message}";
                string date = DateTime.Now.ToShortDateString();
                var fullpath = Path.Combine(DirName, $"{date}.txt");
                File.AppendAllText(fullpath, msg);
            }
            //static void LogToEventViewer(string message)
            //{
            //    EventLog log = new EventLog("TrainingLogs", Environment.MachineName, Process.GetCurrentProcess().ProcessName);
            //    log.WriteEntry(message, EventLogEntryType.Information);
            //}

            static void MulticastDelegateExample()
            {
                LogMessageDelegate logger = new LogMessageDelegate(LogToFile);
               // logger += new LogMessageDelegate(LogToEventViewer);
                logger += new LogMessageDelegate(LogToConsole);
                LogInfo(logger);
            }

            static void Main(string[] args)
        {


                MulticastDelegateExample();
        }
        static double AddFunc(double v1, double v2)
        {
            return v1 + v2;
        }
        static double MultiplyFunc(double v1, double v2)
        {
            return v1 * v2;
        }
        //static void Hello()
        //{
        //    Console.WriteLine("Hello world");
        //}
        //static void Bye()
        //{
        //    Console.WriteLine("Bye world");
        //}
    }
}
