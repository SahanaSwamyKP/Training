using System;
using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;

namespace ConsoleApp1
{
	internal class Ex07CustomerIO
	{
		static void WriteCustomerInfo(Customer cst)
		{
			try
			{
				var filename = Ex06FileIO.Configuration?["FileOptions:FileDir"];
				File.AppendAllText(filename, cst.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		  static void Main(string [] args)
			{
				Ex06FileIO.Initialize();
				Customer cst = new Customer { CustomerAddress = "Bangalore", CustomerId = 10, CustomerName = "Sadana" };
				cst.AddCart(new Product
				{
					Id = 1,
					Name = "Ear phone",
					Price = 10,
					quantity = 1
				});
				cst.AddCart(new Product
				{
					Id = 2,
					Name = "fruits",
					Price = 20,
					quantity = 1
				});
				cst.AddCart(new Product
				{
					Id = 3,
					Name = "Honey",
					Price = 30,
					quantity = 1
				});
				WriteCustomerInfo(cst);
			}





			}
}
