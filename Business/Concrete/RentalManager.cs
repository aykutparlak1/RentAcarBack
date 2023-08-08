using Azure;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalsDal;
        ICarService _carService;
        public RentalManager(IRentalDal rentalsDal, ICarService carService)
        {
            _carService = carService;
            _rentalsDal = rentalsDal;
        }
        [ValidationAspect(typeof(RentACarValidator))]
        public IResult Add(Rental rentals)
        {
            var result = BusinessRules.Run(CheckCarExist(rentals),CheckCarStatus(rentals));
            if (result != null)
            {
                return result;
            }
            IDataResult<Car> carStatus = _carService.GetById(rentals.CarId);
                carStatus.Data.IsActive = true;
                _carService.Update(carStatus.Data);
                _rentalsDal.Add(rentals);
                return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Rental rentals)
        {
            var result = BusinessRules.Run(CheckRentalExists(rentals.Id), IfCarReceived(rentals.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalsDal.Delete(rentals);
            return new SuccesResult(Messages.Deleted);
        }

        public IResult Update(Rental rentals)
        {

            var result = BusinessRules.Run(CheckRentalExists(rentals.Id));
            if (result != null)
            {
                return result;
            }
            _rentalsDal.Update(rentals);

            return new SuccesResult(Messages.Updated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalsDal.GetAll();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalNotFound);
            }
            return new SuccesDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalsId)
        {
            var result = _rentalsDal.Get(c => c.Id == rentalsId);
            if (result == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccesDataResult<Rental>(result, Messages.Listed);
        }

        public IDataResult<RentalsDetailDto> GetRentalsDetailById(int Id)
        {
            var result = _rentalsDal.GetRentalsDetailById(Id);
            if (result == null)
            {
                return new ErrorDataResult<RentalsDetailDto>(Messages.RentalNotFound);
            }
            return new SuccesDataResult<RentalsDetailDto>(result, Messages.Listed);
        }
        private IResult CheckCarExist(Rental rentals)
        {
            var result = _carService.GetById(rentals.CarId);
            if (!result.IsSuccess)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            return new SuccesResult();
        }
        private IResult CheckCarStatus(Rental rentals)
        {
            var result = _carService.GetById(rentals.CarId);
            if (result.Data.IsActive)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }
            return new SuccesResult();
        }


        private IResult CheckRentalExists(int id)
        {
            var result = GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            return new SuccesResult();
        }

        private IResult IfCarReceived(int id)
        {
            var result = _carService.GetById(id);
            if (!result.IsSuccess)
            {
                return new ErrorResult(result.Message);
            }
            else if (result.Data.IsActive)
            {
                return new ErrorResult(Messages.CarNotReceived);
            }
            return new SuccesResult();
        }
    }
}

