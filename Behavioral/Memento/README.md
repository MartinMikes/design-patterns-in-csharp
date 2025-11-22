# Memento Pattern

## Intent

Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

## Problem

You need to save and restore the state of an object without exposing its implementation details (e.g., for undo/redo functionality).

## Solution

The Memento pattern delegates creating state snapshots to the actual owner of the state, the originator object, ensuring encapsulation is not violated.

## When to Use

- You need to save and restore object state (undo/redo)
- Direct interface to obtain state would expose implementation details and violate encapsulation
- You need to implement checkpoints or snapshots

## C# Implementation

See the [Program.cs](./Program.cs) file for a document editor with undo functionality using snapshots.

## Pros

- Can produce snapshots without violating encapsulation
- Simplifies originator code by delegating state storage to caretaker
- Supports undo/redo operations

## Cons

- App might consume lots of RAM if clients create mementos too often
- Caretakers should track originator's lifecycle to destroy obsolete mementos
- Dynamic programming languages can't guarantee memento state stays untouched
