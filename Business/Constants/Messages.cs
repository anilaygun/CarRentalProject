using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // for car entities
        public static string AddedCar = "Araba Ekleme Başarılı";
        public static string CarNameInvaled = "Araba Ekleme Başarısız Oldu!";
        public static string DeletedCar = "Araba Silme Başarılı";
        public static string UpdatedCar = "Araba Güncelleme Başarılı";
        public static string ListedCar = "Araba Listeleme Başarılı";
        public static string FailListedCar = "Araba Listeleme Başarısız Oldu!";
        public static string ListedCarByColorId = "Renk Kimlik Numarasına Göre Araba Listeleme Başarılı";
        public static string ListedCarByBrandId = "Model Kimlik Numarasına Göre Araba Listeleme Başarılı";

        // for brand entities
        public static string AddedBrand = "Model Ekleme Başarılı";
        public static string DeletedBrand = "Model Silme Başarılı";
        public static string UpdatedBrand = "Model Güncelleme Başarılı";
        public static string ListedBrand = "Model Listeleme Başarılı";

        // for color entities
        public static string AddedColor = "Renk Ekleme Başarılı";
        public static string DeletedColor = "Renk Silme Başarılı";
        public static string UpdatedColor = "Renk Güncelleme Başarılı";
        public static string ListedColor = "Renk Listeleme Başarılı";

        // for Rental entities
        public static string ListedRental = "Kiralama Listeleme Başarılı";
        public static string AddedRental = "Kiralama Ekleme Başarılı";
        public static string DeletedRental = "Kiralama Silme Başarılı";
        public static string UpdatedRental = "Kiralama Güncelleme Başarılı";

        // for Customer entities
        public static string ListedCustomer = "Müşteri Listeleme Başarılı";
        public static string ListedDetailCustomer = "Müşteri Detay Listeleme Başarılı";
        public static string AddedCustomer = "Müşteri Ekleme Başarılı";
        public static string DeletedCustomer = "Müşteri Silme Başarılı";
        public static string UpdatedCustomer = "Müşteri Güncelleme Başarılı";

        // for User entities
        public static string ListedUser = "Müşteri Listeleme Başarılı";
        public static string UserNameInvalıd = "Kullanıcı Ekleme Başarısız Oldu!";
        public static string AddedUser = "Kullanıcı Ekleme Başarılı";
        public static string DeletedUser = "Kullanıcı Silme Başarılı";
        public static string UpdatedUser = "Kullanıcık Güncelleme Başarılı";
    }
}
