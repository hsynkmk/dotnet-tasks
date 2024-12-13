using AsynchronousProgramming.BasicExample;

// Difference between synchronous and asynchronous file download
#if false
var fileDownloader = new MainDifference();

Console.WriteLine("Synchronous Download:");
fileDownloader.DownloadFileSync("https://www.w3schools.com/cs/index.php");

Console.WriteLine("\nAsynchronous Download:");
await fileDownloader.DownloadFileAsync("https://www.w3schools.com/cs/index.php");

Console.WriteLine("\nDone.\n\n\n");
#endif

// Static Task Methods
#if false
var taskFileDownloader = new StaticTaskMethods();
await fileDownloader.DownloadFileAsync("http://example.com/file1");

var fileUrls = new List<string>
        {
            "https://www.w3schools.com/cs/index.php",
            "https://www.w3schools.com/cs/cs_intro.php",
            "https://www.w3schools.com/cs/cs_getstarted.php"
        };

await taskFileDownloader.DownloadMultipleFilesAsync(fileUrls);

Console.WriteLine("Operations completed.");
#endif

// Async/Await with Error Handling
#if true
var fileDownloader = new AsyncAwaitWithErrorHandling();

string validUrl = "https://www.w3schools.com/cs/index.php";
string invalidUrl = "funny-url";
string savePath = "C:\\Downloads\\async_await.txt";

Console.WriteLine("Attempting to download a valid file:");
await fileDownloader.DownloadFileAsync(validUrl, savePath);

Console.WriteLine("\nAttempting to download from an invalid URL:");
await fileDownloader.DownloadFileAsync(invalidUrl, savePath);

Console.WriteLine("\nProgram finished.");
#endif

Console.ReadKey();