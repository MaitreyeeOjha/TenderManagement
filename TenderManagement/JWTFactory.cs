using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TenderManagement
{
    public class JWTFactory
    {
        private const string communicationKey = "This is Authenticated from API";
        SecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));


        // The Method is used to generate token for user
        public string GenerateTokenForUser(string userName, int userId)
        {
           
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(signingKey,
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "self",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddYears(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;

        }

        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuers = new string[]
                  {
                      "self",
                  },
                IssuerSigningKey = signingKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {

                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;

            }

            return validatedToken as JwtSecurityToken;

        }

    }
}
