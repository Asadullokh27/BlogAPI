using BlogAPI.Application.Services.BlogPostServices;
using BlogAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {

        private readonly IBlogPostService _blogpostService;

        public BlogPostController(IBlogPostService blogpostService)
        {
            _blogpostService = blogpostService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            try
            {
                var posts = await _blogpostService.GetAllBlogPosts();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            try
            {
                var post = await _blogpostService.GetBlogPostById(id);
                if (post == null)
                    return NotFound();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(BlogPostDTO blogpostDTO)
        {
            try
            {
                var post = await _blogpostService.CreateBlogPost(blogpostDTO);
                return CreatedAtAction(nameof(GetBlogPostById), new { id = post.Id }, post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogpostById(int id, BlogPostDTO blogposttDTO)
        {
            try
            {
                var updatedBlogPost = await _blogpostService.UpdateBlogpostById(id, blogposttDTO);
                if (updatedBlogPost == null)
                    return NotFound();

                return Ok(updatedBlogPost);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPostById(int id)
        {
            try
            {
                var result = await _blogpostService.DeleteBlogPostById(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
