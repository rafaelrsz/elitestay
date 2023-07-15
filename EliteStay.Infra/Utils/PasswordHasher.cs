using System.Security.Cryptography;
using EliteStay.Domain.BookingContext.Utils;

namespace EliteStay.Infra.Utils
{
  public class PasswordHasher : IPasswordHasher
  {
    private const int saltSize = 16;
    private const int keySize = 32;
    private const int iterations = 1000;
    private const char delimiter = ';';
    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
    public string Hash(string password)
    {
      var salt = RandomNumberGenerator.GetBytes(saltSize);
      var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, _hashAlgorithmName, keySize);

      return string.Join(delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string passwordHash, string inputPassword)
    {
      var elements = passwordHash.Split(delimiter);
      var salt = Convert.FromBase64String(elements[0]);
      var hash = Convert.FromBase64String(elements[1]);

      var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, iterations, _hashAlgorithmName, keySize);

      return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
  }
}