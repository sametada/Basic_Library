namespace WebApplication_01.Models
{
	public interface IKitapTuruRepository : IRepository<KitapTuru>
	{
		void Guncelle(KitapTuru kitapTuru);
		void Kaydet();

	}
}
