namespace LoggingHTTPCalls.DelegateHandler
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingHandler> _logger;

        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log Request
            _logger.LogInformation("Request: {method} {url}", request.Method, request.RequestUri);

            if (request.Content != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                _logger.LogInformation("Request Body: {body}", requestBody);
            }

            // Call the inner handler
            var response = await base.SendAsync(request, cancellationToken);

            // Log Response
            _logger.LogInformation("Response: {statusCode}", response.StatusCode);

            if (response.Content != null)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Response Body: {body}", responseBody);
            }

            return response;
        }
    }
}
