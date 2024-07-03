using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
	class Product
	{
		public string Name { get; set; }=string.Empty;
		public int Id { get; set; }
		public int Price { get; set; }

		public int quantity { get; set; }
	}
	internal class Customer

	{
		public DateTime BillDate{ get; set; }=DateTime.Now;
		private List<Product> products = new List<Product>();
		public string CustomerName { get; set; }= string.Empty;
		public int CustomerId { get; set; }
		public string CustomerAddress { get; set; }= string.Empty;

		public int BillAmount { get; set; }

		private void GenerateBill()
		{
			var amount = 0;
			foreach (var item in products)
			{
				amount += item.Price * item.quantity;
			}
            BillAmount=amount;
		}
		public void AddCart(Product product)
		{
			if (product == null)
			{
				throw new Exception("Product details are not set");
			}
			products.Add(product);
			GenerateBill();
		}
		public void RemoveCart(Product product) {
			if (!products.Remove(product))
				throw new Exception("Product not found to remove");
		}

		public override string ToString()
		{
			//return $"Name:{CustomerName}\nCustomer Address: {CustomerAddress}\n BillDate:{BillDate}\n BillAmount:{BillAmount}\n\n";
			return $"{BillDate.ToString("dd/MM/yyyy")},{CustomerId},{CustomerName},{CustomerAddress},{BillAmount}\n";
		}

	}
}
