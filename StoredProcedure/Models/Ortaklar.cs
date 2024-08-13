using System;
using System.Collections.Generic;

namespace StoredProcedure.Models;

public partial class Ortaklar
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Adres { get; set; }

    public string? Telefon1 { get; set; }

    public string? Telefon2 { get; set; }

    public bool? KasaSahibi { get; set; }

    public string? TcKimlik { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Sifre { get; set; }

    public string? Mail { get; set; }

    public string? Yetki { get; set; }

    public int? YetkiliId { get; set; }

    public int? BolmudId { get; set; }

    public string? SifreMail { get; set; }

    public bool? Silindi { get; set; }

    public DateTime? Tarih { get; set; }

    public string? SilTar { get; set; }

    public string? Logg { get; set; }

    public int? SubeId { get; set; }

    public bool? Sartname { get; set; }

    public string? MesajKod { get; set; }

    public DateTime? MesajTime { get; set; }

    public bool? DosyaMuaf { get; set; }

    public string? BankaAd { get; set; }

    public string? Iban { get; set; }

    public string? Hesapsahibi { get; set; }

    public bool? ShowTc { get; set; }

    public bool? IsAvukat { get; set; }

    public bool? CanLogin { get; set; }

    public int? RolId { get; set; }

    public int? UnvanId { get; set; }

    public int? FirmaId { get; set; }

    public bool? SabitMesajKod { get; set; }

    public bool? AvList { get; set; }
}
