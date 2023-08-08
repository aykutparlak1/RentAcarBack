using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
        IDataResult<Brand> GetByName(string brandName);
        IResult Update(Brand brand);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
    }
}
