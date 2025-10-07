# Decorator Pattern

## Intent
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

## Problem
You need to add behavior to individual objects without affecting other objects of the same class. Using inheritance to extend behavior results in a rigid, static solution.

## Solution
The Decorator pattern wraps an object with another object that adds new behavior, while keeping the interface the same. Multiple decorators can be stacked to combine behaviors.

## Structure
```
Component (interface)
└── Operation()

ConcreteComponent
└── Operation()

Decorator (implements Component)
├── component (reference to Component)
└── Operation() (calls component.Operation())

ConcreteDecorator
└── Operation() (adds behavior before/after calling base.Operation())
```

## When to Use
- To add responsibilities to individual objects dynamically and transparently
- For responsibilities that can be withdrawn
- When extension by subclassing is impractical (class explosion)
- To add behavior without modifying existing code

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- More flexible than static inheritance
- Avoids feature-laden classes high up in the hierarchy
- Can add/remove responsibilities at runtime
- Single Responsibility Principle - dividing functionality between classes

## Cons
- Hard to remove a specific wrapper from the wrappers stack
- Hard to implement decorator that doesn't depend on order in the stack
- Initial configuration code might look ugly with many layers
