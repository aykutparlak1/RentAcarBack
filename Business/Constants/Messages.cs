using Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {


        public static string Added = " Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = " Güncellendi";
        public static string Listed = " Listelendi";
        public static string ErrorAdd = " eklenemedi";


        public static string MaintenanceTime = "Sistem Bakımda.";

        public static string BrandAlreadyExists = "Bu marka zaten mevcut";
        public static string BrandNotFound = "Marka Bulunamadı.";


        public static string AuthorizationDenied = "Yetkiniz yetersiz.";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UnSuccessfulLogin = "Email veya şifreyi kontrol ediniz.";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserClaims = "Kullanıcı yetkileri Listelendi";
        public static string UserNotFound = "Kullancı Bulunamadı";


        public static string CarNotFound = "Araba Bulunamadı.";
        public static string CarAlreadyRented = "Araba zaten kirada.";

        public static string RentError ="Araba kiralanamadı";

        public static string CarAlreadyExists = "Araba zaten var.";
        public static string PlateNumberAlreadyExists= "Bu plakaya sahip bir araç zaten sistemde kayıtlı.";




        public static string ColorNotFound="Renk Bulunamadı.";
        public static string ColorAlreadyExists="Renk zaten var";
        public static string CompanyNotFound= "Şirket bulunamadı";
        public static string CompanyAlreadtExists = "Bu şirket zaten var.";

        public static string RentalNotFound = "Kiralama Bulunamadı";


        public static string CarNotReceived = "Araba Teslim Edilmedi";
    }
}
