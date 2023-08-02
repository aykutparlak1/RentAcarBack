using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarsDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                  var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto { CarId = car.Id, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int id)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where car.BrandId == id
                             select new CarDetailDto { CarId = car.Id, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandAndColorId(int brandId,int colorId)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where car.ColorId == colorId && car.BrandId == brandId
                             select new CarDetailDto { CarId = car.Id, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int id)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where car.ColorId == id
                             select new CarDetailDto { CarId = car.Id, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };
                return result.ToList();
            }
        }
    }
}
