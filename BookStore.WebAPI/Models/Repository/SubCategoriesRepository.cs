using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStoreMvc.Models.Repository
{
    public class SubCategoriesRepository : IRepository<SubCategory>
    {
        public SubCategoriesRepository()
        {

        }

        public Product Create(SubCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SubCategories
                    .Include(nameof(SubCategory.Category))
                    .ToList();
            }
        }

        public SubCategory Update(SubCategory item)
        {
            throw new NotImplementedException();
        }
    }
}