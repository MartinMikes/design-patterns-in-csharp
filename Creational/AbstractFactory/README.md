# Abstract Factory Pattern

## Intent

Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

## Problem

You need to create families of related objects that must be used together, and you want to ensure that these objects are compatible.

## Solution

The Abstract Factory pattern provides an interface for creating families of related objects without specifying their concrete classes.

## When to Use

- A system should be independent of how its products are created
- A system should be configured with one of multiple families of products
- A family of related product objects is designed to be used together
- You want to provide a class library of products and reveal only their interfaces

## C# Implementation

See the [Program.cs](./Program.cs) file for theme factories creating consistent UI widget families.

## Pros

- Isolates concrete classes
- Makes exchanging product families easy
- Promotes consistency among products

## Cons

- Supporting new kinds of products is difficult
- Increases complexity with many interfaces and classes
