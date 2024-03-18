using System.Security.Cryptography;
using System.Text;

namespace HangManSolo;

public class UserManager
{
	private GameDbContext db = new();
	public byte[] EncryptPassword(string password, out byte[] salt)
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

		return hash;
	}

	public void UserToDb(string username, byte[] passwordHash, byte[] salt)
	{
		db.Add(new User
		{
			Username = username,
			PassHash = passwordHash,
			Salt = salt,
			Score = 0
		});
		db.SaveChanges();
	}
}