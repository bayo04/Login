using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        // metoda za registraciju
        [HttpPost]
        [Route("[action]")]
        public bool Register(string username, string password)
        {
            // https://stackoverflow.com/questions/19605150/regex-for-password-must-contain-at-least-eight-characters-at-least-one-number-a
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{4,}$");

            Match match = regex.Match(password);
            // ako lozinka nije dobra ili ako je username zauzet onda vraća false
            if (!match.Success || !FileHelper.CheckUsername(username))
            {
                return false;
            }
            var passwordHashed = HashHelper.GetHashString(password);
            var salt = GenerateSalt();
            var passwordHashedSalt = HashHelper.GetHashString(password + salt);
            var passwordHashedPepper = HashHelper.GetHashString(password + FileHelper.GetPepperValue());

            User user = new User
            {
                UserName = username,
                PwdHash = passwordHashed,
                PwdHashSalt = passwordHashedSalt,
                PwdHashPepper = passwordHashedPepper,
                Salt = salt
            };
            FileHelper.StoreUser(user);

            return true;
        }

        // generira sol (nekoliko random znakova)
        private string GenerateSalt()
        {
            var value = "";
            while (true)
            {
                var random = new RNGCryptoServiceProvider();

                // Maximum length of salt
                int max_length = 32;

                // Empty salt array
                var salt = new byte[max_length];

                // Build the random bytes
                random.GetNonZeroBytes(salt);

                value = Convert.ToBase64String(salt);

                // ako sol sadrži zarez, stvarat će probleme u bazi tako da je najbolje da se ponovno generira sol bez zareza
                if (value.Contains(','))
                {
                    continue;
                }
                break;
            }


            // Return the string encoded salt
            return value;
        }

        // metoda za prijavu običnim hashom
        [HttpPost]
        [Route("[action]")]
        public bool Login(string username, string hash)
        {
            return FileHelper.CheckLogin(username, hash, "login");
        }

        // metoda za prijavu hashom sa soli
        [HttpPost]
        [Route("[action]")]
        public bool LoginSalt(string username, string hash)
        {
            return FileHelper.CheckLogin(username, hash, "salt");
        }

        // metoda za prijavu hashom sa paprom
        [HttpPost]
        [Route("[action]")]
        public bool LoginPepper(string username, string hash)
        {
            return FileHelper.CheckLogin(username, hash, "pepper");
        }

        // metoda za dohvaćanje salta od nekog korisnika
        [HttpPost]
        [Route("[action]")]
        public string GetSalt(string username)
        {
            return FileHelper.GetSalt(username);
        }
    }
}
