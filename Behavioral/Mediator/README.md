# Mediator Pattern

## Intent
Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly.

## Problem
You have multiple objects that need to communicate with each other, creating a tangled web of dependencies that's hard to maintain and understand.

## Solution
The Mediator pattern centralizes complex communications and control logic between related objects into a single mediator object.

## When to Use
- A set of objects communicate in complex but well-defined ways
- Reusing an object is difficult because it communicates with many other objects
- Behavior distributed between several classes should be customizable without subclassing

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Single Responsibility Principle - extract communications into a single place
- Open/Closed Principle - introduce new mediators without changing components
- Reduces coupling between components
- Easier to reuse individual components

## Cons
- Over time a mediator can evolve into a God Object
- Can become overly complex
