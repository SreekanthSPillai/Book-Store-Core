using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStoreMvc.Models.Repository
{
    public class CategoriesRepository : IRepository<Category>
    {
        public IEnumerable<Category> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categories
                    .Include(nameof(Category.SubCategories))
                    .ToList();
            }
        }

        public Product Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}