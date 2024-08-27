// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

Console.WriteLine("Hello, World!");

VeriKaliciligiContext context = new();
#region Kayıt Ekleme
User user1 = new()
{
    Name = "Ali",
    Surname = "Güneş",
    Age = 22,
    Score = 100
};
await context.Users.AddAsync(user1);
await context.SaveChangesAsync();
#endregion

#region Toplu Kayıt Ödeme
List<User> users = new()
{
    new User { Name="Kübra",Surname="Güneş",Age=18,Score=100},
    new User { Name = "Emin", Surname = "Güneş", Age = 12, Score = 100 }
};
await context.Users.AddRangeAsync(users);
await context.SaveChangesAsync();
#endregion

#region Kayıt Güncelleme
User user2 = context.Users.FirstOrDefault(x => x.Id == 1);
user2.Age = 21;
await context.SaveChangesAsync();
#endregion


#region Toplu Kayıt Güncelleme
List<User> user3 = context.Users.Where(a => a.Id < 5).ToList();
user3.ForEach(a => a.Name = "*");
await context.SaveChangesAsync();
#endregion

#region Change Tracker olmadan güncelleme
User user4 = new() { Id = 1, Name = "Büşra", Surname = "Güneş", Score = 100, Age = 11 };
context.Update(user4);
context.SaveChanges();
#endregion

#region Kayıt silme
User user5 = context.Users.FirstOrDefault(x => x.Id == 4);
context.Remove(user5);
context.SaveChanges();
#endregion

#region Toplu Silme
List<User> user = context.Users.Where(x => x.Name == "*").ToList();
context.RemoveRange(user);
context.SaveChanges();
#endregion
