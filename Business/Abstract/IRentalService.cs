using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {

        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalsId);
        IResult Update(Rental rentals);
        IResult Add(Rental rentals);
        IResult Delete(Rental rentals);
        
        IDataResult<List<RentalsDetailDto>> GetRentalsDetailById(int Id);

    }
}
