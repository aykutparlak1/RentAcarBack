using Business.AbstractValidator;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cache;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("Brand.Add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService")]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckBrandExists(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            
            return new SuccesResult(Messages.Added);
        }



        [SecuredOperation("Brand.Delete")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(IfBrandNotExists(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Delete(brand);
            return new SuccesResult(Messages.Added);
        }


        [SecuredOperation("Brand.Update")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(IfBrandNotExists(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);

            return new SuccesResult(Messages.Updated);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandNotFound);
            }
            return new SuccesDataResult<List<Brand>>(result,Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(b => b.BrandId == brandId);
            if (result==null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccesDataResult<Brand>(result, Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<Brand> GetByName(string brandName)
        {
            var result = _brandDal.Get(b => b.BrandName == brandName);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccesDataResult<Brand>(result, Messages.Listed);
        }



        private IResult CheckBrandExists(Brand brand)
        {
            var result = GetByName(brand.BrandName);
            if (result.IsSuccess)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }
            return new SuccesResult();
        }

        private IResult IfBrandNotExists(Brand brand)
        {
            var result = GetById(brand.BrandId);
            if (!result.IsSuccess)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            return new SuccesResult();
        }



    }
}
