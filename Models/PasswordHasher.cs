using System;
using System.Security.Cryptography;

namespace lamia12771.Models
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        public static void CreatePasswordHash(
            string password,
            out string passwordHash,
            out string passwordSalt)
        {
            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                passwordSalt = Convert.ToBase64String(salt);
                passwordHash = Convert.ToBase64String(hash);
            }
        }


        public static bool VerifyPassword(
            string password,
            string storedHash,
            string storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(storedHash) ||
                string.IsNullOrWhiteSpace(storedSalt))
            {
                return false;
            }

            byte[] salt;

            try
            {
                salt = Convert.FromBase64String(storedSalt);
            }
            catch
            {
                return false;
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations))
            {
                byte[] calculatedHash =
                    pbkdf2.GetBytes(HashSize);

                byte[] savedHash;

                try
                {
                    savedHash =
                        Convert.FromBase64String(storedHash);
                }
                catch
                {
                    return false;
                }

                if (calculatedHash.Length != savedHash.Length)
                {
                    return false;
                }

                int difference = 0;

                for (int i = 0;
                     i < calculatedHash.Length;
                     i++)
                {
                    difference |=
                        calculatedHash[i] ^ savedHash[i];
                }

                return difference == 0;
            }
        }
    }
}