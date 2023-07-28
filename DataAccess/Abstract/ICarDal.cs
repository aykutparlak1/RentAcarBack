using Core.DataAcces;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarsDetails();
        List<CarDetailDto> GetCarsDetailsByColorId(int id);
        List<CarDetailDto> GetCarsDetailsByBrandId(int id);
        List<CarDetailDto> GetCarsDetailsByBrandAndColorId(int brandId, int colorId);
    }
}
