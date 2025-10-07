# Chain of Responsibility Pattern

## Intent
Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.

## Problem
You need to process a request through multiple handlers, but you don't want to hard-code which handler processes which request.

## Solution
The Chain of Responsibility pattern passes requests along a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain.

## When to Use
- More than one object may handle a request, and the handler isn't known in advance
- You want to issue a request to one of several objects without specifying the receiver explicitly
- The set of objects that can handle a request should be specified dynamically

## C# Implementation
Coming soon - see [Program.cs](./Program.cs) when available.

## Pros
- Can control the order of request handling
- Single Responsibility Principle - decouple classes that invoke and perform operations
- Open/Closed Principle - introduce new handlers without breaking existing code

## Cons
- Some requests may end up unhandled
- Can be hard to observe runtime characteristics of the chain
