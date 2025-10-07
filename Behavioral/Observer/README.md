# Observer Pattern

## Intent
Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## Problem
You need to notify multiple objects about state changes in another object without creating tight coupling between them. Hard-coding these relationships makes the code inflexible.

## Solution
The Observer pattern establishes a subscription mechanism where objects (observers) can subscribe to events from another object (subject) and get notified when the subject's state changes.

## Structure
```
Subject
├── Attach(Observer)
├── Detach(Observer)
├── Notify()
└── observers list

Observer (interface)
└── Update()

ConcreteSubject
└── GetState(), SetState()

ConcreteObserver
└── Update()
```

## When to Use
- When changes to one object require changing others, and you don't know how many objects need to change
- When an object should notify other objects without making assumptions about who these objects are
- When you need a publish-subscribe model

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Open/Closed Principle - can introduce new subscriber classes without changing publisher
- Establishes relationships between objects at runtime
- Loose coupling between subjects and observers

## Cons
- Subscribers are notified in random order
- Can cause memory leaks if observers aren't properly unsubscribed
- May cause unexpected cascading updates
