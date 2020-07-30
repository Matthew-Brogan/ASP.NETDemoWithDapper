using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.netCoreDemo.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAllProducts();
        public Products GetProduct(int id);
        public void UpdateProduct(Products product);
        public void InsertProduct(Products productToInsert);
        public IEnumerable<Category> GetCategories();
        public Products AssignProducts();
        public void DeleteProduct(Products product);
        public IEnumerable<Reviews> GetReviews();
        public void InsertReview(Reviews review);
        
    }
}
