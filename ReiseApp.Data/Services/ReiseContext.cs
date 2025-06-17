using Microsoft.EntityFrameworkCore;
using ReiseApp.Data.Models;
namespace ReiseApp.Data.Services;


public class ReiseContext : DbContext
{
    public DbSet<Reise> Reisen { get; set; }

    private readonly string _path = string.Empty;

    public ReiseContext(string path)
    {
        _path = path;
        SQLitePCL.Batteries_V2.Init();
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={_path}");
    }

}
