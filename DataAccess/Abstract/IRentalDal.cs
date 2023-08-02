using Core.DataAcces;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        RentalsDetailDto GetRentalsDetailById(int Id);
    }
}
