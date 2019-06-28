using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStoreMvc.Models.Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        public ProductsRepository()
        {

        }

        public IEnumerable<Product> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products
                    .Include(nameof(Product.SubCategory))
                    .ToList();
            }
        }

        public Product Find(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products
                    .Include(nameof(Product.SubCategory))
                    .Single(p => p.Id == id);
            }
        }

        public Product Create(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

                db.Entry(product).Reload();
                return product;
            }
        }

        public Product Update(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();

                db.Entry(product).Reload();
                return product;
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    throw new ProductNotFoundException();
                }
                db.Entry(product).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }
    }
}