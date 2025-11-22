# Interpreter Pattern

## Intent

Convert language grammar into an object model so that statements can be evaluated by interpreting that model.

## Problem

Applications sometimes embed a small language (formulas, filters, commands). Recompiling the grammar every time is brittle, and tightly coupling parsing/evaluation logic with other code becomes hard to maintain.

## Solution

Define an abstract expression interface with a shared `Interpret` method. Concrete terminal and non-terminal expressions compose together to represent the grammar. A context supplies shared state (such as variables), and evaluation happens by recursively interpreting the expression tree.

## Structure

```text
Context
├── variable bindings

AbstractExpression
├── Interpret(context)

TerminalExpression
└── Interpret(context)

NonTerminalExpression
└── Interpret(context)
    └── references other expressions
```

## When to Use

- You have a simple grammar that changes infrequently
- You want to represent sentences as object trees for flexibility
- You need to add new grammar constructs without editing existing code

## C# Implementation

See the [Program.cs](./Program.cs) file for a runnable arithmetic interpreter example.

## How to Run

1. Create a .NET console project in this directory:

    ```bash
    dotnet new console -n Interpreter -f net10.0
    ```

2. Replace the generated `Program.cs` with the provided sample
3. Run the application:

    ```bash
    dotnet run
    ```

## Pros

- Grammar rules live in code and are easy to extend
- Enables building reusable AST nodes
- Encourages separation between parsing and evaluation

## Cons

- Complex grammars lead to many classes
- Expression trees can become deeply nested and harder to debug

## Related Patterns

- **Composite** – expression trees leverage the same recursive structure
- **Visitor** – can traverse expression trees to implement alternative behaviors
