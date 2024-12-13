namespace AsynchronousProgramming.BasicExample
{
    internal class StaticTaskMethods
    {
        public static async Task TaskRun()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Executing a CPU-intensive task asynchronously.");
                Thread.Sleep(3000);
            });
            Console.WriteLine("Task completed.");
        }

        public static async Task TaskDelay()
        {
            Console.WriteLine("Starting delay...");
            await Task.Delay(2000); // Delay for 2 seconds
            Console.WriteLine("Delay completed.");
        }

        public static async Task TaskWhenAll()
        {
            var task1 = Task.Delay(2000);
            var task2 = Task.Delay(3000);

            Console.WriteLine("Waiting for all tasks to complete...");
            await Task.WhenAll(task1, task2);
            Console.WriteLine("All tasks completed.");
        }

        public static async Task TaskWhenAny()
        {
            var task1 = Task.Delay(2000);
            var task2 = Task.Delay(3000);

            Console.WriteLine("Waiting for the first task to complete...");
            await Task.WhenAny(task1, task2);
            Console.WriteLine("One task has completed.");
        }

        public static Task<int> TaskFromResult()
        {
            Console.WriteLine("Returning a completed task with result.");
            return Task.FromResult(42); // Returns a completed task with the result 42
        }

        public static Task CompletedTask()
        {
            Console.WriteLine("Returning a completed task with no result.");
            return Task.CompletedTask;
        }

        // File downloader methods
        public async Task DownloadFileAsync(string fileUrl)
        {
            Console.WriteLine($"Starting to download file from {fileUrl}...");
            await Task.Delay(2000); // 2 seconds delay
            Console.WriteLine($"File downloaded from {fileUrl}");
        }

        public async Task DownloadMultipleFilesAsync(IEnumerable<string> fileUrls)
        {
            var downloadTasks = fileUrls.Select(url => DownloadFileAsync(url));
            await Task.WhenAll(downloadTasks);
            Console.WriteLine("All files downloaded.");
        }
    }
}
