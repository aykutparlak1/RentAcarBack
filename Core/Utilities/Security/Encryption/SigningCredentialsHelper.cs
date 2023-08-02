using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //bu kod, belirtilen securityKey ile HMAC - SHA256 algoritmasını kullanarak JWT'nin imzalanması için gerekli olan SigningCredentials nesnesini döndürür.
            //Bu SigningCredentials nesnesi, JWT'nin oluşturulması sırasında kullanılacak ve JWT'nin doğrulanması sırasında doğrulama işlemlerine yardımcı olacaktır.
        }
    }
}
