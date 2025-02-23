using System.Security.Cryptography;
using System.Text;

namespace Lgym.Services.Security
{
    public static class PasswordHasher
    {
        // Długość hashu w bajtach (np. 32 = 256 bit)
        private const int HashByteSize = 32;
        // Ilość iteracji PBKDF2 (np. 10_000). Im wyższa, tym bezpieczniej, ale wolniej.
        private const int Iterations = 10_000;

        /// <summary>
        /// Zwraca hashowane hasło w postaci Base64 (dla uproszczenia).
        /// Salt = userName + globalSalt (z ustawień).
        /// </summary>
        public static string HashPassword(string password, string userName, string globalSalt)
        {
            // Budujemy sól: userName + globalSalt
            var saltString = userName + globalSalt;

            // Konwertujemy sól i hasło do bajtów
            var saltBytes = Encoding.UTF8.GetBytes(saltString);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Tworzymy PBKDF2 (Rfc2898DeriveBytes)
            using var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, Iterations, HashAlgorithmName.SHA256);

            // Generujemy klucz (hash)
            byte[] key = pbkdf2.GetBytes(HashByteSize);

            // Zwracamy w Base64 (można też przechowywać w hex)
            return Convert.ToBase64String(key);
        }
    }
}
