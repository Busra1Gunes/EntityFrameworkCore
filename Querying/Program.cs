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
//Sorguyu ToList veya foreach döngüsü ile execute ederiz
#endregion

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
#region Çogul veri getiren sorgulama fonksiyonları
#region ToListAsync
//Üretilen sorguyu execute ettirmemizi sağlayan sorgudur IQueryable den IEnumerable geçmemizi sağlar
#endregion
#region Where
//Oluşturulan sağlayan where şartı eklmemizi sağlayan bir fonkisyondur
#endregion
#region OrderBy
//Sorgu üzerinde sıralama yapmamızı sağlayan fonksiyondur,OrderBy ascending olarak sıralamayı yapar
#endregion
#region ThenBy
//OrderBy üzerinde yapılan sıralama işemini farklı kolonlarada uygulamamız sağlar default olarak ascending
var thenby = context.Urunler.Where(u => u.Id > 2 || u.UrunAdi.StartsWith("A")).
	OrderBy(u => u.Fiyat).ThenBy(t => t.UrunAdi).ThenBy(t => t.Id);
//Fiyat özelliği eşit olan öğeleri UrunAdi özelliğine göre artan sıraya göre ikinci bir düzeyde sıralar.
//önce fiyata göre sıralıyor fiyatı aynı olanları ürün adına göre sıralıyor , ürün adı aynı olanları ise ID ye göre sıralıyor
#endregion
#region OrderByDescending
//descending olarak sıralama yapmamızı sağlayan fonksiyondur
#endregion
#region ThenByDescending
//OrderByDescending üzerinde yapılan sıralama işemini farklı kolonlarada uygulamamız sağlar default olarak ascending
#endregion

#endregion
#region FindAsync
//Find fonksiyonu primary key kolonuna özel hızlı bir şekilde sorgulama yapmamızı sağlayan bir fonksiyondur
Urun urun1 = await context.Urunler.FindAsync(1);
#endregion#region LastAsync
//Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır. OrderBy kullanılması mecburidir.
//var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastAsync(u => u.Id > 55);


#region LastOrDefaultAsync
//Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa null döner. OrderBy kullanılması mecburidir.
//var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastOrDefaultAsync(u => u.Id > 55);
#endregion

#region Diğer Sorgulama Fonksiyonları
#region CountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) bizlere bildiren fonksiyondur.
//var urunler = (await context.Urunler.ToListAsync()).Count();
//var urunler = await context.Urunler.CountAsync();
#endregion

#region LongCountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(long) bizlere bildiren fonksiyondur.
//var urunler = await context.Urunler.LongCountAsync(u => u.Fiyat > 5000);
#endregion

#region AnyAsync
//Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur. 
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("1")).AnyAsync();
//var urunler = await context.Urunler.AnyAsync(u => u.UrunAdi.Contains("1"));
#endregion

#region MaxAsync
//Verilen kolondaki max değeri getirir.
//var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat);
#endregion

#region MinAsync
//Verilen kolondaki min değeri getirir.
//var fiyat = await context.Urunler.MinAsync(u => u.Fiyat);
#endregion

#region Distinct
//Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
//var urunler = await context.Urunler.Distinct().ToListAsync();
#endregion

#region AllAsync
//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.
//var m = await context.Urunler.AllAsync(u => u.Fiyat < 15000);
//var m = await context.Urunler.AllAsync(u => u.UrunAdi.Contains("a"));
#endregion

#region SumAsync
//Vermiş olduğumuz sayısal proeprtynin toplamını alır.
//var fiyatToplam = await context.Urunler.SumAsync(u => u.Fiyat);
#endregion

#region AverageAsync
//Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını alır.
//var aritmatikOrtalama = await context.Urunler.AverageAsync(u => u.Fiyat);
#endregion

#region Contains
//Like '%...%' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToListAsync();
#endregion

#region StartsWith
//Like '...%' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("7")).ToListAsync();
#endregion

#region EndsWith
//Like '%...' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToListAsync();
#endregion
#endregion

#region Sorgu Sonucu Dönüşüm Fonksiyonları
//Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultuusnda farklı türlerde projecsiyon edebiliyoruz.

#region ToDictionaryAsync
//Sorgu neticesinde gelecek olan veriyi bir dictioanry olarak elde etmek/tutmak/karşılamak istiyorsak eğer kullanılır!
//var urunler = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

//ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
//ToList : Gelen sorgu neticesini entity türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
//ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
#endregion

#region ToArrayAsync
//Oluşturulan sorguyu dizi olarak elde eder.
//ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi  olarak elde eder.
//var urunler = await context.Urunler.ToArrayAsync();
#endregion

#region Select
//Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur,
//1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır. 

//var urunler = await context.Urunler.Select(u => new Urun
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

//2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim

//var urunler = await context.Urunler.Select(u => new 
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();


//var urunler = await context.Urunler.Select(u => new UrunDetay
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

#endregion

#region SelectMany
//Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.

//var urunler = await context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new
//{
//    u.Id,
//    u.Fiyat,
//    p.ParcaAdi
//}).ToListAsync();
#endregion
#endregion

#region GroupBy Fonksiyonu
//Gruplama yapmamızı sağlayan fonksiyondur.
#region Method Syntax
//var datas = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
//{
//    Count = group.Count(),
//    Fiyat = group.Key
//}).ToListAsync();
#endregion
#region Query Syntax
var datas = await (from urun in context.Urunler
                   group urun by urun.Fiyat
            into @group
                   select new
                   {
                       Fiyat = @group.Key,
                       Count = @group.Count()
                   }).ToListAsync();
#endregion
#endregion

#region Foreach Fonksiyonu
//Bir sorgulama fonksiyonu felan değildir!
//Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur. foreach döngüsünün metot halidir!

foreach (var item in datas)
{

}
datas.ForEach(x =>
{

});
#endregion

var urunler1 = context.Urunler.Include(p => p.Parcalar).SelectMany(p => p.Parcalar, (u, p) => new
{
    u.Id,
    u.Fiyat,
    p.ParcaAdi,
}).ToListAsync();
