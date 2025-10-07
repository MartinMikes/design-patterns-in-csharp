# Adapter Pattern

## Intent
Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

## Problem
You have existing code that expects one interface, but you need to work with a class that has a different interface. You can't modify the existing class, but you need to make it compatible.

## Solution
The Adapter pattern creates a wrapper class (adapter) that translates calls from the expected interface to the incompatible class's interface.

## Structure
```
Target (interface that client expects)
└── Request()

Adapter (implements Target)
├── adaptee (reference to Adaptee)
└── Request() (calls adaptee.SpecificRequest())

Adaptee (existing incompatible class)
└── SpecificRequest()
```

## When to Use
- You want to use an existing class with an incompatible interface
- You want to create a reusable class that cooperates with unrelated classes
- You need to use several existing subclasses, but adapting their interface by subclassing is impractical

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Single Responsibility Principle - separates interface conversion from business logic
- Open/Closed Principle - can introduce new adapters without breaking existing code
- Allows classes with incompatible interfaces to collaborate

## Cons
- Overall complexity increases due to new interfaces and classes
- Sometimes it's simpler to change the service class to match the rest of your code
