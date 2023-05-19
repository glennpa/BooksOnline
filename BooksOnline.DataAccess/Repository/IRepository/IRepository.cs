using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnline.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		//T - Category

		//Get or Find Data
		T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

		//Get All Data
		IEnumerable<T> GetAll(string? includeProperties = null);

		//Add Data
		void Add(T entity);

		//Remove Data
		void Remove(T entity);

		//Remove Range of Data
		void RemoveRange(IEnumerable<T> entity);
	}
}
