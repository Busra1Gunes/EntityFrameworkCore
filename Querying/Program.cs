// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

ETicaretContext context = new();

#region En temel sorgulma nasıl yapılır
//Metod Syntax
var Urunler = await context.Urunler.ToListAsync();
//Query Syntax
var Urunler2 = await (from urun in context.Urunler
					  select urun).ToListAsync();
#endregion
#region Sorguyu execute etmek için ne yapmamız gerekmektedir?

#endregion
//Sorguyu ToList ile execute ederiz veya foreach döngüsü ile

#region IQueryable ve IEnumerable 
//IQueryable örnek
var urunler = from urun in context.Urunler
			  select urun;

//IEnumerable örnek
var urunler2 = await (from urun in context.Urunler
					  select urun).ToListAsync(); //ToList bir IEnumerable'dır
#endregion
#region IQueryable
//EF Core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder
#endregion
#region IEnumerable
//Sorgunun çalıştırılıp/execute edilip verilerin in memory e yüklenmiş halinş ifade eder
#endregion
#region ForeachIQueryable
//execute edilmemiş bir sorgu foreach içinde execute edilmiş olur bu davranışa Deffered Execution (Ertelenmiş Çalışma)
foreach (Urun urun in urunler) //Sorgu bu noktada IEnumerable olur
{
	Console.WriteLine(urun.UrunAdi);
}
#endregion
#region Deffered Execution (Ertelenmiş Çalışma)
// sorgularında ilgili kod yazıldığı noktada çalıştırılmaz/sorguyu generate etmez
//nerede eder? çalıştırıldığı/execute edildiği noktada tetiklenir ! işte bu durumada ertelenmiş çalışma denir!
int urunID = 5;
var veriler =from urun in context.Urunler 
			 where urun.Id> urunID                     //Burda sorgus oluşturulur ama çalıştırlmaz!!! ertelenmiştir
			 select urun;

urunID = 10;
foreach (var urun in veriler) //burda sorgu çalıştırılır ama  sorguda son urunID değeri olan 10'u alır
{
    Console.WriteLine(urun.Id);
}

#endregion
public class ETicaretContext : DbContext
{
	public DbSet<Urun> Urunler { get; set; }
	public DbSet<Parca> Parcalar { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Data Source=DESKTOP-IUMMNFO\\SQLEXPRESS;Database=ETicaretDB;Integrated Security=True;Trust Server Certificate=True");
	}
}
public class Urun
{
	public int Id { get; set; }
	public string UrunAdi { get; set; }
	public float Fiyat { get; set; }
	public ICollection<Parca> Parcalar { get; set; }
}
public class Parca
{
	public int Id { get; set; }
	public string ParcaAdi { get; set; }
}
