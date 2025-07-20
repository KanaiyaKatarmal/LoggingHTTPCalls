namespace LoggingHTTPCalls.Service
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyClient");
        }

        public async Task<string> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
