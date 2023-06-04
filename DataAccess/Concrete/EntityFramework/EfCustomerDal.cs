using Core.DataAccess.EntityFramework;
using Core.Utulities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cus in context.Customers
                             join r in context.Rentals on cus.CustomerId equals r.CustomerId
                             join u in context.Users on cus.UserId equals u.UserId
                             join b in context.Brands on cus.BrandId equals b.BrandId



                             select new CustomerDetailDto
                             {
                                 CustomerId = cus.CustomerId,
                                 CompanyName = cus.CompanyName,
                                 UserFirstName = u.UserFirstName,
                                 UserLastName = u.UserLastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 BrandName = b.BrandName,
                             };
                return result.ToList();

            }
        }
    }
}
