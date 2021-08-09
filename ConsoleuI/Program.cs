using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleuI
{
    //SOLID
    //Open Closed Principle:yaptıgın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));
            var result = carManager.GetAll();
            if (result.Success==true)
            {
               foreach (var car in result.Data)
               {
                Console.WriteLine(car.CarName);
               }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        
        }
    }
}
