using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ETicaretContext context = new();
#region Change Tracking Neydi?
//Context nesnesi üzerinden gelen tüm nesneler/veriler otomotik olarak bir takip mekanızması tarafından izlenirler.
//İşte bu takip mekanizmasına Change Tracker denir , Change Tracker ile nesneler üzerindeki değişiklikler işlemler takip edilerek netice itibariyle bu işlemlerin
//fıtratına uygun sql sorgucukları generate edilir , İşte bu işleme de change tracking denir
#endregion
#region ChangeTracker Propertysi
//Takip edilen nesnelere erişebilmemizi sağlayan ve gerektiği taktirde işlemler gerçekleştirmemizi sağlayan bir propertydir
//Context sınıfın base class'ı olan DbContext sınıfının bir member'ıdır
var urunler = await context.Urunler.ToListAsync();
urunler[6].Fiyat = 2; //UPDATE
context.Urunler.Remove(urunler[6]); //DELETE
var datas = context.ChangeTracker.Entries();
Console.WriteLine();
#endregion
#region DetectChanges Metodu
//EF Core, context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel değişiklikler
//yakalarak bunların anlık görüntüleri (snapshot)'ini oluştrabilir
//Yapılan değişikliklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir.
//SaveChanges fonksiyonu çağırıldığı anda nesneler EF Core tarafından otomotik kontrol edilebilirler
#endregion


