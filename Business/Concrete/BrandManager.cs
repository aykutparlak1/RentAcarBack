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
    public class BrandManager : IBrandService
    {

        IBrandDal _brandService;
        public BrandManager(IBrandDal brandDal)
        {
            _brandService = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandService.Add(brand);
            
            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandService.Delete(brand);
            return new SuccesResult(Messages.Added);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandService.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandService.Get(b=> b.BrandId == brandId), Messages.ProductListed);
        }

        public IResult Update(Brand brand)
        {
            _brandService.Update(brand);

            return new SuccesResult(Messages.Updated);
        }
    }
}
