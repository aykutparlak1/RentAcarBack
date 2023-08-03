using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {

        //Altaki mettot bir extension yanı hazırda bulunan bir kütüphaneye metot ekliyoruz
        //mesela using System.Security.Claims; kütüphanesinden claimleri barındırıyor biz diyoruz ki bu calimlere bir de AddEmail
        //tutan bir metot ekle
        // bu metot Claim nesnesinde key value değerini tutuyor.

        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email)); // JwtRegisteredClaimNames ile ClaimTypes aynı işlemi yapıyor.
            // claims listesi icinde key value seklinde dictionry olustuyor 
            //
        
        }
          
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }


        // burası ise bizim array seklinde yolladıgımız rolleri aynı sekilde tek tek bir claim collection listesine ekliyor
        //Örneğin{{ClaimTypes.Role:"Admin"],{ClaimTypes.Role:"Product.List"}}
        //seklinde listeye aktarır ekler yani
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
