using Microsoft.EntityFrameworkCore;
namespace HangManSolo;

public class GameDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // enter postgres DB here
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Port=5455;Database=hangman;Username=postgres;Password=postgres;");
}
public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PassHash { get; set; }
    public byte[]? Salt { get; set; }
    public int Score { get; set; }
    public int GamesPlayed { get; set; }
}