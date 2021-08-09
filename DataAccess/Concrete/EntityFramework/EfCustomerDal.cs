using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : IEfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> customerDetailDtos(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapContext context= new  ReCapContext())
            {
                var result = from customer in filter == null ? context.Customers: context.Customers.Where(filter)
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 UserId = user.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 Email = user.Email,
                                 Status = user.Status,
                                 FindexPoint = customer.FindexPoint
                             };
                return result.ToList();
            }
        }
    }
}
