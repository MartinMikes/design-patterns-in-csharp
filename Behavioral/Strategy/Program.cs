using System;

namespace Strategy
{
    // Strategy interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // Concrete Strategies
    public class CreditCardPayment : IPaymentStrategy
    {
        private string cardNumber;

        public CreditCardPayment(string cardNumber)
        {
            this.cardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Credit Card ending in {cardNumber.Substring(cardNumber.Length - 4)}");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        private string email;

        public PayPalPayment(string email)
        {
            this.email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using PayPal account {email}");
        }
    }

    public class BitcoinPayment : IPaymentStrategy
    {
        private string walletAddress;

        public BitcoinPayment(string walletAddress)
        {
            this.walletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Bitcoin wallet {walletAddress}");
        }
    }

    // Context
    public class ShoppingCart
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }

        public void Checkout(decimal amount)
        {
            if (paymentStrategy == null)
            {
                Console.WriteLine("Please select a payment method");
                return;
            }

            paymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Strategy Pattern Demo ===\n");

            var cart = new ShoppingCart();
            decimal totalAmount = 250.00m;

            // Pay with Credit Card
            Console.WriteLine("Paying with Credit Card:");
            cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456"));
            cart.Checkout(totalAmount);

            // Pay with PayPal
            Console.WriteLine("\nPaying with PayPal:");
            cart.SetPaymentStrategy(new PayPalPayment("user@example.com"));
            cart.Checkout(totalAmount);

            // Pay with Bitcoin
            Console.WriteLine("\nPaying with Bitcoin:");
            cart.SetPaymentStrategy(new BitcoinPayment("1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"));
            cart.Checkout(totalAmount);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
