using System;

namespace Decorator
{
    // Component interface
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetCost()
        {
            return 2.00;
        }
    }

    // Base Decorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return coffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return coffee.GetCost();
        }
    }

    // Concrete Decorators
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return coffee.GetDescription() + ", Milk";
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.50;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return coffee.GetDescription() + ", Sugar";
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.25;
        }
    }

    public class WhipDecorator : CoffeeDecorator
    {
        public WhipDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return coffee.GetDescription() + ", Whipped Cream";
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.75;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Decorator Pattern Demo ===\n");

            // Simple coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            // Coffee with milk
            coffee = new MilkDecorator(new SimpleCoffee());
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            // Coffee with milk and sugar
            coffee = new SugarDecorator(new MilkDecorator(new SimpleCoffee()));
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            // Coffee with everything
            coffee = new WhipDecorator(
                new SugarDecorator(
                    new MilkDecorator(new SimpleCoffee())
                )
            );
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
