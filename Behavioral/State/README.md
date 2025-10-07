# State Pattern

## Intent
Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.

## Problem
You have an object that behaves differently depending on its state, and the number of states is large, with state-specific code changing frequently.

## Solution
The State pattern extracts state-specific behaviors into separate state classes and forces the original object to delegate work to an instance of these classes.

## When to Use
- Object behavior depends on its state, and it must change behavior at runtime based on that state
- Operations have large conditional statements that depend on object state
- State transitions are explicit and numerous

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Single Responsibility Principle - organize state-related code
- Open/Closed Principle - introduce new states without changing existing ones
- Simplifies context code by eliminating bulky state machine conditionals

## Cons
- Overkill if state machine has only a few states or rarely changes
- Increases the number of classes
