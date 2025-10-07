# Bridge Pattern

## Intent
Decouple an abstraction from its implementation so that the two can vary independently.

## Problem
You need to extend a class in two independent dimensions. Using inheritance creates a complex hierarchy.

## Solution
The Bridge pattern separates abstraction from implementation, putting them in separate class hierarchies that can vary independently.

## When to Use
- You want to avoid permanent binding between abstraction and implementation
- Both abstractions and implementations should be extensible by subclassing
- Changes in implementation should not impact clients
- You want to share an implementation among multiple objects

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Can develop platform-independent classes and apps
- Client code works with high-level abstractions
- Open/Closed Principle - introduce new abstractions and implementations independently

## Cons
- Code might become more complicated with many new classes
- Increased complexity in the design
