using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.AbstractValidator
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Update(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
