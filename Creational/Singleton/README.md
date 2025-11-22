# Singleton Pattern

## Intent

Ensure a class has only one instance and provide a global point of access to it.

## Problem

Sometimes you need to ensure that a class has exactly one instance. For example, a single database connection, a configuration manager, or a logging service shared across the application.

## Solution

The Singleton pattern ensures that a class has only one instance by:

- Making the constructor private
- Providing a static method that returns the single instance
- Storing the instance as a static variable

## Structure

```text
Singleton
├── private static instance
├── private constructor
└── public static GetInstance()
```

## When to Use

- When exactly one instance of a class is needed
- When the single instance should be accessible from a well-known access point
- When the sole instance should be extensible by subclassing

## C# Implementation

See the [Program.cs](./Program.cs) file for a thread-safe implementation example.

### How to Run

1. Create a .NET console project in this directory:

   ```bash
   dotnet new console -n Singleton -f net10.0
   ```

2. Replace the generated Program.cs with the provided one
3. Run the application:

   ```bash
   dotnet run
   ```

## Pros

- Controlled access to the sole instance
- Reduced namespace pollution
- Permits refinement of operations and representation
- Lazy initialization possible

## Cons

- Difficult to unit test
- Violates Single Responsibility Principle (manages its own lifecycle)
- Can hide dependencies
- Requires special care in multi-threaded applications
