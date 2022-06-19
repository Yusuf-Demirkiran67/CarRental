using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = (from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join clr in context.Colors
                              on c.ColorId equals clr.Id
                              select new CarDetailDto
                              {
                                  BrandId = b.Id,
                                  ColorId = clr.Id,
                                  BrandName = b.Name,
                                  ColorName = clr.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear


                              }).ToList();

                return result;
            }


        }
    }
}
