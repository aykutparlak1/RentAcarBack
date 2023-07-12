using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            { 
                new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2000",Description= "Mercedess"   },
                new Car {Id=2,BrandId=3,ColorId=12,DailyPrice=101,ModelYear="2002",Description= "Audi"   },
                new Car {Id=3,BrandId=3,ColorId=13,DailyPrice=103,ModelYear="2003",Description= "Audi"   },
                new Car {Id=4,BrandId=2,ColorId=11,DailyPrice=50,ModelYear="2010",Description="Roll Royce"}
            };
        }







        public void Add(Car car)
        {
           _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _car.SingleOrDefault(c=>c.Id == car.Id);
            _car.Remove(cartoDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carUpdate = _car.SingleOrDefault(c => c.Id == car.Id);

            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ModelYear = car.ModelYear;   
            carUpdate.Description = car.Description;
            carUpdate.ModelYear=car.ModelYear;
            carUpdate.BrandId = car.BrandId;
        }
    }
}
