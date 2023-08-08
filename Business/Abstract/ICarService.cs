using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IResult Add(Car car);

        IResult Delete(Car car);


        IResult Update(Car car);

        IDataResult<Car> GetByPlateNumber(string plateNumber);
        IDataResult<List<CarDetailDto>> GetAllCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandAndColorId(int brandId, int colorId);

    }
}
