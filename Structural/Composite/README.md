# Composite Pattern

## Intent

Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions uniformly.

## Problem

You need to work with tree structures of objects where individual objects and groups of objects should be treated uniformly.

## Solution

The Composite pattern composes objects into tree structures and allows treating individual objects and compositions of objects uniformly through a common interface.

## When to Use

- You want to represent part-whole hierarchies of objects
- You want clients to ignore the difference between compositions and individual objects
- You need to implement a tree-like object structure

## C# Implementation

See the [Program.cs](./Program.cs) file for a graphics tree demonstrating uniform treatment of leaf and composite nodes.

## Pros

- Can work with complex tree structures more conveniently
- Open/Closed Principle - introduce new element types without breaking existing code
- Clients can treat all objects uniformly

## Cons

- Might be difficult to provide a common interface for classes with very different functionality
- Can make design overly general
