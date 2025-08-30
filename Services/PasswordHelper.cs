using System.Security.Cryptography;

namespace BookingSystemApi.Services
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            var pdkd2f = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA3_256);
            byte[] hash = pdkd2f.GetBytes(32);

            byte[] hashBytes = new byte[48];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
