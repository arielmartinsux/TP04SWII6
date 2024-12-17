using Microsoft.EntityFrameworkCore;
using TP04SWII6.Models;
public class AppDbContext : DbContext
{
    public DbSet<Jogo> Jogos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
