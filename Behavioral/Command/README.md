# Command Pattern

## Intent
Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

## Problem
You need to issue requests to objects without knowing anything about the operation being requested or the receiver of the request. You may also need to support undo/redo functionality.

## Solution
The Command pattern turns a request into a stand-alone object that contains all information about the request. This transformation lets you pass requests as method arguments, delay or queue a request's execution, and support undoable operations.

## Structure
```
Command (interface)
└── Execute()

ConcreteCommand
├── receiver (reference to Receiver)
└── Execute() (calls receiver.Action())

Invoker
├── command (reference to Command)
└── ExecuteCommand()

Receiver
└── Action()
```

## When to Use
- To parameterize objects with operations
- To queue operations, schedule their execution, or execute them remotely
- To implement reversible operations (undo/redo)
- To log changes so they can be reapplied in case of a system crash
- To structure a system around high-level operations built on primitive operations

## C# Implementation
See the [Program.cs](./Program.cs) file for an implementation example.

## Pros
- Single Responsibility Principle - decouple classes that invoke operations from those that perform them
- Open/Closed Principle - introduce new commands without breaking existing code
- Can implement undo/redo
- Can implement deferred execution of operations
- Can assemble a set of simple commands into a complex one

## Cons
- Code may become more complicated with many command classes
- Increases the overall complexity of the code
