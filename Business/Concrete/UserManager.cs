using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Reflection;

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
            
            var result = BusinessRules.Run(CheckUserAlreadyExists(user.Email));
            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(User user)
        {

            var result = BusinessRules.Run(IfUserExists(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccesResult(Messages.Deleted);
        }
        public IResult Update(User user)
        {
            var result = BusinessRules.Run(IfUserExists(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Update(user);

            return new SuccesResult(Messages.Updated);
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.UserNotFound);
            }
            return new SuccesDataResult<List<User>>(result, Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccesDataResult<User>(_userDal.Get(c => c.Id == userId), Messages.Listed);
        }
        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccesDataResult<User>(result,Messages.UserListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        private IResult CheckUserAlreadyExists(string email)
        {
            var result = GetByEmail(email);
            if (result != null) 
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccesResult();
        }
        private IResult IfUserExists(int id)
        {
            var result = GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccesResult();
        }
    }
}
