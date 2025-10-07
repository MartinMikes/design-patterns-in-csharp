# Flyweight Pattern

## Intent
Use sharing to support large numbers of fine-grained objects efficiently.

## Problem
You need to create a large number of similar objects, which causes memory issues due to the overhead of object creation.

## Solution
The Flyweight pattern minimizes memory usage by sharing common parts of state between multiple objects instead of keeping all data in each object.

## When to Use
- An application uses a large number of objects
- Storage costs are high because of the quantity of objects
- Most object state can be made extrinsic
- Many groups of objects may be replaced by relatively few shared objects
- The application doesn't depend on object identity

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Can save lots of RAM when dealing with many similar objects
- Centralizes state management for similar objects

## Cons
- Code becomes more complicated
- Trading RAM for CPU cycles when some context data needs to be recalculated
- Extrinsic state must be computed or looked up
