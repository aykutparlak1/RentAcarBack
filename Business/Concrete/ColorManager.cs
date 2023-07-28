using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorService;
        public ColorManager(IColorDal colorDal)
        {
            _colorService = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorService.Add(color);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorService.Delete(color);
            return new SuccesResult(Messages.Added);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorService.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccesDataResult<Color>(_colorService.Get(c => c.ColorId == colorId), Messages.ProductListed);
        }

        public IResult Update(Color color)
        {
            _colorService.Update(color);

            return new SuccesResult(Messages.Updated);
        }
    }
}
