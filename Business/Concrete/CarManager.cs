using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }else if (car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.ProductDailyPriceInvalid);
            }
            _carService.Add(car);
            return new SuccesResult(Messages.ProductAdded);

        }

        public IResult Delete(Car car)
        {
           _carService.Delete(car);
            return new SuccesResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carService.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccesDataResult<Car>(_carService.Get(c => c.Id == carId), Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carService.GetAllCarsDetails(), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult< List < Car >> (_carService.GetAll(c => c.BrandId == brandId), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<List<Car>>(_carService.GetAll(c => c.ColorId == colorId), Messages.ProductsListed);
        }

        public IResult Update(Car car)
        {
            _carService.Update(car);
            return new SuccesResult(Messages.ProductUpdated);
        }
    }
}
