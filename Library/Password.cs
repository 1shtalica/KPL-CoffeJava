using System.Security.Cryptography;

namespace Library
{
    public static class Password
    {
        public static bool ComparePassword(string inputPassword, string hashedPassword, string saltBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            string hashedInputPassword = HashPassword(inputPassword, salt);
            return hashedPassword == hashedInputPassword;


        }

        

        public static byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(hash);
            }
        }
    }


}