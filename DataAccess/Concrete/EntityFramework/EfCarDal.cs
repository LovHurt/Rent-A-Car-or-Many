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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarTableContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarTableContext context = new CarTableContext())
            {
                var result = from c in context.Car
                    join b in context.Brand
                        on c.BrandId equals b.BrandId
                    join cl in context.Color
                        on c.ColorId equals cl.ColorId
                    select new CarDetailDto
                    {
                        CarId = c.CarId, Description = c.Description, BrandName = b.BrandName, ModelYear = c.ModelYear,
                        ColorName = cl.ColorName
                    };
                return result.ToList();
            }
        }
    }
}

