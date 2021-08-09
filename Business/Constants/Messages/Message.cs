using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants.Messages
{
    public class Message
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted="Araç silidi";
        public static string Carlisted="Araçlar Listelendi";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string CarUpdated="Araç güncellendi";
        public static string BrandUpdated="Markalar güncellendi";
        public static string BrandAdded="Marka eklendi";
        public static string BrandListed="Markalar listelendi";
        public static string BrandDeleted="Marka Silindi";
        public static string ColorAdded="Renk eklendi";
        public static string ColorDeleted="Renk Silindi";
        public static string ColorListed="Renkler Listelendi";
        public static string ColorUpdated="Renk Güncellendi";
        public static string CarNameInlvalid="Minimum 2 karakterli olmalıdır";
        public static string ICarImagesAdded="Resımler eklendi";
        public static string ICarImagesDeleted="Resımler silindi";
        public static string ICarImagesUpdated="Resımler güncellendi";
        public static string CarImagesListed="Resimler Listelendi";
        public static string CarCountOfCarImagesError="Bir arabanın en fazla beş ürünü olabilir";
        public static string BrandLimitExceded="Maxsimum 15 Marka eklenebilir";
        public static string AuthorizationDenied="yetkiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Giriş Yapıldı";
        public static string RentalAdded="kiralama eklendi";
        public static string RentalDeleted="kiralama silindi";
        public static string RentalListed="kiralama listelendi";
        public static string RentalUpdated="kiralama güncellendi";
        public static string CustomerUpdated="müşteriler güncellendi";
        public static string CustomerListed="müşteriler listelendi";
        public static string CustomerDeleted="müşteriler silindi";
        public static string CustomerAdded="müşteriler eklendi";
        public static string FailedCarImageAdd="Resim Dosyaya Eklendi";
      
    }
}
