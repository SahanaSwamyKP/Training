using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Data;
using ConsoleApp1.Entities;

namespace ConsoleApp1
{
	internal class Ex08CsvFileIO
	{
        static void Main(string[] args)
        {
			//testAddingCsvFile();
			testReadingFile();
        }

		private static void testReadingFile()
		{
			ICustomerRepo repo = new CsvCustomerRepo();
			var cust = repo.GetAllCustomer();
            foreach (var item in cust)
            {
                Console.WriteLine($"Mr/Mrs {cust.CustomerName} purchased products with us for an amount of Rs.{cust.BillAmount}on {cust.CustomerAddress}");

            }
        }

		private static void testAddingCsvFile()
		{
			ICustomerRepo repo=new CsvCustomerRepo();
			var cst = new Customer { CustomerId = 10, CustomerAddress = "Bangalore", CustomerName = "Suman" };
			cst.AddCart(new Product { Id = 12, Name = "Toor Dhal", Price = 200, quantity = 3 });
			cst.AddCart(new Product { Id = 13, Name = "Moon Dhal", Price = 20, quantity = 5 });
			repo.AddNewCustomer( cst );

		}
	}
}
