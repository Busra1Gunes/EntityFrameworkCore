// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

public class ETicaretContext : DbContext
{
	public DbSet<Urun> Urunler { get; set; }
	public DbSet<Parca> Parcalar { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Data Source=DESKTOP-IUMMNFO\\SQLEXPRESS;Database=ETicaretDB;Integrated Security=True;Trust Server Certificate=True");
	}
}
