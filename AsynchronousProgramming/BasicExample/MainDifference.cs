

namespace AsynchronousProgramming.BasicExample
{
    internal class MainDifference
    {
        public void DownloadFileSync(string fileUrl)
        {
            Console.WriteLine($"Starting to download file from {fileUrl}...");
            Thread.Sleep(5000); // 5 seconds delay
            Console.WriteLine($"File downloaded from {fileUrl}");
        }

        public async Task DownloadFileAsync(string fileUrl)
        {
            Console.WriteLine($"Starting to download file from {fileUrl}...");
            await Task.Delay(5000); // 5 seconds delay
            Console.WriteLine($"File downloaded from {fileUrl}");
        }
    }
}
