using System.Security.Cryptography;
using System.Text;

namespace Common.Application.SecurityUtil;

public class Sha256Hasher
{
    public static string Hash(string inputValue)
    {
        using var sha256 = SHA256.Create();
        var originalBytes = Encoding.Default.GetBytes(inputValue);
        var encodedBytes = sha256.ComputeHash(originalBytes);
        return Convert.ToBase64String(encodedBytes);
    }
    public static bool IsCompare(string hashText, string rawText)
    {
        var hash = Hash(rawText);
        return hashText == hash;
    }
}