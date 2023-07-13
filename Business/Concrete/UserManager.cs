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
    public class UserManager : IUserService
    {


        IUserDal _userService;
        public UserManager(IUserDal userDal)
        {
                _userService = userDal;
        }
        public IResult Add(User user)
        {
            _userService.Add(user);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userService.Delete(user);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userService.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccesDataResult<User>(_userService.Get(c => c.Id == userId), Messages.Listed);
        }

        public IResult Update(User user)
        {
            _userService.Update(user);

            return new SuccesResult(Messages.Updated);
        }
    }
}
