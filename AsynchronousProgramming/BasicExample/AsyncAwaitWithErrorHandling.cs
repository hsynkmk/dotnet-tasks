namespace AsynchronousProgramming.BasicExample
{
    internal class AsyncAwaitWithErrorHandling
    {

        private readonly HttpClient _httpClient;

        public AsyncAwaitWithErrorHandling()
        {
            _httpClient = new HttpClient();
        }

        public async Task DownloadFileAsync(string fileUrl, string savePath)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                throw new ArgumentException("File URL cannot be null or empty.", nameof(fileUrl));

            if (string.IsNullOrWhiteSpace(savePath))
                throw new ArgumentException("Save path cannot be null or empty.", nameof(savePath));

            Console.WriteLine($"Starting download from {fileUrl}...");

            try
            {
                using var response = await _httpClient.GetAsync(fileUrl);

                response.EnsureSuccessStatusCode();

                var fileBytes = await response.Content.ReadAsByteArrayAsync();

                await SaveFileAsync(savePath, fileBytes);

                Console.WriteLine($"File downloaded and saved to {savePath}.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private async Task SaveFileAsync(string savePath, byte[] fileBytes)
        {
            Console.WriteLine($"Simulating saving file to {savePath}...");
            await Task.Delay(1000); // 1 second delay
            Console.WriteLine("File save simulation complete.");
        }
    }
}
