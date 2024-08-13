using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace StoredProcedure.Models;

public partial class HukdanUniContext : DbContext
{
    public HukdanUniContext()
    {
    }

    public HukdanUniContext(DbContextOptions<HukdanUniContext> options)
        : base(options)
    {
    }
    public string AvukatGetir(int takip_id)
    {
        var takipIdParameter = new SqlParameter("@takip_id", takip_id);
        var result = this.Database.ExecuteSqlRawAsync("Select dbo.AvukatGetir("+takip_id+")");
        return result.ToString();
    }

    public virtual DbSet<OrtakPayDurum> OrtakPayDurums { get; set; }

    public virtual DbSet<Ortaklar> Ortaklars { get; set; }

    public virtual DbSet<Takip> Takips { get; set; }
    public virtual DbSet<TakipAvukat> TakipAvukat { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Initial Catalog=hukdanUNI;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");
        modelBuilder.Entity<TakipAvukat>().HasNoKey();
        modelBuilder.Entity<OrtakPayDurum>(entity =>
        {
            entity.ToTable("ortak_pay_durum", tb => tb.HasTrigger("paydurum_trig"));

            entity.HasIndex(e => new { e.TakipId, e.Silindi, e.Id, e.OrtakId, e.Sorumluluk }, "_dta_index_ortak_pay_durum_13_1170103209__K3_K7_K1_K2_K5");

            entity.HasIndex(e => new { e.Silindi, e.TakipId, e.OrtakId, e.Id, e.Sorumluluk }, "_dta_index_ortak_pay_durum_13_1170103209__K7_K3D_K2_K1_K5").IsDescending(false, true, false, false, false);

            entity.HasIndex(e => new { e.Silindi, e.TakipId, e.OrtakId }, "_dta_index_ortak_pay_durum_iptaldosyalari");

            entity.HasIndex(e => new { e.TakipId, e.Sorumluluk, e.Silindi, e.OrtakId }, "_dta_index_ortak_pay_durum_iptaldosyalari_2");

            entity.HasIndex(e => e.Silindi, "_dta_index_ortak_pay_durum_magduriban");

            entity.HasIndex(e => new { e.OrtakId, e.Silindi, e.TakipId }, "_dta_index_ortak_pay_durum_ortakrap_3");

            entity.HasIndex(e => new { e.TakipId, e.Silindi, e.Id, e.OrtakId, e.Prim }, "_dta_index_ortak_pay_durum_zimmetler");

            entity.HasIndex(e => e.Silindi, "silindi_INDEX");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DevredenPay)
                .HasMaxLength(10)
                .HasColumnName("devreden_pay");
            entity.Property(e => e.DevredenTutar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("devreden_tutar");
            entity.Property(e => e.OrtakId).HasColumnName("ortak_id");
            entity.Property(e => e.Payorani)
                .HasMaxLength(10)
                .HasDefaultValueSql("((0))")
                .HasColumnName("payorani");
            entity.Property(e => e.Prim).HasColumnName("prim");
            entity.Property(e => e.Silindi)
                .HasDefaultValue(false)
                .HasColumnName("silindi");
            entity.Property(e => e.Sorumluluk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sorumluluk");
            entity.Property(e => e.TakipId).HasColumnName("takip_id");
            entity.Property(e => e.Yerine)
                .HasMaxLength(60)
                .HasColumnName("yerine");
            entity.Property(e => e.YetkiliId).HasColumnName("yetkili_id");

            entity.HasOne(d => d.Takip).WithMany(p => p.OrtakPayDurums)
                .HasForeignKey(d => d.TakipId)
                .HasConstraintName("FK_ortak_pay_durum_takip");
        });

        modelBuilder.Entity<Ortaklar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ortaklar", tb => tb.HasTrigger("ortak_trig"));

            entity.HasIndex(e => new { e.Silindi, e.Id }, "_dta_index_ortaklar_13_1513772450__K16_K1_2_3");

            entity.HasIndex(e => new { e.Id, e.YetkiliId, e.BolmudId }, "_dta_index_ortaklar_magduriban");

            entity.HasIndex(e => new { e.Id, e.RolId, e.Silindi }, "_dta_index_ortaklar_masrafonay_2");

            entity.HasIndex(e => new { e.Id, e.FirmaId, e.SubeId, e.IsAvukat, e.Silindi }, "_dta_index_ortaklar_ortakrap_4");

            entity.HasIndex(e => new { e.Id, e.Silindi }, "_dta_index_ortaklar_oskan");

            entity.HasIndex(e => new { e.Yetki, e.Id, e.Silindi, e.Ad, e.YetkiliId, e.BolmudId }, "_dta_index_ortaklar_zimmetler");

            entity.HasIndex(e => e.Silindi, "silindi_INDEX");

            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .HasColumnName("ad");
            entity.Property(e => e.Adres)
                .HasMaxLength(200)
                .HasColumnName("adres");
            entity.Property(e => e.AvList).HasColumnName("avList");
            entity.Property(e => e.BankaAd)
                .HasMaxLength(50)
                .HasColumnName("banka_ad");
            entity.Property(e => e.BolmudId).HasColumnName("bolmud_id");
            entity.Property(e => e.CanLogin)
                .HasDefaultValue(false)
                .HasColumnName("canLogin");
            entity.Property(e => e.DosyaMuaf).HasColumnName("dosyaMuaf");
            entity.Property(e => e.FirmaId)
                .HasDefaultValue(1)
                .HasColumnName("firmaID");
            entity.Property(e => e.Hesapsahibi)
                .HasMaxLength(50)
                .HasColumnName("hesapsahibi");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IsAvukat)
                .HasDefaultValue(false)
                .HasColumnName("isAvukat");
            entity.Property(e => e.KasaSahibi).HasColumnName("kasa_sahibi");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(20)
                .HasColumnName("kullanici_adi");
            entity.Property(e => e.Logg)
                .HasMaxLength(500)
                .HasColumnName("logg");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.MesajKod)
                .HasMaxLength(10)
                .HasColumnName("mesajKod");
            entity.Property(e => e.MesajTime)
                .HasColumnType("datetime")
                .HasColumnName("mesajTime");
            entity.Property(e => e.RolId)
                .HasDefaultValue(0)
                .HasColumnName("rolID");
            entity.Property(e => e.SabitMesajKod)
                .HasDefaultValue(false)
                .HasColumnName("sabitMesajKod");
            entity.Property(e => e.Sartname).HasColumnName("sartname");
            entity.Property(e => e.ShowTc)
                .HasDefaultValue(false)
                .HasColumnName("showTc");
            entity.Property(e => e.Sifre)
                .HasMaxLength(20)
                .HasColumnName("sifre");
            entity.Property(e => e.SifreMail)
                .HasMaxLength(20)
                .HasColumnName("sifre_mail");
            entity.Property(e => e.SilTar)
                .HasMaxLength(15)
                .HasColumnName("silTar");
            entity.Property(e => e.Silindi).HasColumnName("silindi");
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .HasColumnName("soyad");
            entity.Property(e => e.SubeId)
                .HasDefaultValue(0)
                .HasColumnName("sube_id");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TcKimlik)
                .HasMaxLength(11)
                .HasColumnName("tc_kimlik");
            entity.Property(e => e.Telefon1)
                .HasMaxLength(15)
                .HasColumnName("telefon1");
            entity.Property(e => e.Telefon2)
                .HasMaxLength(15)
                .HasColumnName("telefon2");
            entity.Property(e => e.UnvanId)
                .HasDefaultValue(0)
                .HasColumnName("unvanID");
            entity.Property(e => e.Yetki)
                .HasMaxLength(15)
                .HasColumnName("yetki");
            entity.Property(e => e.YetkiliId).HasColumnName("yetkili_id");
        });

        modelBuilder.Entity<Takip>(entity =>
        {
            entity.ToTable("takip", tb =>
                {
                    tb.HasTrigger("takipAsama_trig");
                    tb.HasTrigger("takip_trig");
                    tb.HasTrigger("trg_OrtakYetki");
                    tb.HasTrigger("trg_policetarih");
                });

            entity.HasIndex(e => new { e.Silindi, e.Id, e.Tur }, "_dta_index_takip_13_1666821000__K12_K1_K5_2_3_8_9");

            entity.HasIndex(e => new { e.Id, e.Tur, e.Davaturid, e.Silindi, e.Durum }, "_dta_index_takip_13_1666821000__K1_K5_K4_K12_K8_2_3_6_7_9_10_11_23_24_25_26_28_38_52");

            entity.HasIndex(e => new { e.KazaIl, e.Id, e.Davaturid, e.DoktorOnay, e.Onay, e.Eski, e.TalepTuru, e.Durum, e.Silindi, e.Tur }, "_dta_index_takip_13_1666821000__K41_K1_K4_K84_K52_K10_K29_K8_K12_K5_2_3_6_7_9_11_23_24_25_26_28_38");

            entity.HasIndex(e => new { e.Durum, e.Silindi, e.Id }, "_dta_index_takip_13_1666821000__K8_K12_K1_16");

            entity.HasIndex(e => new { e.Durum, e.Silindi, e.Id }, "_dta_index_takip_13_1666821000__K8_K12_K1_28");

            entity.HasIndex(e => new { e.Durum, e.Silindi, e.Id, e.Goster }, "_dta_index_takip_13_1666821000__K8_K12_K1_K16_28");

            entity.HasIndex(e => new { e.Id, e.Tur, e.DoktorId, e.KusurbkId, e.Silindi }, "_dta_index_takip_iptaldosyalari");

            entity.HasIndex(e => new { e.Id, e.Durum, e.Silindi, e.Tur }, "_dta_index_takip_magdurgorusmerapor");

            entity.HasIndex(e => new { e.AcilisTarih, e.Silindi, e.Eski, e.Id }, "_dta_index_takip_ortakrap_5");

            entity.HasIndex(e => new { e.Id, e.Durum, e.Silindi, e.KapanisTarih }, "_dta_index_takip_ortakrap_6");

            entity.HasIndex(e => new { e.Durum, e.Silindi, e.Id, e.Goster, e.Tur, e.Onay }, "_dta_index_takip_oskan");

            entity.HasIndex(e => e.AcilisTarih, "acilis_tarih_INDEX");

            entity.HasIndex(e => new { e.AcilisTarih, e.Silindi }, "acilis_tarih_silindi_INDEX");

            entity.HasIndex(e => e.Silindi, "silindi_INDEX");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcilisTarih)
                .HasColumnType("datetime")
                .HasColumnName("acilis_tarih");
            entity.Property(e => e.Aktueryasonuc)
                .HasMaxLength(300)
                .HasColumnName("aktueryasonuc");
            entity.Property(e => e.AnketId).HasColumnName("anket_id");
            entity.Property(e => e.AnneBilgi)
                .HasMaxLength(100)
                .HasColumnName("anneBilgi");
            entity.Property(e => e.AvNote)
                .HasMaxLength(250)
                .HasColumnName("avNote");
            entity.Property(e => e.AvutServisAciklama)
                .HasMaxLength(500)
                .HasColumnName("avutServisAciklama");
            entity.Property(e => e.Azilname).HasColumnName("azilname");
            entity.Property(e => e.BabaBilgi)
                .HasMaxLength(100)
                .HasColumnName("babaBilgi");
            entity.Property(e => e.BolmudId).HasColumnName("bolmud_id");
            entity.Property(e => e.CezaAd)
                .HasMaxLength(250)
                .HasColumnName("cezaAd");
            entity.Property(e => e.CezaEsas)
                .HasMaxLength(150)
                .HasColumnName("cezaEsas");
            entity.Property(e => e.CezaYil)
                .HasMaxLength(150)
                .HasColumnName("cezaYil");
            entity.Property(e => e.Cinsiyet)
                .HasMaxLength(50)
                .HasColumnName("cinsiyet");
            entity.Property(e => e.CocukBilgi).HasColumnName("cocukBilgi");
            entity.Property(e => e.CocukSayi).HasColumnName("cocuk_sayi");
            entity.Property(e => e.DavaTarihi)
                .HasColumnType("datetime")
                .HasColumnName("dava_tarihi");
            entity.Property(e => e.Davali)
                .HasMaxLength(350)
                .HasColumnName("davali");
            entity.Property(e => e.Davaturid).HasColumnName("davaturid");
            entity.Property(e => e.Degisikisdosyasi)
                .HasMaxLength(100)
                .HasColumnName("degisikisdosyasi");
            entity.Property(e => e.DogumTarihi)
                .HasColumnType("datetime")
                .HasColumnName("dogum_tarihi");
            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.DoktorOnay).HasColumnName("doktorOnay");
            entity.Property(e => e.DosyaAsama)
                .HasMaxLength(1000)
                .HasColumnName("dosyaAsama");
            entity.Property(e => e.DrGorus).HasMaxLength(250);
            entity.Property(e => e.Durum)
                .HasMaxLength(50)
                .HasColumnName("durum");
            entity.Property(e => e.DurusmaSaat)
                .HasMaxLength(10)
                .HasColumnName("durusma_saat");
            entity.Property(e => e.DurusmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("durusma_tarih");
            entity.Property(e => e.EDevletSifre)
                .HasMaxLength(100)
                .HasColumnName("eDevletSifre");
            entity.Property(e => e.ENabizSifre)
                .HasMaxLength(100)
                .HasColumnName("eNabizSifre");
            entity.Property(e => e.EpikrizTani)
                .HasMaxLength(300)
                .HasColumnName("epikrizTani");
            entity.Property(e => e.EsBilgi)
                .HasMaxLength(100)
                .HasColumnName("esBilgi");
            entity.Property(e => e.EsasNo)
                .HasMaxLength(40)
                .HasColumnName("esas_no");
            entity.Property(e => e.EsasYil)
                .HasMaxLength(50)
                .HasColumnName("esas_yil");
            entity.Property(e => e.Eski).HasColumnName("eski");
            entity.Property(e => e.EskiDonem).HasColumnName("eski_donem");
            entity.Property(e => e.GeciciIsGöremezlik)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("geciciIsGöremezlik");
            entity.Property(e => e.GeriAcilma).HasColumnName("geriAcilma");
            entity.Property(e => e.Goster)
                .HasMaxLength(70)
                .HasColumnName("goster");
            entity.Property(e => e.Gsm)
                .HasMaxLength(20)
                .HasColumnName("gsm");
            entity.Property(e => e.GuncelleyenId).HasColumnName("guncelleyen_id");
            entity.Property(e => e.HaklilikOrani)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("haklilik_orani");
            entity.Property(e => e.Haksahip)
                .HasMaxLength(100)
                .HasColumnName("haksahip");
            entity.Property(e => e.IcraEsasno)
                .HasMaxLength(150)
                .HasColumnName("icra_esasno");
            entity.Property(e => e.IcraEsasyil)
                .HasMaxLength(150)
                .HasColumnName("icra_esasyil");
            entity.Property(e => e.IcraMdrAd)
                .HasMaxLength(250)
                .HasColumnName("icra_mdrAd");
            entity.Property(e => e.IcraTakipTarih).HasColumnType("datetime");
            entity.Property(e => e.KapanisTarih)
                .HasColumnType("datetime")
                .HasColumnName("kapanis_tarih");
            entity.Property(e => e.KararNo)
                .HasMaxLength(10)
                .HasColumnName("kararNo");
            entity.Property(e => e.KararYil)
                .HasMaxLength(10)
                .HasColumnName("kararYil");
            entity.Property(e => e.KazaIl)
                .HasMaxLength(100)
                .HasColumnName("kaza_il");
            entity.Property(e => e.KazaIlce)
                .HasMaxLength(100)
                .HasColumnName("kaza_ilce");
            entity.Property(e => e.KazaMevki)
                .HasMaxLength(250)
                .HasColumnName("kaza_mevki");
            entity.Property(e => e.KazaTarihi)
                .HasDefaultValue(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("kaza_tarihi");
            entity.Property(e => e.KesifTarih)
                .HasColumnType("datetime")
                .HasColumnName("kesif_tarih");
            entity.Property(e => e.KusurbkId).HasColumnName("kusurbk_id");
            entity.Property(e => e.KusurluaracBilgi)
                .HasMaxLength(200)
                .HasColumnName("kusurluarac_bilgi");
            entity.Property(e => e.Logg)
                .HasMaxLength(500)
                .HasColumnName("logg");
            entity.Property(e => e.MagdurAd)
                .HasMaxLength(50)
                .HasColumnName("magdur_ad");
            entity.Property(e => e.MagdurAdres)
                .HasMaxLength(200)
                .HasColumnName("magdurAdres");
            entity.Property(e => e.MagdurIlKod).HasColumnName("magdur_ilKod");
            entity.Property(e => e.MagdurIlceKod).HasColumnName("magdur_ilceKod");
            entity.Property(e => e.MagdurMaas)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("magdur_maas");
            entity.Property(e => e.MagdurSoyad)
                .HasMaxLength(50)
                .HasColumnName("magdur_soyad");
            entity.Property(e => e.MahSakOrn)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mahSakOrn");
            entity.Property(e => e.MahkemeAd)
                .HasMaxLength(150)
                .HasColumnName("mahkeme_ad");
            entity.Property(e => e.ManevitazTalep).HasColumnName("manevitaz_talep");
            entity.Property(e => e.MedeniHali)
                .HasMaxLength(50)
                .HasColumnName("medeni_hali");
            entity.Property(e => e.Meslek)
                .HasMaxLength(100)
                .HasColumnName("meslek");
            entity.Property(e => e.NotArabul)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("notArabul");
            entity.Property(e => e.NotArabulKusur)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("notArabulKusur");
            entity.Property(e => e.NotArabulSoran)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("notArabulSOran");
            entity.Property(e => e.NotArabulTutar)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("notArabulTutar");
            entity.Property(e => e.NotEvrakDevri)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("notEvrakDevri");
            entity.Property(e => e.NotPayDevri)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("notPayDevri");
            entity.Property(e => e.Nott)
                .HasMaxLength(250)
                .HasColumnName("nott");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.OnayDrSakatlikOran).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Payoran)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("payoran");
            entity.Property(e => e.Plaka)
                .HasMaxLength(100)
                .HasColumnName("plaka");
            entity.Property(e => e.PoliceNo)
                .HasMaxLength(100)
                .HasColumnName("police_no");
            entity.Property(e => e.PoliceTarih)
                .HasColumnType("datetime")
                .HasColumnName("policeTarih");
            entity.Property(e => e.PrimIds)
                .HasMaxLength(100)
                .HasColumnName("prim_ids");
            entity.Property(e => e.RHastane)
                .HasMaxLength(300)
                .HasColumnName("rHastane");
            entity.Property(e => e.RaporGonTar)
                .HasColumnType("datetime")
                .HasColumnName("raporGonTar");
            entity.Property(e => e.RaporTar)
                .HasDefaultValue(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("rapor_tar");
            entity.Property(e => e.RuhsatSahibi)
                .HasMaxLength(100)
                .HasColumnName("ruhsat_sahibi");
            entity.Property(e => e.SakatlikDurumu)
                .HasMaxLength(300)
                .HasColumnName("sakatlik_durumu");
            entity.Property(e => e.SakatlikOrani)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sakatlik_orani");
            entity.Property(e => e.SatinAlinanDosya)
                .HasDefaultValue(false)
                .HasColumnName("satinAlinanDosya");
            entity.Property(e => e.SavcilikAd)
                .HasMaxLength(250)
                .HasColumnName("savcilikAd");
            entity.Property(e => e.SavcilikEsas)
                .HasMaxLength(150)
                .HasColumnName("savcilikEsas");
            entity.Property(e => e.SavcilikYil)
                .HasMaxLength(150)
                .HasColumnName("savcilikYil");
            entity.Property(e => e.SigortaBasvuruTar)
                .HasColumnType("datetime")
                .HasColumnName("sigortaBasvuruTar");
            entity.Property(e => e.SigortaHasarNo)
                .HasMaxLength(150)
                .HasColumnName("sigortaHasarNo");
            entity.Property(e => e.SilTar)
                .HasColumnType("datetime")
                .HasColumnName("silTar");
            entity.Property(e => e.Silindi).HasColumnName("silindi");
            entity.Property(e => e.SorgulamaNot)
                .HasMaxLength(250)
                .IsFixedLength()
                .HasColumnName("sorgulama_not");
            entity.Property(e => e.Sorumluluk).HasColumnName("sorumluluk");
            entity.Property(e => e.SurucuAd)
                .HasMaxLength(50)
                .HasColumnName("surucuAd");
            entity.Property(e => e.SurucuMeslek)
                .HasMaxLength(100)
                .HasColumnName("surucu_meslek");
            entity.Property(e => e.THastane)
                .HasMaxLength(300)
                .HasColumnName("tHastane");
            entity.Property(e => e.TahminiDosyaTutar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tahminiDosyaTutar");
            entity.Property(e => e.TahminiSakatlik1)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tahminiSakatlik1");
            entity.Property(e => e.TahminiSakatlik2)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tahminiSakatlik2");
            entity.Property(e => e.TakipTalep).HasColumnName("takip_talep");
            entity.Property(e => e.TalepTuru)
                .HasMaxLength(50)
                .HasColumnName("talep_turu");
            entity.Property(e => e.TapuDurum).HasColumnName("tapu_durum");
            entity.Property(e => e.TazminatTutar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tazminat_tutar");
            entity.Property(e => e.TcKimlikNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tc_kimlik_no");
            entity.Property(e => e.Temyiz)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("temyiz");
            entity.Property(e => e.TemyizEsasNo)
                .HasMaxLength(50)
                .HasColumnName("temyizEsasNo");
            entity.Property(e => e.TemyizEsasyil)
                .HasMaxLength(50)
                .HasColumnName("temyizEsasyil");
            entity.Property(e => e.TemyizMahkemeAd)
                .HasMaxLength(100)
                .HasColumnName("temyizMahkemeAd");
            entity.Property(e => e.Temyizalt)
                .HasMaxLength(50)
                .HasColumnName("temyizalt");
            entity.Property(e => e.Tur).HasColumnName("tur");
            entity.Property(e => e.UzlasmaDurumu)
                .HasMaxLength(250)
                .HasColumnName("uzlasma_durumu");
            entity.Property(e => e.VekaletTuru)
                .HasMaxLength(50)
                .HasColumnName("vekalet_turu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
