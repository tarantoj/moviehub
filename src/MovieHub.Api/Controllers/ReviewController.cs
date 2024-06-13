using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHub.Api.Models;
using MovieHub.Database;

namespace MovieHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController(ILogger<ReviewController> logger, MovieHubContext movieHubContext)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ReviewDto review)
    {
        var savedReview = await movieHubContext.Reviews.AddAsync(new Review
        {
            Comment = review.Comment,
            MovieId = review.MovieId,
            ReviewDate = review.ReviewDate,
            Score = review.Score
        });

        await movieHubContext.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { savedReview.Entity.Id }, new ReviewDto
        {
            Id = savedReview.Entity.Id,
            MovieId = savedReview.Entity.MovieId,
            ReviewDate = savedReview.Entity.ReviewDate,
            Score = savedReview.Entity.Score,
            Comment = savedReview.Entity.Comment
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> Get(int id)
    {
        var review = await movieHubContext.Reviews
            .Select(r => new ReviewDto
            {
                Id = r.Id,
                MovieId = r.MovieId,
                ReviewDate = r.ReviewDate,
                Score = r.Score,
                Comment = r.Comment
            })
            .FirstOrDefaultAsync(r => r.Id == id);

        if (review is null) return NotFound();

        return Ok(review);
    }
}