using BooksOnline.DataAccess.Repository.IRepository;
using BooksOnline.Models;
using BooksOnlineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnline.DataAccess.Repository
{
	public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
	{
		private ApplicationDbContext _db;

		public CoverTypeRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;

		}

		public void Update(CoverType obj)
		{
			_db.CoverTypes.Update(obj);
		}
	}
}
