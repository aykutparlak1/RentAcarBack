using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Core.Utilities.Security.Encryption;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Core.Extensions;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get;}
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key:"TokenOptions").Get<TokenOptions>();//Burası wepapi icindeki configuration bölümünden GetSection(key:"TokenOptions") bilgilerini alıp  .Get<TokenOptions>() ile TokenOptionsa mapliyor objesine dönüştürüyor 
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //token süresini alıyor ve şuanki sürenin üzerine dakika cinsinden ekliyor
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //security keyi symmetrickey byte dizisi olarak olusturyor
            var signinCredentials = SigningCredentialsHelper.CreateSigninCredentials(securityKey); // olusan security keyi hash256 algoritması ile haslıyor ve imza olusturuyor
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,signinCredentials, operationClaims); 
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken { Token = token, Expiration=_accessTokenExpiration};
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                //Bu, oluşturulan JWT'nin "issuer" alanını (iss alanı) belirtir. JWT, kimlik doğrulayan veya JWT'yi oluşturan tarafın adını veya URL'sini içerir.
                audience: tokenOptions.Audience,
                //Bu, oluşturulan JWT'nin "audience" alanını (aud alanı) belirtir. JWT, hangi alıcıların bu JWT'yi kabul ettiğini ifade eder.
                expires: _accessTokenExpiration,
                //Bu, oluşturulan JWT'nin ne zamana kadar gecerli olacağını belirtir.
                notBefore: DateTime.Now,
                //Bu, oluşturulan JWT'nin "notBefore" alanını (nbf alanı) belirtir. JWT, bu tarihten önce kabul edilmemelidir. bu sayae hiç olusturulmamıs bir token doğrulanmaz
                claims: SetClaims(user,operationClaims),
                //Bu, SetClaims metodunu kullanarak JWT'nin "claims" alanını (claim alanı) belirtir. Bu kısım, kullanıcıya özel JWT taleplerini ve yetkilendirmelerini içerebilir.
                signingCredentials: signingCredentials
                //Bu, daha önce oluşturulan JWT imza bilgisini belirtir.JWT'nin doğrulanması için bu imza kullanılacak.
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>(); //Claim listesi olusturuyor

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());
            return claims;

        }
    }
}
