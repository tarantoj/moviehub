using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHub.Api.Models;
using MovieHub.Database;

namespace MovieHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController(ILogger<ReviewController> logger, MovieHubContext movieHubContext) : ControllerBase
{
    /*[HttpPost]*/
    /*public async Task<ActionResult> Create([FromBody] ReviewDto review)*/
    /*{*/
    /*    var savedReview = await movieHubContext.Reviews.AddAsync(mapper.Map<Review>(review));*/
    /**/
    /*    await movieHubContext.SaveChangesAsync();*/
    /**/
    /*    return CreatedAtAction(nameof(Get), new { savedReview.Entity.Id }, savedReview.Entity);*/
    /*}*/
    /**/
    /*[HttpGet("{id}")]*/
    /*public Task<ReviewDto> Get(int id)*/
    /*{*/
    /*    return mapper.ProjectTo<ReviewDto>(movieHubContext.Reviews.Where(r => r.Id == id)).SingleAsync();*/
    /*}*/
}
