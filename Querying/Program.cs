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