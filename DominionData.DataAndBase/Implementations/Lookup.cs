using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionData.DataAndBase.Models;

namespace DominionData.DataAndBase
{
	public class Lookup
	{
		public List<AddressTypeModel> AddressType()
		{
			using (var context = new Uow(new DominionDataEntities()))
			{
				var custRepo = context.GetRepo<AddressType>();
				var query = custRepo.GetByIQuerable()
					.Select(s => new AddressTypeModel()
					{
						AddressType1 = s.AddressType1,
						AddressTypeId = s.AddressTypeId
					})
					.ToList();

				return query;
			}
		}
	}
}
