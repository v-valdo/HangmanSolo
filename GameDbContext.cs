using Microsoft.EntityFrameworkCore;
namespace HangManSolo;

public class GameDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<UserScore> Score { get; set; }
}

public class User
{
	public int Id { get; set; }
	public string? Username { get; set; }
	public byte[]? PassHash { get; set; }
	public byte[]? Salt { get; set; }
	public UserScore? Score { get; set; }
}
public class UserScore
{
	public int UserId { get; set; }
	public int ScoreValue { get; set; }
	public User? User { get; set; }
}
