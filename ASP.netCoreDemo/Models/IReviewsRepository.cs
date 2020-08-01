using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.netCoreDemo.Models
{
   public interface IReviewsRepository
    {
        public IEnumerable<Reviews> GetReviews();
        public void InsertReview(Reviews review);
        public Reviews AssignReview();
        public void UpdateReviews(Reviews review);
        public Reviews GetReview(int id);
        public void DeleteReview(Reviews review);

    }


}
