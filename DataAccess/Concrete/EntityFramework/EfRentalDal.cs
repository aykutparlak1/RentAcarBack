using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlContext>, IRentalDal
    {
        public RentalsDetailDto GetRentalsDetailById(int Id)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from rental in context.Rentals
                             where rental.Id == Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join user in context.Users on rental.UserId equals user.Id
                             join customer in context.Customers on  rental.CustomerId equals customer.Id
                             select new RentalsDetailDto {
                                 RentalId = rental.Id, IsActive = rental.IsActive,
                                 UserName =user.FirstName,UserEmail=user.Email, UserLastName=user.LastName,
                                 CarName = car.CarName, CarDescription = car.Description, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice,
                                 CompanyName = customer.CompanyName,
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
