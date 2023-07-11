using Business.Concrete;
using DataAccess.Concrete.InMemory;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager car =new CarManager(new InMemoryCarDal());
        Console.WriteLine(car.GetById(1).ToList());

    }
}