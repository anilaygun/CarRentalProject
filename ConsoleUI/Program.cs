using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Console.WriteLine("ARAÇ ÖZELLİKLERİ\n------------");

CarManager carManager = new CarManager(new EfCarDal());

//carManager.Add(new Car() { BrandId = 3, ColorId = 1, ModelYear = 2024, DailyPrice = 1500000, Description = "YENİ MODEL SİPARİŞ" });
foreach (var cars in carManager.GetAll())
{

    Console.WriteLine("{0} / {1} / {2} =>{3} ", cars.Id, cars.ModelYear, cars.Description, cars.DailyPrice.ToString("000.00"));
}
Console.WriteLine("\n-FİNİSH-");