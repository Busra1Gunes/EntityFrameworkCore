// See https://aka.ms/new-console-template for more information

public class Urun
{
	public int Id { get; set; }
	public string UrunAdi { get; set; }
	public float Fiyat { get; set; }
	public ICollection<Parca> Parcalar { get; set; }
}
