using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
	internal class Ex06FileIO
	{
		const string filename = "TestCode.txt";

        static void WriteToFile(string content)
        {
            if (Configuration != null)
            {
                string? fileName = Configuration["FileOptions:FileDir"];
                Console.WriteLine(fileName);
                if (fileName != null)
                {
                    File.AppendAllText(filename, content+"\n");
                }
                else
                {
                    Console.WriteLine("Path is not set,cannot write to file");
                }
            }
        }
		public static IConfigurationRoot? Configuration{get;  private set;}
        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\Fnf Training\\InductionTraining\\ConsoleApp1")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
		static void Main(string[] args)
        {
            Initialize();
            WriteToFile("Content Added Successfully ");
        }
    }
}
