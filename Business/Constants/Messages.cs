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

        // for brand entities
        public static string AddedBrand = "Model Ekleme Başarılı";
        public static string DeletedBrand = "Model Silme Başarılı";
        public static string UpdatedBrand = "Model Güncelleme Başarılı";

        // for color entities
        public static string AddedColor = "Renk Ekleme Başarılı";
        public static string DeletedColor = "Renk Silme Başarılı";
        public static string UpdatedColor = "Renk Güncelleme Başarılı";

    }
}
