using Core.DataAcces.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(int id)
        {
            using (SqlContext context = new SqlContext)
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             //select new CarDetailDto { CarName = car.CarName, UnitsInStock = p.UnitsInstock };

                return result.ToList();
            }
        }
    }
}
