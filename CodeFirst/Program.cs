// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;



Console.WriteLine("");
//Kod üzerinden migrate işlemi
//ECommerceDbContext context = new();
//await context.Database.MigrateAsync();


//ECommerceDbContext, DbContext'ten türeyen bir sınıf olduğu için veritabanı sunucusunda bir veritabanına karşılık gelen sınıf olduğu bilinir
public class ECommerceDbContext:DbContext
{
    //Tablo oluşturma
    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Database=ECommerce;Integrated Security=True;Trust Server Certificate=True");
    }
}

//Entity
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}