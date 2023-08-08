using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckColorAlreadyExists(color.ColorName));
            if (result != null)
            {
                return result;
            }
            _colorDal.Add(color);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            var result = BusinessRules.Run(IfColorExists(color.ColorId));
            if (result != null)
            {
                return result;
            }
            _colorDal.Delete(color);
            return new SuccesResult(Messages.Added);
        }
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(IfColorExists(color.ColorId));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);

            return new SuccesResult(Messages.Updated);
        }
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
            return new SuccesDataResult<List<Color>>(result, Messages.Listed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(b => b.ColorId == colorId);
            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccesDataResult<Color>(result, Messages.Listed);
        }

        public IDataResult<Color> GetByName(string colorName)
        {
            var result = _colorDal.Get(b => b.ColorName == colorName);
            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccesDataResult<Color>(result, Messages.Listed);
        }

        private IResult CheckColorAlreadyExists(string colorName)
        {
            var result = _colorDal.Get(c=>c.ColorName==colorName);
            if (result != null) {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            return new SuccesResult();
        }
        private IResult IfColorExists(int id)
        {
           var result = GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            return new SuccesResult();
        }

    }
}
