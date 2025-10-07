# Strategy Pattern

## Intent
Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## Problem
You have multiple algorithms or behaviors that do similar things but in different ways. Using conditional statements to choose between them makes the code hard to maintain and extend.

## Solution
The Strategy pattern defines a family of algorithms, puts each in a separate class, and makes their objects interchangeable at runtime.

## Structure
```
Context
├── strategy (reference to Strategy)
└── ExecuteStrategy()

Strategy (interface)
└── Execute()

ConcreteStrategyA, B, C
└── Execute() (different implementations)
```

## When to Use
- When you have many similar classes that only differ in behavior
- When you need different variants of an algorithm
- When a class has massive conditional statements that switch between different behaviors
- To isolate the business logic of a class from implementation details of algorithms

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Open/Closed Principle - can introduce new strategies without changing context
- Can swap algorithms at runtime
- Isolates implementation details from the code that uses them
- Can replace inheritance with composition

## Cons
- Increases the number of objects in the application
- Clients must be aware of different strategies to select the appropriate one
- May be overkill if you only have a couple of algorithms that rarely change
