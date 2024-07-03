using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Data
{
	interface ICustomerRepo
	{
		void AddNewCustomer(Customer cst);
		void DeleteCustomer(int cstId);
		void UpdateCustomer(Customer cst);

		List<Customer> GetAllCustomer();
	}

	class CsvCustomerRepo : ICustomerRepo
	{
		private readonly string filename;
		public CsvCustomerRepo()
		{
			Ex06FileIO.Initialize();
			filename = Ex06FileIO.Configuration["FileOptions:CsvPath"];
		}


		public void AddNewCustomer(Customer cst)
		{
			if (filename == null) {
				throw new NotImplementedException("Filepath is not set,refer configuration");
				}
			File.AppendAllText(filename,cst.ToString());
		}

		public void DeleteCustomer(int cstId)
		{
			throw new NotImplementedException();
		}

		public List<Customer> GetAllCustomer()
		{
			List<Customer> list = new List<Customer>();
			if (filename == null)
			{
				throw new Exception("File is not set,Data cannot be read,refer the Configuration file");
			}
			var lines = File.ReadAllLines(filename);
			foreach (var line in lines)
			{
				if (string.IsNullOrEmpty(line))
				{
					return list;
				}
				var words = line.Split(' ');
				Customer cst = new Customer();
				cst.BillDate = DateTime.Parse(words[0]);
				cst.CustomerId = int.Parse(words[1]);
				cst.CustomerName = words[2];
				cst.CustomerAddress = words[3];
				cst.BillAmount = int.Parse(words[4]);

				list.Add(cst);
			}
			return list;
		}

		public void UpdateCustomer(Customer cst)
		{
			throw new NotImplementedException();
		}
	}
}
