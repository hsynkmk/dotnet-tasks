using PrinciplesOfSOLID;

// Single responsibility principle (SRP)
#if false
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


// Open/Closed Principle (OCP)
#if false
Console.WriteLine("Open/Closed Principle (OCP)");

Console.WriteLine("--Without OCP--");
var wrongPaymentProcessor = new WrongPaymentProcessor();
wrongPaymentProcessor.ProcessPayment("CreditCard");
wrongPaymentProcessor.ProcessPayment("PayPal");

Console.WriteLine("\n--With OCP--");
var paymentProcessor = new PaymentProcessor();
var creditCardPayment = new CreditCardPayment();
var payPalPayment = new PayPalPayment();
var bitcoinPayment = new BitcoinPayment();

paymentProcessor.ProcessPayment(creditCardPayment);
paymentProcessor.ProcessPayment(payPalPayment);
paymentProcessor.ProcessPayment(bitcoinPayment);
#endif

// Liskov Substitution Principle (LSP)
#if true
Console.WriteLine("Liskov Substitution Principle (LSP)");

Console.WriteLine("--Without LSP--");

WrongRectangle badSquare = new WrongSquare();
badSquare.Width = 5;
badSquare.Height = 10; // Width also becomes 10
Console.WriteLine($"Area (incorrect): {badSquare.CalculateArea()}");


Console.WriteLine("\n--With LSP--");
var rectangle = new Rectangle(5, 10);
var square = new Square(7);

var areaCalculator = new AreaCalculator();
areaCalculator.PrintArea(rectangle);
areaCalculator.PrintArea(square);
#endif


Console.ReadLine();
