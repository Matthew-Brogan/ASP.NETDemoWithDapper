using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ASP.netCoreDemo.Models
{
    public class ReviewsRepository: IReviewsRepository
    {
        private readonly IDbConnection _conn;
        public ReviewsRepository(IDbConnection conn)
        {
            this._conn = conn;
        }
        public IEnumerable<Reviews> GetReviews()
        {
            return _conn.Query<Reviews>("Select * from reviews;");
        }

        public void InsertReview(Reviews review)
        {
            _conn.Execute("insert into reviews (reviewer,comment) values (@name,@comment);",
               new { name = review.Reviewer, comment = review.Comment });
        }
        public Reviews AssignReview()
        {
            var review = new Reviews();
            return review;
        }
        public void UpdateReviews(Reviews review)
        {
            _conn.Execute("UPDATE reviews SET Reviewer = @name, Comment = @comment WHERE ProductID = @id",
                new { name = review.Reviewer, comment = review.Comment, id = review.ProductID });

        }
        public Reviews GetReview(int id)
        {
            return _conn.QuerySingle<Reviews>("SELECT * FROM Reviews WHERE ReviewID = @Id",
                new { Id = id });

        }

        public void DeleteReview(Reviews review)
        {
            _conn.Execute("Delete from reviews where reviewID = @id;",
                new { id = review.ReviewID });
        }
    }
}
