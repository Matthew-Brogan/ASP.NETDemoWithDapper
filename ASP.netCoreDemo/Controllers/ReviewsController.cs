using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.netCoreDemo.Models;

namespace ASP.netCoreDemo.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepository repo;

        public ReviewsController(IReviewsRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult ReviewIndex()
        {
            var rev = repo.GetReviews();
            return View(rev);
        }
        public IActionResult InsertReview()
        {
            var rev = repo.AssignReview();
            return View(rev);
        }
        public IActionResult InsertReviewToDatabase(Reviews reviewToInsert)
        {
            repo.InsertReview(reviewToInsert);
            return RedirectToAction("ReviewIndex");
        }
        public IActionResult UpdateReviews(int id)
        {
            Reviews rev = repo.GetReview(id);

            repo.UpdateReviews(rev);

            if (rev == null)
            {
                return View("ReviewNotFound");
            }

            return View(rev);
        }
        public IActionResult ViewReview(int id)
        {
            var review = repo.GetReview(id);
            return View(review);
        }
        public IActionResult UpdateReviewToDatabase(Reviews review)
        {
            repo.UpdateReviews(review);

            return RedirectToAction("ViewReview", new { id = review.ReviewID });
        }
        public IActionResult DeleteReview(Reviews review)
        {
            repo.DeleteReview(review);
            return RedirectToAction("ReviewIndex");
        }

    }
}
