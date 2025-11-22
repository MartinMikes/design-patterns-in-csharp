# Template Method Pattern

## Intent

Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

## Problem

You have multiple classes with similar algorithms that differ only in some steps. Code duplication occurs when you implement the algorithm in each class.

## Solution

The Template Method pattern breaks down an algorithm into steps and allows subclasses to override specific steps while keeping the overall structure intact.

## When to Use

- You want to let clients extend only particular steps of an algorithm, but not the whole algorithm or its structure
- You have several classes with almost identical algorithms with minor differences
- You want to control the extension points for subclasses

## C# Implementation

See the [Program.cs](./Program.cs) file for data exporters (CSV and JSON) sharing a common workflow template.

## Pros

- Can let clients override only certain parts of a large algorithm
- Can pull duplicate code into a superclass
- Promotes code reuse

## Cons

- Clients may be limited by the provided skeleton
- Might violate Liskov Substitution Principle by suppressing default step via subclass
- Template methods tend to be harder to maintain as they grow
