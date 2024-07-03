using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Ex05ListsWithDelegates
	{

        static void Main(string[] args)
        {
            List<string> list = new List<string>
            {
                "Apples","mangoes","tomatos","Oranges","Pineapples"
            };
            Console.WriteLine("Enter the item to find");
            string selected=Console.ReadLine();
            //var found=list.Find(delegate (string arg)
            //{
            //    return arg.Contains( selected);
            //});
            var found=list.Find(e=>e.Contains(selected));
            Console.WriteLine("The  found element is "+found);

            var find=list.FindAll(item=>item.Contains(selected));
            Console.WriteLine("These are other matched items");
            foreach (var item in find)
            {
                Console.WriteLine(item);
            }

        }
    }
}
