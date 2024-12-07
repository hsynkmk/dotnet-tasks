using PrinciplesOfSOLID;

// Single responsibility principle (SRP)
#if true
Console.WriteLine("Single responsibility principle (SRP)");

Console.WriteLine("--Without SRP--");
var wrongOrderManager = new WrongOrderManager();
wrongOrderManager.ProcessOrder();
wrongOrderManager.LogOrder();
wrongOrderManager.NotifyCustomer();

Console.WriteLine("\n--With SRP--");
var orderProcessor = new OrderProcessor();
var logger = new Logger();
var notificationService = new NotificationService();

var orderService = new OrderService(orderProcessor, logger, notificationService);
orderService.Process();
#endif


Console.ReadLine();

