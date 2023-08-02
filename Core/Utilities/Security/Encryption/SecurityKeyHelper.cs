using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));// gelen security anahtarını utf8 karakter diziliminde byte dizisine ceviriyor bu bu dizi 
            // bu dizi yani anahtar token doğrulamasına veya şifrelenmesinde kulanılıyor.
        }
    }
}
