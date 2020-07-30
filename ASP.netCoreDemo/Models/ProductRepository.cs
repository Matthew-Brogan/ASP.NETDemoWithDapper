using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.netCoreDemo.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public IEnumerable<Products> GetAllProducts()
        {
            return _conn.Query<Products>("SELECT * FROM PRODUCTS;");
        }

        public Products GetProduct(int id)
        {
            return (Products)_conn.QuerySingle<Products>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });

        }

        public void UpdateProduct(Products product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });

        }

        public void InsertProduct(Products productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });

        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");

        }

        public Products AssignProducts()
        {
            var categoryList = GetCategories();
            var product = new Products();
            product.Categories = categoryList;

            return product;

        }

        public void DeleteProduct(Products product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                                  new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                                       new { id = product.ProductID });
        }

        public IEnumerable<Reviews> GetReviews()
        {
           return _conn.Query<Reviews>("Select * from reviews;");
        }

        public void InsertReview(Reviews review)
        {
             _conn.Execute("Insert Into reviews (Reviewer,Comment) Values (@name,@comment);",
                new { name = review.Reviewer, comment = review.Comment });
        }

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
    }
}
