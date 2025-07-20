using LoggingHTTPCalls.Service;
using Microsoft.AspNetCore.Mvc;

    namespace LoggingHTTPCalls.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PostsController : Controller
        {
            private readonly PostService _postService;

            public PostsController(PostService postService)
            {
                _postService = postService;
            }

            // GET: api/posts
            [HttpGet]
            public async Task<IActionResult> GetPosts()
            {
                await _postService.CallExternalApiAsync();
                return Ok("Posts fetched successfully.");
            }

        }
    }
