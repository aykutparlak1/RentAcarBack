using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {


        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
                _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccesDataResult<User>(_userDal.Get(c => c.Id == userId), Messages.Listed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccesResult(Messages.Updated);
        }


        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccesDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
