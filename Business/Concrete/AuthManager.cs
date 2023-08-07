using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private ITokenHelper _tokenHelper;
        private IUserService _userService;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesToken=  _tokenHelper.CreateToken(user,claims.Data);
            return new SuccesDataResult<AccessToken>(accesToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)

        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            BusinessRules.Run(VerifyEmail(userForLoginDto, userToCheck.IsSuccess),VerifyPassword(userForLoginDto, userToCheck.Data));

            return new SuccesDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }


        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            BusinessRules.Run(CheckUserExists(userForRegisterDto.Email));
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash,out passwordSalt);
            var user = new User
            {
                Email= userForRegisterDto.Email,
                FirstName= userForRegisterDto.FirstName,
                LastName= userForRegisterDto.LastName,
                PasswordHash= passwordHash,
                PasswordSalt= passwordSalt,
                Status=true
            };
            _userService.Add(user);
            return new SuccesDataResult<User>(user,Messages.UserRegistered);
        }
        public IDataResult<User> VerifyEmail(UserForLoginDto userForLoginDto,bool userToCheck)
        {
            if (userToCheck == false)
            {
                return new ErrorDataResult<User>(Messages.UnSuccessfulLogin);
            }
            return new SuccesDataResult<User>();
        }
        public IDataResult<User> VerifyPassword(UserForLoginDto userForLoginDto, User user)
        {

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.UnSuccessfulLogin);
            }
            return new SuccesDataResult<User>();
        }

        public IResult CheckUserExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccesResult();
        }
    }
}
