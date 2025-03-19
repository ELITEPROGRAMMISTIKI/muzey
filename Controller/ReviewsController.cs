using Microsoft.AspNetCore.Mvc;
using muzey.Data;
using muzey.Models;
using Microsoft.AspNetCore.Identity;

namespace muzey.Controller
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto review)
        {
            if (string.IsNullOrEmpty(review.Text))
            {
                return BadRequest("Text is required");
            }

            string userName = "Гость";
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    userName = user.UserName;
                }
            }

            var newReview = new Review
            {
                Text = review.Text,
                DateReview = DateTime.Now,
                Name = userName
            };

            _context.Reviews.Add(newReview);
            await _context.SaveChangesAsync();
            
            return Ok(newReview);
        }

        [HttpGet("get")]
        public IActionResult GetReviews()
        {
            var reviews = _context.Reviews.OrderByDescending(r => r.DateReview).ToList();
            return Ok(reviews);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return Forbid();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("checkAdmin")]
        public async Task<IActionResult> CheckAdminRole()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Ok(false);
            }
            
            var isAdmin = await _userManager.IsInRoleAsync(user, "admin");
            return Ok(isAdmin);
        }
    }

    public class ReviewDto
    {
        public string Text { get; set; }
    }
}