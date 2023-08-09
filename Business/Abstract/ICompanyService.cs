using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.AbstractValidator
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int customerId);
        IResult Update(Company customer);
        IResult Add(Company customer);
        IResult Delete(Company customer);
        IDataResult<Company> GetByName(string companyName);
    }
}
