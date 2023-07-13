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

        CarDetailsTest(car);
    }

    private static void CarDetailsTest(CarManager car)
    {
        foreach (var c in car.GetCarDetails())
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