# Visitor Pattern

## Intent

Represent an operation to be performed on elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.

## Problem

You need to perform operations across a set of objects with different types/interfaces, and you want to avoid polluting their classes with these operations.

## Solution

The Visitor pattern suggests placing new behavior into a separate class called visitor, instead of integrating it into existing classes. Objects accept visitors and delegate execution to the visitor.

## When to Use

- You need to perform operations on all elements of a complex object structure
- You want to clean up business logic of auxiliary behaviors
- A behavior makes sense only in some classes of a class hierarchy, but not in others

## C# Implementation

See the [Program.cs](./Program.cs) file for file system visitors calculating sizes and printing tree structures.

## Pros

- Open/Closed Principle - introduce new behavior without changing existing classes
- Single Responsibility Principle - move multiple versions of same behavior into one class
- Can accumulate useful information while working with various objects

## Cons

- Need to update all visitors each time a class is added or removed from element hierarchy
- Elements might lack necessary access to private fields and methods that visitor needs
