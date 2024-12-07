using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinciplesOfSOLID
{
    #region Without OCP
    public class WrongPaymentProcessor
    {
        public void ProcessPayment(string paymentType)
        {
            if (paymentType == "CreditCard")
            {
                Console.WriteLine($"{this.GetType().Name} -> Processing with Credit Card...");
            }
            else if (paymentType == "PayPal")
            {
                Console.WriteLine($"{this.GetType().Name} -> Processing with PayPal...");
            }
            else
            {
                throw new NotImplementedException($"{this.GetType().Name} -> Payment type not supported.");
            }
        }
    }
    #endregion


    #region With OCP
    #region interface
    public interface IPaymentMethod
    {
        void ProcessPayment();
    }
    #endregion

    #region PaymentMethods
    public class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine($"{this.GetType().Name} -> Processing with Credit Card...");
        }
    }

    public class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine($"{this.GetType().Name} -> Processing with PayPal...");
        }
    }

    // Add a new payment method without modifying existing code and this is the demostration of Open/Closed Principle
    public class BitcoinPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine($"{this.GetType().Name} -> Processing with Bitcoin...");
        }
    }
    #endregion

    public class PaymentProcessor
    {
        public void ProcessPayment(IPaymentMethod paymentMethod)
        {
            paymentMethod.ProcessPayment();
        }
    }
    #endregion
}
