using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using QuestStore.Data;

namespace QuestStore.Models
{
    public class Password
    {
        // TODO: maybe make it more OOP not static...?

        // generate salt and hashed password
        // TODO: add to controller to generate hash when user is registered
        public static (byte[], string) HashPassword(string userPassword)
        {
            var salt = new byte[10];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed =
                Convert.ToBase64String(KeyDerivation.Pbkdf2(userPassword, salt, KeyDerivationPrf.HMACSHA1, 1000,
                    256 / 8));
            return (salt, hashed);
        }


        // compare password stored in db with just given
        // TODO: need to retrieve data for user by name
        public static bool IfPasswordsMatch(LoginCredentials userFromDb, string userPassword)
        {
            var saltFromDb = userFromDb.PasswordSalt;
            var hashFromDb = userFromDb.PasswordHash;
            string hashedAgainToCompare = Convert.ToBase64String(KeyDerivation.Pbkdf2(userPassword, saltFromDb,
                    KeyDerivationPrf.HMACSHA1, 1000, 256 / 8));
            if (hashedAgainToCompare == hashFromDb)
            {
                // TODO: user valid for login
                return true;
            }
            return false;
        }
    }
}
