using System;
using System.Collections.Generic;

namespace Interpreter;

public sealed class Context
{
  private readonly Dictionary<string, int> variables = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

  public void Set(string name, int value) => variables[name] = value;

  public int Get(string name) => variables.TryGetValue(name, out var value)
    ? value
    : throw new KeyNotFoundException($"Variable '{name}' is not defined in the context.");
}

public interface IExpression
{
  int Interpret(Context context);
}

public sealed class NumberExpression(int value) : IExpression
{
  public int Value { get; } = value;

  public int Interpret(Context context) => Value;
}

public sealed class VariableExpression(string name) : IExpression
{
  public string Name
  {
    get;
    init => field = string.IsNullOrWhiteSpace(value)
      ? throw new ArgumentException("Variable name cannot be empty", nameof(value))
      : value;
  } = name;

  public int Interpret(Context context) => context.Get(Name);
}

public abstract class BinaryExpression(IExpression left, IExpression right) : IExpression
{
  protected IExpression Left { get; } = left;
  protected IExpression Right { get; } = right;

  public int Interpret(Context context)
  {
    var leftValue = Left.Interpret(context);
    var rightValue = Right.Interpret(context);
    return Apply(leftValue, rightValue);
  }

  protected abstract int Apply(int left, int right);
}

public sealed class AddExpression : BinaryExpression
{
  public AddExpression(IExpression left, IExpression right) : base(left, right) { }

  protected override int Apply(int left, int right) => left + right;
}

public sealed class SubtractExpression : BinaryExpression
{
  public SubtractExpression(IExpression left, IExpression right) : base(left, right) { }

  protected override int Apply(int left, int right) => left - right;
}

public sealed class MultiplyExpression : BinaryExpression
{
  public MultiplyExpression(IExpression left, IExpression right) : base(left, right) { }

  protected override int Apply(int left, int right) => left * right;
}

public sealed class DivideExpression : BinaryExpression
{
  public DivideExpression(IExpression left, IExpression right) : base(left, right) { }

  protected override int Apply(int left, int right)
    => right == 0
      ? throw new DivideByZeroException("Interpreter attempted to divide by zero.")
      : left / right;
}

public static class ExpressionParser
{
  public static IExpression ParsePostfix(string input)
  {
    var stack = new Stack<IExpression>();
    foreach (var token in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
      stack.Push(token switch
      {
        "+" => CreateBinary(stack, (l, r) => new AddExpression(l, r)),
        "-" => CreateBinary(stack, (l, r) => new SubtractExpression(l, r)),
        "*" => CreateBinary(stack, (l, r) => new MultiplyExpression(l, r)),
        "/" => CreateBinary(stack, (l, r) => new DivideExpression(l, r)),
        _ => int.TryParse(token, out var number)
          ? new NumberExpression(number)
          : new VariableExpression(token)
      });
    }

    return stack.Count == 1
      ? stack.Pop()
      : throw new InvalidOperationException("Invalid expression. Ensure it is in postfix form.");
  }

  private static IExpression CreateBinary(Stack<IExpression> stack, Func<IExpression, IExpression, IExpression> factory)
  {
    if (stack.Count < 2)
    {
      throw new InvalidOperationException("Insufficient operands for binary operator.");
    }

    var right = stack.Pop();
    var left = stack.Pop();
    return factory(left, right);
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Interpreter Pattern Demo ===");
    Console.WriteLine();

    var context = new Context();
    context.Set("sales", 42);
    context.Set("bonus", 3);
    context.Set("tax", 2);

    var expression = ExpressionParser.ParsePostfix("sales bonus + tax * 10 +");
    var result = expression.Interpret(context);
    Console.WriteLine("Expression: (sales + bonus) * tax + 10");
    Console.WriteLine($"Result: {result}");
    Console.WriteLine();

    var second = ExpressionParser.ParsePostfix("sales 5 / bonus -");
    var secondResult = second.Interpret(context);
    Console.WriteLine("Expression: (sales / 5) - bonus");
    Console.WriteLine($"Result: {secondResult}");

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
