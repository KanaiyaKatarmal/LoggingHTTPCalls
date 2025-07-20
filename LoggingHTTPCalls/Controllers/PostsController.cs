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
        public async Task<IActionResult> Get()
        {
            var result = await _postService.GetPostsAsync();
            return Content(result, "application/json");
        }

    }
}
