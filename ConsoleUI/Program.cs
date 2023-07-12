using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager car = new CarManager(new EfCarDal());
        //AddCarTest(car);

        foreach (var c in car.GetAll())
        {
            Console.WriteLine(c.CarName);
        }
    }

    private static void AddCarTest(CarManager car)
    {
        Car cars = new Car { BrandId = 2, ColorId = 1, DailyPrice = 50, ModelYear = "2010", Description = "Roll Royce", CarName = "Sevv" };
        car.Add(cars);
    }
}