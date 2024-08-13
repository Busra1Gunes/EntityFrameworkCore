// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Models;
using System.Collections.Generic;
Console.WriteLine("Hello, World!");
HukdanUniContext hukdanUniContext = new();

// Asenkron olarak takipleri al
var takips = await hukdanUniContext.Takips
    .OrderByDescending(t => t.Id) // Sıralama
    .Take(100) // İlk 100 kaydı al
    .ToListAsync(); // Listeye dönüştür

// Sonuçları saklayacak bir liste oluştur
var allResults = new List<string>();

// Her ID için AvukatGetir fonksiyonunu çağır
foreach (var takip in takips)
{
    // Asenkron işlemi bekleyerek sonuçları topla
    var result =  hukdanUniContext.AvukatGetir(takip.Id);
    allResults.Add(result);
}

// Sonuçları kullanarak işlemler yapabilirsiniz
// Örneğin, sonuçları konsola yazdırma
foreach (var result in allResults)
{
    Console.WriteLine(result);
}


Console.WriteLine();

