namespace PrinciplesOfSOLID
{
    #region Without DIP
    // Low-level module (Specific implementation of notification)
    public class WrongEmailNotification
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"Sending Email to {to}: {message}");
        }
    }

    // High-level module depends on low-level module
    public class WrongFunService
    {
        private readonly WrongEmailNotification _wrongEmailNotification;

        public WrongFunService()
        {
            _wrongEmailNotification = new WrongEmailNotification(); // This is where tight coupling happens
        }

        public void ProcessOrder(string customerEmail)
        {
            Console.WriteLine("Order processed successfully.");
            _wrongEmailNotification.SendEmail(customerEmail, "Your order has been processed!");
        }
    }
    #endregion


    #region With DIP
    // We need abstraction: Contract for notifications
    public interface INotificationService
    {
        void Notify(string to, string message);
    }

    // Low-level module: Email notification implementation
    public class EmailNotification : INotificationService
    {
        public void Notify(string to, string message)
        {
            Console.WriteLine($"Sending Email to {to}: {message}");
        }
    }

    // Low-level module: SMS notification
    public class SmsNotification : INotificationService
    {
        public void Notify(string to, string message)
        {
            Console.WriteLine($"Sending SMS to {to}: {message}");
        }
    }

    // High-level module: Depends on abstraction
    public class FunService(INotificationService notificationService)
    {
        private readonly INotificationService _notificationService = notificationService;

        public void ProcessOrder(string customerContact)
        {
            Console.WriteLine("Order processed successfully.");
            _notificationService.Notify(customerContact, "Your order has been processed!");
        }
    }
    #endregion
}
