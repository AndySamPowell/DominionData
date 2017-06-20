using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionData.DataAndBase;
namespace DominionData.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program();
		}

		public Program()
		{
			var cust = new CustomerList();
			var custList = cust.GetAll();

			var look = new Lookup();
			var at = look.AddressType();

		}


	}
}
