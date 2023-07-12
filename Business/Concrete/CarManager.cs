using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {


        ICarDal _carService;

        public CarManager(ICarDal carDal)
        {
            _carService = carDal;
        }
        public void Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                Console.WriteLine("Araba ismi 2den büyük olmalıdır");
            }else if (car.DailyPrice<=0)
            {
                Console.WriteLine("Araba Fiyatı 0dan büyük olmalıdır.");
            }
            else
            {
                _carService.Add(car);
            }
        }

        public void Delete(Car car)
        {
           _carService.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carService.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carService.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carService.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carService.Update(car);
            Console.WriteLine(GetAll());
        }
    }
}
