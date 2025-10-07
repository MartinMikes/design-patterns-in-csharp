# Prototype Pattern

## Intent
Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

## Problem
You need to create new objects that are similar to existing objects, and object creation is expensive or complex.

## Solution
The Prototype pattern creates new objects by cloning existing objects (prototypes) rather than creating them from scratch.

## When to Use
- When the classes to instantiate are specified at runtime
- To avoid building a class hierarchy of factories parallel to product hierarchy
- When instances of a class can have only a few different combinations of state
- When object creation is expensive

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Can clone objects without coupling to their concrete classes
- Can get rid of repeated initialization code
- Convenient for producing complex objects

## Cons
- Cloning complex objects with circular references might be tricky
- Deep copy vs shallow copy considerations
