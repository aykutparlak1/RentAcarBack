using Business.AbstractValidator;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cache;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {


        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }


        [SecuredOperation("Car.Add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckPlateNumber(car.PlateNumber));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccesResult(Messages.Added);

        }
        [SecuredOperation("Car.Delete")]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(IfCarExists(car.Id));
            if (result != null)
            {
                return result;
            }
            _carDal.Delete(car);
            return new SuccesResult(Messages.Deleted);
        }

        [SecuredOperation("Car.Update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(IfCarExists(car.Id));
            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccesResult(Messages.Updated);
        }
        [CacheAspect]
        public IDataResult<Car> GetByPlateNumber(string plateNumber)
        {
            var result = _carDal.Get(c=>c.PlateNumber==plateNumber);
            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccesDataResult<Car>(result);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result.Count == 0)
            { 
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<Car>>(result,Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccesDataResult<Car>(result, Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            var result = _carDal.GetAllCarsDetails();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(), Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccesDataResult< List<Car>> (result, Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<Car>>(result, Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id)
        {
            var result = _carDal.GetCarsDetailsByColorId(id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<CarDetailDto>>(result, Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandAndColorId(int brandId, int colorId)
        {
            var result = _carDal.GetCarsDetailsByBrandAndColorId(brandId, colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByBrandAndColorId(brandId, colorId), Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id)
        {
            var result = _carDal.GetCarsDetailsByBrandId(id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByBrandId(id), Messages.Listed);
        }


        private IResult CheckPlateNumber(string plateNumber)
        {
            var result = _carDal.Get(c => c.PlateNumber == plateNumber);
            if (result != null)
            {
                return new ErrorResult(Messages.PlateNumberAlreadyExists);
            }
            return new SuccesResult();
        }
        private IResult IfCarExists(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            return new SuccesResult();
        }
    }
}
