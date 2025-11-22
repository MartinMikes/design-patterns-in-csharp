# Proxy Pattern

## Intent

Provide a surrogate or placeholder for another object to control access to it.

## Problem

You need to control access to an object, add functionality before/after accessing it, or delay its creation until actually needed.

## Solution

The Proxy pattern creates a proxy object that has the same interface as the real object, allowing it to control access and add additional functionality.

## When to Use

- Lazy initialization (virtual proxy) - defer object creation until needed
- Access control (protection proxy) - control access based on permissions
- Local execution of remote service (remote proxy)
- Logging requests (logging proxy)
- Caching request results (caching proxy)
- Smart reference - additional actions when an object is accessed

## C# Implementation

See the [Program.cs](./Program.cs) file for an image proxy demonstrating lazy loading and caching.

## Pros

- Can control the service object without clients knowing about it
- Can manage lifecycle of service object
- Proxy works even if service isn't ready or available
- Open/Closed Principle - introduce new proxies without changing service or clients

## Cons

- Code may become more complicated with many new classes
- Response from service might get delayed
