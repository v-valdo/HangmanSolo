using System.Security.Cryptography;
using System.Text;

namespace HangManSolo;
public class UserManager
{
    private GameDbContext db = new();
    public string EncryptPassword(string password, out byte[] salt)
    {
        int keySize = 64;
        int iterations = 200000;
        HashAlgorithmName algo = HashAlgorithmName.SHA512;

        salt = RandomNumberGenerator.GetBytes(keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            algo,
            keySize);

        return Convert.ToHexString(hash);
    }
    public async Task UserToDb(string username, string passwordHash, byte[] salt)
    {
        db.Add(new User
        {
            Username = username,
            PassHash = passwordHash,
            Salt = salt,
            Score = 0
        });
        await db.SaveChangesAsync();
    }
    public async Task<bool> Login(string username, string password)
    {
        var user = db.Users.FirstOrDefault(x => x.Username == username);
        if (user == null)
        {
            return false;
        }
        if (await AuthPassword(password, user.PassHash, user.Salt))
        {
            return true;
        }
        return false;
    }
    public async Task<bool> AuthPassword(string password, string hash, byte[] salt)
    {
        var compareHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 200000, HashAlgorithmName.SHA512, 64);

        return CryptographicOperations.FixedTimeEquals(compareHash, Convert.FromHexString(hash));
    }
}