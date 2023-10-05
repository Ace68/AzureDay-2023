using System.Linq.Expressions;
using BrewUp.ReadModel.Entities;

namespace BrewUp.ReadModel
{
	public interface IQueries<T> where T : EntityBase
	{
		Task<T> GetById(string id);
		Task<PagedResult<T>> GetByFilter(Expression<Func<T, bool>> query, int page, int pageSize);
	}
}
