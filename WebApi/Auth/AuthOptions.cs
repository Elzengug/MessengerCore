using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TokenApp
{
    public class AuthOptions
    {
        public const string ISSUER = "MessengerCore"; 
        public const string AUDIENCE = "https://localhost:44364"; 
        const string KEY = "getauthkey_secretkey_key123";  
        public const int LIFETIME = 5; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}