using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionData.Base
{
	public class CustomerModel
	{
		public CustomerModel()
		{
			//this.CustomerAddresses = new HashSet<CustomerAddress>();
		}

		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		
		//public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
	}
}
