using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionData.DataAndBase.Models
{
	public class AddressTypeModel
	{
		
		public AddressTypeModel()
		{
			//this.CustomerAddresses = new HashSet<CustomerAddress>();
		}

		public int AddressTypeId { get; set; }
		public string AddressType1 { get; set; }

		
		//public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
	}
}
