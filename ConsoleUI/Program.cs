using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Console.WriteLine("TOGG CRM\n*--------------*");

//GetCarDetailsTest();


//AddCarTest();
UpdateCarTest();
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
    var result = carManager.GetCarDetails();
    if (result.Success == true)
    {
        foreach (var cars in result.Data)
        {
            Console.WriteLine("{0} : {1} / {2} / {3} / {4} => {5} ", cars.CarId, cars.BrandName, cars.ColorName, cars.ModelYear, cars.Description, cars.DailyPrice.ToString("000.00"));

        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}

static void AddCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = 2025, DailyPrice = 1200000, Description = "TOGG A50T" });

    if (result.Success == true)
    {
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine("{0} - {1} - {2} ", car.CarId, car.Description, car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }


}
static void UpdateCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.Update(new Car { CarId = 2005, BrandId = 3, ColorId = 2, ModelYear = 2025, DailyPrice = 900000, Description = "TOGG V10I" });
    if (result.Success == true)
    {
        GetCarDetailsTest();
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}
static void DeleteCarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.Delete(new Car { CarId = 2004 });
    if (result.Success == true)
    {
        foreach (var car in carManager.GetAll().Data)
        {
            Console.WriteLine("{0} - {1} - {2} ", car.CarId, car.Description, car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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
    var result = brandManager.GetAll();
    foreach (var brand in result.Data)
    {
        Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
    }
}

static void DeleteBrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Delete(new Brand { BrandId = 1002 });
    var result = brandManager.GetAll();
    foreach (var brand in result.Data)
    {
        Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
    }
}

static void AddColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(new Color { ColorName = "KAPADOKYA" });
    var result = colorManager.GetAll();
    foreach (var color in result.Data)
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}

static void DeleteColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Delete(new Color { ColorId = 4 });
    var result = colorManager.GetAll();
    foreach (var color in result.Data)
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}

static void UpdateColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Update(new Color { ColorId = 3, ColorName = "KAPADOKYA" });
    var result = colorManager.GetAll();
    foreach (var color in result.Data)
    {
        Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
    }
}