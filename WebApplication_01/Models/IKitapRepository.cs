namespace WebApplication_01.Models
{
	public interface IKitapRepository : IRepository<Kitap>
	{
		void Guncelle(Kitap kitap);
		void Kaydet();

	}
}
