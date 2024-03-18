using Microsoft.EntityFrameworkCore;
namespace HangManSolo;

public class GameDbContext : DbContext
{
	public DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	=> optionsBuilder.UseNpgsql("Host=localhost;Port=5455;Database=hangman;Username=postgres;Password=postgres;");
}


public class User
{
	public int Id { get; set; }
	public string? Username { get; set; }
	public byte[]? PassHash { get; set; }
	public byte[]? Salt { get; set; }
	public int Score { get; set; }
}