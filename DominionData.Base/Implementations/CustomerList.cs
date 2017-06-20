using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionData.Base.Interfaces;

namespace DominionData.Base.Implementations
{
	public class CustomerList 
	{
		public List<CustomerModel> GetAll()
		{
			using (var context = new Uow(new Context.DominionDataEntities()))
			{
				var custRepo = context.GetRepo<Context.Customer>();
				var query = custRepo.GetByIQuerable()
					.Select(s => new CustomerModel()
					{
						CustomerId = s.CustomerId,
						FirstName = s.FirstName,
						LastName = s.LastName,
					})
					.ToList();

				return query;
			}
		}
	}
}
