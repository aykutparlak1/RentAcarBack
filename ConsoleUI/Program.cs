using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        //CarManager car = new CarManager(new EfCarDal());
        //AddCarTest(car);

        //CarDetailsTest(car);
        //UserAddTest();

        RentalManager rentalManager = new RentalManager(new EfRentalsDal());
        Rental rentals = new Rental {CarId=0,CustomerId=1, RentDate=DateTime.Now ,ReturnDate=null};
        Console.WriteLine(rentalManager.Add(rentals).Message);

    }

    private static void UserAddTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());
        User user = new User { CompanyId = 1, FirstName = "Aykut", LastName = "Parlak", Email = "test@test.com", Password = "212321" };
        Console.WriteLine(userManager.Add(user).Message);
    }

    private static void CarDetailsTest(CarManager car)
    {
        var result = car.GetAllCarsDetails();
        foreach (var c in result.Data)
        {
            Console.WriteLine(c.ColorName + "  " + c.BrandName + "  " + c.CarId + "  " + c.ModelYear + "  " + c.CarName);
        }
    }

    private static void AddCarTest(CarManager car)
    {
        Car cars = new Car { BrandId = 2, ColorId = 1, DailyPrice = 50, ModelYear = "2010", Description = "Roll Royce", CarName = "Sevv" };
        car.Add(cars);
    }
}