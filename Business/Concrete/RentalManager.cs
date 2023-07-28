using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalsService;
        ICarService _carService;
        public RentalManager(IRentalDal rentalsDal, ICarService carService)
        {
            _carService = carService;
            _rentalsService = rentalsDal;
        }
        [ValidationAspect(typeof(RentACarValidatör))]
        public IResult Add(Rental rentals)
        {
            IResult result = BusinessRules.Run(CheckCarStatus(rentals));
            if (result != null)
            {
                return result;
            }
            IDataResult<Car> carStatus = _carService.GetById(rentals.CarId);
            if (carStatus.IsSuccess) {
                carStatus.Data.IsActive = true;
                _carService.Update(carStatus.Data);
                _rentalsService.Add(rentals);
                return new SuccesResult(Messages.Added);
            }

            return new ErrorResult(Messages.RentError);
        }

        public IResult Delete(Rental rentals)
        {
            _rentalsService.Delete(rentals);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalsService.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalsId)
        {
            return new SuccesDataResult<Rental>(_rentalsService.Get(c => c.Id == rentalsId), Messages.Listed);
        }

        public IDataResult<List<RentalsDetailDto>> GetRentalsDetailById(int Id)
        {
            return new SuccesDataResult<List<RentalsDetailDto>>(_rentalsService.GetRentalsDetailById(Id), Messages.Listed);
        }

        public IResult Update(Rental rentals)
        {
            _rentalsService.Update(rentals);

            return new SuccesResult(Messages.Updated);
        }
        private IResult CheckCarStatus(Rental rentals)
        {
            var result = _carService.GetById(rentals.CarId).Data.IsActive;
            if (result)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }
            return new SuccesResult();
        }
    }
}

