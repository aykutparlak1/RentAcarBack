using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalsService;
        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsService = rentalsDal;
        }
        public IResult Add(Rental rentals)
        {

            _rentalsService.Add(rentals);

            return new SuccesResult(Messages.Added);
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
    }
}

