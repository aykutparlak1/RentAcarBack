using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal: EfEntityRepositoryBase<Company,SqlContext>, ICompanyDal
    {
    }
}
