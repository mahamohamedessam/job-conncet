using System;
using System.Security.Cryptography;
using System.Text;


namespace jobconnect.Helper
{ 
    public static class HashPassword
    {
            // Method to generate a random password
        
            public static string GenerateRandomPassword(int length = 8)
            {
                const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder sb = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    sb.Append(validChars[rnd.Next(validChars.Length)]);
                }
                return sb.ToString();
            }

            // Method to generate a random salt
            public static byte[] GenerateSalt()
            {
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }
                return salt;
            }

            // Method to generate hash using password and salt
            public static byte[] GenerateHash(string password, byte[] salt)
            {
                using (var hmac = new HMACSHA512(salt))
                {
                    return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }
        }
    }

