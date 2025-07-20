namespace LoggingHTTPCalls.Service
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyClient");
        }

        public async Task CallExternalApiAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            // Handle response...
        }
    }
}
