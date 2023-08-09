using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.AbstractValidator
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
        IDataResult<Color> GetByName(string colorName);
        IResult Update(Color color);
        IResult Add(Color color);
        IResult Delete(Color color);
    }
}
