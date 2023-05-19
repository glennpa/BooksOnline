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
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private ApplicationDbContext _db;

		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;

		}

		public void Update(Product obj)
		{
			var objFromDb = _db.Products.FirstOrDefault(u=>u.Id==obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Description = obj.Description;
				objFromDb.ISBN= obj.ISBN;
				objFromDb.Author = obj.Author;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price = obj.Price;
				objFromDb.Price50 = obj.Price50;
				objFromDb.Price100 = obj.Price100;
				objFromDb.CategoryId = obj.CategoryId;
				objFromDb.CoverTypeId= obj.CoverTypeId;	
				if(objFromDb.ImageUrl != null)
				{
					objFromDb.ImageUrl = objFromDb.ImageUrl;
				}
			}
		}
	}
}
