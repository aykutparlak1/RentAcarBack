using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlContext>, IRentalDal
    {
        //public RentalsDetailDto GetRentalsDetailById(int Id)
        //{
        //    using (SqlContext context = new SqlContext())
        //    {
        //        var result = from rental in context.Rentals
        //                     join car in context.Cars on rental.CarId equals car.Id
        //                     join customer in context.Customers on rental.CustomerId equals customer.Id
        //                     select new RentalsDetailDto { RentalId = rental.Id, CarName = car.CarName, CarDescription = car.Description, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice, CustomerName = customer.CompanyName };

        //         return result;
        //    }
        //}
    }
}
