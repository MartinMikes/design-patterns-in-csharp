# Factory Method Pattern

## Intent
Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

## Problem
You need to create objects, but the exact type of object needed isn't known until runtime. Hard-coding the object creation makes the code inflexible and difficult to extend.

## Solution
The Factory Method pattern provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

## Structure
```
Creator (abstract)
├── FactoryMethod() (abstract)
└── AnOperation()
    
ConcreteCreator
└── FactoryMethod() (returns ConcreteProduct)

Product (interface)
└── ConcreteProduct (implements Product)
```

## When to Use
- A class can't anticipate the type of objects it needs to create
- A class wants its subclasses to specify the objects it creates
- Classes delegate responsibility to one of several helper subclasses

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Avoids tight coupling between creator and concrete products
- Single Responsibility Principle - product creation in one place
- Open/Closed Principle - can introduce new product types without breaking existing code

## Cons
- Code can become more complicated with many new subclasses
- Requires subclassing just to create objects
