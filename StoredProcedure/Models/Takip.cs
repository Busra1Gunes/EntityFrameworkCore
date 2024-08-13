using System;
using System.Collections.Generic;

namespace StoredProcedure.Models;

public partial class Takip
{
    public int Id { get; set; }

    public string? MagdurAd { get; set; }

    public string? MagdurSoyad { get; set; }

    public int? Davaturid { get; set; }

    public int? Tur { get; set; }

    public DateTime? AcilisTarih { get; set; }

    public DateTime? KapanisTarih { get; set; }

    public string? Durum { get; set; }

    public string? TcKimlikNo { get; set; }

    public bool? Eski { get; set; }

    public decimal? Payoran { get; set; }

    public bool? Silindi { get; set; }

    public DateTime? SilTar { get; set; }

    public string? Nott { get; set; }

    public string? Logg { get; set; }

    public string? Goster { get; set; }

    public bool? Sorumluluk { get; set; }

    public int? BolmudId { get; set; }

    public string? PrimIds { get; set; }

    public bool? EskiDonem { get; set; }

    public string? Gsm { get; set; }

    public string? Davali { get; set; }

    public string? EsasYil { get; set; }

    public string? EsasNo { get; set; }

    public string? MahkemeAd { get; set; }

    public string? SigortaHasarNo { get; set; }

    public string? DosyaAsama { get; set; }

    public string? MagdurAdres { get; set; }

    public int? MagdurIlKod { get; set; }

    public int? MagdurIlceKod { get; set; }

    public decimal? TazminatTutar { get; set; }

    public string? TalepTuru { get; set; }

    public string? VekaletTuru { get; set; }

    public decimal? HaklilikOrani { get; set; }

    public decimal? SakatlikOrani { get; set; }

    public string? SakatlikDurumu { get; set; }

    public string? Meslek { get; set; }

    public string? MedeniHali { get; set; }

    public int? CocukSayi { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public DateTime? KazaTarihi { get; set; }

    public DateTime? DavaTarihi { get; set; }

    public string? Aktueryasonuc { get; set; }

    public string? KazaIl { get; set; }

    public string? KazaIlce { get; set; }

    public string? KazaMevki { get; set; }

    public string? PoliceNo { get; set; }

    public string? Plaka { get; set; }

    public string? UzlasmaDurumu { get; set; }

    public int? GuncelleyenId { get; set; }

    public DateTime? DurusmaTarih { get; set; }

    public string? DurusmaSaat { get; set; }

    public decimal? TahminiSakatlik1 { get; set; }

    public decimal? TahminiSakatlik2 { get; set; }

    public bool? Onay { get; set; }

    public string? AvutServisAciklama { get; set; }

    public string Temyiz { get; set; } = null!;

    public string? TemyizMahkemeAd { get; set; }

    public string? TemyizEsasyil { get; set; }

    public string? TemyizEsasNo { get; set; }

    public string? SorgulamaNot { get; set; }

    public decimal? MagdurMaas { get; set; }

    public DateTime? PoliceTarih { get; set; }

    public string? Cinsiyet { get; set; }

    public string? AnneBilgi { get; set; }

    public string? BabaBilgi { get; set; }

    public string? EsBilgi { get; set; }

    public string? CocukBilgi { get; set; }

    public int? DoktorId { get; set; }

    public int? KusurbkId { get; set; }

    public string? IcraMdrAd { get; set; }

    public string? IcraEsasyil { get; set; }

    public string? IcraEsasno { get; set; }

    public string? SavcilikAd { get; set; }

    public string? SavcilikYil { get; set; }

    public string? SavcilikEsas { get; set; }

    public string? CezaAd { get; set; }

    public string? CezaYil { get; set; }

    public string? CezaEsas { get; set; }

    public string? THastane { get; set; }

    public string? RHastane { get; set; }

    public DateTime? RaporTar { get; set; }

    public string? EpikrizTani { get; set; }

    public DateTime? SigortaBasvuruTar { get; set; }

    public DateTime? RaporGonTar { get; set; }

    public string? Haksahip { get; set; }

    public string? EDevletSifre { get; set; }

    public string? AvNote { get; set; }

    public byte? GeriAcilma { get; set; }

    public bool? DoktorOnay { get; set; }

    public decimal? OnayDrSakatlikOran { get; set; }

    public string? DrGorus { get; set; }

    public string? KararYil { get; set; }

    public string? KararNo { get; set; }

    public bool? SatinAlinanDosya { get; set; }

    public string? NotArabul { get; set; }

    public string? NotArabulKusur { get; set; }

    public string? NotArabulSoran { get; set; }

    public string? NotArabulTutar { get; set; }

    public string? NotEvrakDevri { get; set; }

    public string? NotPayDevri { get; set; }

    public string? SurucuAd { get; set; }

    public string? GeciciIsGöremezlik { get; set; }

    public DateTime? KesifTarih { get; set; }

    public decimal? TahminiDosyaTutar { get; set; }

    public string? ENabizSifre { get; set; }

    public string? Temyizalt { get; set; }

    public DateTime? IcraTakipTarih { get; set; }

    public string? Degisikisdosyasi { get; set; }

    public int? AnketId { get; set; }

    public bool? TakipTalep { get; set; }

    public bool? ManevitazTalep { get; set; }

    public bool? TapuDurum { get; set; }

    public bool? Azilname { get; set; }

    public string? SurucuMeslek { get; set; }

    public string? RuhsatSahibi { get; set; }

    public string? KusurluaracBilgi { get; set; }

    public decimal? MahSakOrn { get; set; }

    public virtual ICollection<OrtakPayDurum> OrtakPayDurums { get; set; } = new List<OrtakPayDurum>();
}
