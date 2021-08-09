using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IEfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             select new CarDetailDto
                             {
                                 CarId = p.Id,
                                 BrandName = c.BrandName,
                                 CarName = p.CarName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 ImagePath = (from i in context.CarImages where i.CarId == p.Id select i.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }
    }
}
