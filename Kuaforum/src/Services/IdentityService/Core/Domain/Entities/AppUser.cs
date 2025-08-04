using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; } = true;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }


        //    public DateTime? LastLoginDate { get; set; }
        //    public string ProfilePictureUrl { get; set; }

        //    // Kullanıcı Tipi (Müşteri, Kuaför, Admin)
        //    public UserType UserType { get; set; } // Enum kullanmak daha iyi bir pratik olabilir

        //    // Müşteriye Özgü Alanlar
        //    public string CustomerAddress { get; set; } // Müşteri adresi
        //    public DateTime? DateOfBirth { get; set; } // Müşterinin doğum tarihi

        //    // Kuaföre Özgü Alanlar
        //    public string SalonName { get; set; }
        //    public string SalonAddress { get; set; }
        //    public double Latitude { get; set; } // Harita için enlem
        //    public double Longitude { get; set; } // Harita için boylam
        //    public string Description { get; set; } // Salon açıklaması
        //    public TimeSpan OpeningTime { get; set; } // Çalışma başlangıç saati
        //    public TimeSpan ClosingTime { get; set; } // Çalışma bitiş saati
        //    public int AverageRating { get; set; } // Değerlendirme & Yorum Servisinden gelen ortalama puan (Denormalize edilebilir)
        //    public bool AcceptsMen { get; set; } // Erkek müşteri kabul ediyor mu?
        //    public bool AcceptsWomen { get; set; } // Kadın müşteri kabul ediyor mu?

        //    // İlişkisel Veriler (EF Core ile navigasyon property'leri)
        //    // Bir kullanıcının birden fazla randevusu olabilir
        //    // public ICollection<Appointment> Appointments { get; set; }

        //    // Bir kullanıcının birden fazla ürünü olabilir (eğer kendi ürünlerini satıyorsa, ancak projenizde sadece admin satıyor)
        //    // public ICollection<Order> Orders { get; set; } // Müşterinin verdiği siparişler
        //}

        //// UserType Enum'u (örnek)
        //public enum UserType
        //{
        //    Customer,
        //    Hairdresser, // Kuaför/Berber
        //    BeautyCenter, // Güzellik Merkezi
        //    Admin
        //}
    }
}
