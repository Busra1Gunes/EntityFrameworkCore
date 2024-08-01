// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

public class VeriKaliciligiContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Database=VeriKaliciligi;Integrated Security=True;Trust Server Certificate=True");
    }
}
