namespace PrinciplesOfSOLID
{
    #region Without SRP
    public class WrongOrderManager
    {
        public void ProcessOrder()
        {
            Console.WriteLine($"{this.GetType().Name} -> Processing the order...");
        }

        public void LogOrder()
        {
            Console.WriteLine($"{this.GetType().Name} -> Logging order...");
        }

        public void NotifyCustomer()
        {
            Console.WriteLine($"{this.GetType().Name} -> Sending notification to the customer...");
        }
    }
    #endregion


    #region With SRP
    public class OrderProcessor
    {
        public void ProcessOrder()
        {
            Console.WriteLine($"{this.GetType().Name} -> Processing the order...");
        }
    }

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{this.GetType().Name} -> Log: {message}");
        }
    }

    public class NotificationService
    {
        public void NotifyCustomer(string message)
        {
            Console.WriteLine($"{this.GetType().Name} -> Notification: {message}");
        }
    }
    #endregion


    #region Simple Service Without Violating SRP
    public class OrderService(OrderProcessor orderProcessor, Logger logger, NotificationService notificationService)
    {
        private readonly OrderProcessor _orderProcessor = orderProcessor;
        private readonly Logger _logger = logger;
        private readonly NotificationService _notificationService = notificationService;

        public void Process()
        {
            _orderProcessor.ProcessOrder();
            _logger.Log("Order has been processed.");
            _notificationService.NotifyCustomer("Your order has been processed successfully.");
        }
    }
    #endregion
}
