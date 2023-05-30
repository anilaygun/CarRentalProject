using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Console.WriteLine("TOGG CRM\n*--------------*");

GetCarDetailsTest();


//AddCarTest();
//UpdateCarTest();
//DeleteCarTest();

/////////////////////////////

//AddBrandTest();
//UpdateBrandTest();
//DeleteBrandTest();

////////////////////

//AddColorTest();
//DeleteColorTest();
//UpdateColorTest();


/// bütün entitylerin operasyonları test edilecek ve en son bütün arabaların çıktısına bakılacak!!!!

Console.WriteLine("\n*--------------*\n");

static void GetCarDetailsTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var cars in carManager.GetCarDetails())
    {

        Console.WriteLine("{0} : {1} / {2} / {3} / {4} => {5} ", cars.CarId, cars.BrandName, cars.ColorName, cars.ModelYear, cars.Description, cars.DailyPrice.ToString("000.00"));
    }
}

static void AddCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Add(new Car { BrandId = 4, ColorId = 2, ModelYear = 2025, DailyPrice = 1500000, Description = "TOGG T40X" });
}
static void UpdateCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Update(new Car { CarId = 4, BrandId = 3, ColorId = 2, ModelYear = 2025, DailyPrice = 1400000, Description = "TOGG T40X" });
    GetCarDetailsTest();
}
static void DeleteCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Delete(new Car { CarId = 5 });
    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine("{0} - {1} - {2} ", car.CarId, car.Description, car.DailyPrice);
    }
}

static void AddBrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Add(new Brand { BrandName = "YENİ TOGG SEDAN" });


}

static void UpdateBrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Update(new Brand { BrandId = 1003, BrandName = "YENİ TOGG YSUV" });
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
    }
}

static void DeleteBrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Delete(new Brand { BrandId = 1002 });
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
    }
}

static void AddColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(new Color { ColorName = "KAPADOKYA" });
    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}

static void DeleteColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Delete(new Color { ColorId = 4 });
    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}

static void UpdateColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Update(new Color { ColorId = 3, ColorName = "KAPADOKYA" });
    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}