# Builder Pattern

## Intent
Separate the construction of a complex object from its representation so that the same construction process can create different representations.

## Problem
You need to create complex objects with many optional parameters or configuration steps. Using constructors with many parameters becomes unwieldy and error-prone.

## Solution
The Builder pattern provides a step-by-step approach to constructing objects. It separates the construction logic from the representation, allowing the same construction process to create different representations.

## Structure
```
Director
└── Construct() (uses Builder)

Builder (interface)
├── BuildPartA()
├── BuildPartB()
└── GetResult()

ConcreteBuilder
└── implements all building methods

Product
└── the complex object being built
```

## When to Use
- To avoid "telescoping constructor" anti-pattern
- When you want to create different representations of a product
- When construction process must allow different representations for the object being constructed
- When you need to construct composite trees or other complex objects

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Can construct objects step-by-step
- Can reuse the same construction code for different representations
- Single Responsibility Principle - isolates complex construction code from business logic
- More control over the construction process

## Cons
- Overall complexity increases due to multiple new classes
- Code may become more verbose
