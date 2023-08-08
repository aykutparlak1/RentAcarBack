using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {

        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company company)
        {
            var result = BusinessRules.Run(CheckCompanyAlreadyExists(company.CompanyName));
            if (result != null)
            {
                return result;
            }
            _companyDal.Add(company);

            return new SuccesResult(Messages.Added);
        }

        public IResult Update(Company company)
        {
            var result = BusinessRules.Run(IfCompanyExists(company.Id));
            if (result != null)
            {
                return result;
            }
            _companyDal.Update(company);

            return new SuccesResult(Messages.Updated);
        }

        public IResult Delete(Company company)
        {
            var result = BusinessRules.Run(IfCompanyExists(company.Id));
            if (result != null)
            {
                return result;
            }
            _companyDal.Delete(company);
            return new SuccesResult(Messages.Added);
        }

        public IDataResult<List<Company>> GetAll()
        {
            var result = _companyDal.GetAll();
            if (result.Count == 0 )
            {
                return new ErrorDataResult<List<Company>>(Messages.CompanyNotFound);
            }
            return new SuccesDataResult<List<Company>>(result, Messages.Listed);
        }

        public IDataResult<Company> GetById(int companyId)
        {
            var result = _companyDal.Get(c => c.Id == companyId);
            if (result == null)
            {
                return new ErrorDataResult<Company>(Messages.CompanyNotFound);
            }
            return new SuccesDataResult<Company>(result, Messages.Listed);
        }
        public IDataResult<Company> GetByName(string companyName)
        {
            var result = _companyDal.Get(c => c.CompanyName == companyName);
            if (result == null)
            {
                return new ErrorDataResult<Company>(Messages.CompanyNotFound);
            }
            return new SuccesDataResult<Company>(result, Messages.Listed);
        }

        private IResult IfCompanyExists(int id)
        {
            var result = GetById(id);
            if (!result.IsSuccess)
            {
                return new ErrorResult(Messages.CompanyNotFound);
            }
            return new SuccesResult();
        }
        private IResult CheckCompanyAlreadyExists(string companyName)
        {
            var result = GetByName(companyName);
            if (!result.IsSuccess)
            {
                return new ErrorResult(Messages.CompanyAlreadtExists);
            }
            return new SuccesResult();
        }
    }
}
