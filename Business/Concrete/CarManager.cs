using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Drawing;

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

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id)
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carService.GetCarsDetailsByColorId(id),Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carService.GetCarsDetailsByBrandAndColorId(brandId, colorId), Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id)
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carService.GetCarsDetailsByBrandId(id), Messages.ProductListed);
        }
    }
}
