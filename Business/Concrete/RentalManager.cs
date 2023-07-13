using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalsDal _rentalsService;
        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsService = rentalsDal;
        }
        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate==null)
            {
                return new ErrorResult(Messages.ErrorAdd);
            }
            _rentalsService.Add(rentals);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsService.Delete(rentals);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccesDataResult<List<Rentals>>(_rentalsService.GetAll(),Messages.Listed);
        }

        public IDataResult<Rentals> GetById(int rentalsId)
        {
            return new SuccesDataResult<Rentals>(_rentalsService.Get(c => c.Id == rentalsId), Messages.Listed);
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsService.Update(rentals);

            return new SuccesResult(Messages.Updated);
        }
    }
}

