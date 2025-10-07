# Design Patterns in C#

A comprehensive guide to design patterns in C#, inspired by the Gang of Four (GoF) book. This repository contains documentation and minimalistic code samples demonstrating each design pattern.

## Repository Structure

The patterns are organized into three main categories:

### Creational Patterns
Patterns that deal with object creation mechanisms.

- **[Singleton](./Creational/Singleton)** - Ensures a class has only one instance
- **[Factory Method](./Creational/FactoryMethod)** - Creates objects without specifying exact classes
- **[Abstract Factory](./Creational/AbstractFactory)** - Creates families of related objects
- **[Builder](./Creational/Builder)** - Constructs complex objects step by step
- **[Prototype](./Creational/Prototype)** - Creates new objects by copying existing ones

### Structural Patterns
Patterns that deal with object composition and relationships.

- **[Adapter](./Structural/Adapter)** - Allows incompatible interfaces to work together
- **[Bridge](./Structural/Bridge)** - Separates abstraction from implementation
- **[Composite](./Structural/Composite)** - Composes objects into tree structures
- **[Decorator](./Structural/Decorator)** - Adds behavior to objects dynamically
- **[Facade](./Structural/Facade)** - Provides a simplified interface to a complex system
- **[Flyweight](./Structural/Flyweight)** - Shares common state between multiple objects
- **[Proxy](./Structural/Proxy)** - Provides a surrogate or placeholder for another object

### Behavioral Patterns
Patterns that deal with object collaboration and responsibility.

- **[Chain of Responsibility](./Behavioral/ChainOfResponsibility)** - Passes requests along a chain of handlers
- **[Command](./Behavioral/Command)** - Encapsulates a request as an object
- **[Iterator](./Behavioral/Iterator)** - Accesses elements of a collection sequentially
- **[Mediator](./Behavioral/Mediator)** - Defines how objects interact
- **[Memento](./Behavioral/Memento)** - Captures and restores an object's state
- **[Observer](./Behavioral/Observer)** - Notifies multiple objects about state changes
- **[State](./Behavioral/State)** - Alters object behavior when its state changes
- **[Strategy](./Behavioral/Strategy)** - Defines a family of interchangeable algorithms
- **[Template Method](./Behavioral/TemplateMethod)** - Defines the skeleton of an algorithm
- **[Visitor](./Behavioral/Visitor)** - Separates algorithms from objects they operate on

## How to Use

Each pattern directory contains:
- `README.md` - Documentation explaining the pattern
- A minimalistic C# application demonstrating the pattern

### Requirements

These samples are built with:
- **.NET 10** - The latest LTS release with enhanced runtime performance
- **C# 14** - Featuring new language improvements including:
  - `field` keyword for cleaner property implementations
  - Null-conditional assignment (`?.=`)
  - Extension members and improved `Span<T>` support
  - Enhanced lambda expressions

To run the samples, install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

## Contributing

Feel free to contribute by adding more examples or improving existing documentation.