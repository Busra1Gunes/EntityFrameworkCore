// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


Console.WriteLine("123");
#region Veri Nasıl Eklenir

ETicaretContext context = new();
Urun urun = new()
{
    UrunAdi = "A Ürünü",
    Fiyat = 10
};
Urun urun2 = new()
{
    UrunAdi = "B Ürünü",
    Fiyat = 10
};
Urun urun3 = new()
{
    UrunAdi = "c Ürünü",
    Fiyat = 10
};
await context.AddAsync(urun);
#region AddRange
await context.Urunler.AddRangeAsync(urun, urun2, urun3);
#endregion
//veya  tip güvenli olacak şekilde
// await context.Urunler.AddAsync(urun); 
await context.SaveChangesAsync();

//Savechanges : insert, update ve delete sorgularını oluşturup bir transaction eşliğinde veritabanına gönderip execute eden fonksiyondur
//eğer ki oluşturulan sorgulardan birisi başarısız olursa tüm işlemleri geri alır()
#endregion

// SaveChanges fonksiyonu her tetiklediğinde bir transaction oluşturulduğundan dolayı EF Core ile yapılan her bir işleme özel kullanmaktan
//kaçınmalıyız, Çünki her işleme özel transaction veritabanı açısından ekstra maliyet demektir, O yüzden mümkün mertebe tüm işlemlerimizi tek bir 
//trnsaction eşliğinde veri tabanına gönderebilmek için savechanges'ı aşagıdaki gibi tek seferde kullanmak hem maliyet hem de yönetilebilirlik 
//açısından katkıda bulunmuş olacaktır


#region ****Eklenen verinin generate Edilen Id'sini Elde Etme
Console.WriteLine(urun.Id);
#endregion

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    #region OnConfiguring ile Konfigurasyon Ayarını Gerçekleştirmek
    //EF Core tool'unu yapılandırmak için kullandığımız bir metottur
    //Context nesnesinde override edilerek kullanılmaktadır
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Database=ETicaretDB;Integrated Security=True;Trust Server Certificate=True");
    }
}
#region Basit düzeyde entity tanımlama kuralları
//EF Core, her tablonun default olarak bir primary key kolonu olması gerektiğini kabul eder
//Haliyle bu kolonu temsil eden bir property tanımlanmadığımız taktirde hata vericektir
//Bir entity'de yazdığımız property'nin primery key olabilmesi için içinde Id geçmesi gerekir
#endregion
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public double Fiyat { get; set; }


}

