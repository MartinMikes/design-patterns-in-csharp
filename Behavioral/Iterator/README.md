# Iterator Pattern

## Intent

Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

## Problem

You need to traverse a collection of objects without exposing its internal structure or depending on how it stores its elements.

## Solution

The Iterator pattern extracts the traversal behavior of a collection into a separate object called an iterator, providing a standard way to loop through items.

## When to Use

- To access a collection's contents without exposing its internal structure
- To support multiple traversals of aggregate objects
- To provide a uniform interface for traversing different structures

## C# Implementation

See the [Program.cs](./Program.cs) file for a music playlist iterator with forward and reverse traversal.

**Note:** C# has built-in iterator support through `IEnumerable<T>` and `IEnumerator<T>` interfaces.

## Pros

- Single Responsibility Principle - clean up client and collection code
- Open/Closed Principle - implement new types of collections and iterators
- Can iterate over the same collection in parallel
- Can delay iteration and continue when needed

## Cons

- Overkill if your app only works with simple collections
- Less efficient than going through elements of specialized collections directly
