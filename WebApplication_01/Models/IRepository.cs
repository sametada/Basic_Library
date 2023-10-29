using System.Linq.Expressions;

namespace WebApplication_01.Models
{
	public interface IRepository<T> where T: class
	{
		//T == kitap türü
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filtre);
		void Ekle(T entity);
		void Sil(T entity);
		void SilAralik(IEnumerable<T> entity);
	}
}
