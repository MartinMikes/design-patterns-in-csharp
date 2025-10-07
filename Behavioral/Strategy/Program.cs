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
        // Using C# 14 field keyword for property
        public string CardNumber
        {
            get;
            init => field = value ?? throw new ArgumentNullException(nameof(value));
        }

        public CreditCardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Credit Card ending in {CardNumber.Substring(CardNumber.Length - 4)}");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        // Using C# 14 field keyword
        public string Email
        {
            get;
            init => field = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PayPalPayment(string email)
        {
            Email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using PayPal account {Email}");
        }
    }

    public class BitcoinPayment : IPaymentStrategy
    {
        // Using C# 14 field keyword
        public string WalletAddress
        {
            get;
            init => field = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BitcoinPayment(string walletAddress)
        {
            WalletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Bitcoin wallet {WalletAddress}");
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
            // Using C# 14 null-conditional assignment
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
