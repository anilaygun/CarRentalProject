using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Colors on car.ColorId equals c.ColorId

                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = b.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                             };

                return result.ToList();
            }
        }
    }
}
