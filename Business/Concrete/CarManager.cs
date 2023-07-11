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
            _carService.Add(car);
        }

        public void Delete(Car car)
        {
           _carService.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carService.GetAll();
        }

        public List<Car> GetById(int carId)
        {
            return _carService.GetById(carId);
        }

        public void Update(Car car)
        {
            _carService.Update(car);
            Console.WriteLine(GetAll());
        }
    }
}
