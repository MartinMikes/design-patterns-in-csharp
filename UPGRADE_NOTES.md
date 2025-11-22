# .NET 10 Upgrade Notes

## Overview

This repository has been upgraded from .NET 9 to **.NET 10** with **C# 14** language features. All code samples have been modernized to leverage the latest language improvements while maintaining the integrity of the Gang of Four design patterns.

## Upgrade Summary

### Framework Version
- **From:** .NET 9.0
- **To:** .NET 10.0 (LTS - Long Term Support)
- **C# Version:** C# 14

### Key Benefits

#### .NET 10 Runtime Improvements
- **Enhanced JIT Compilation:** Better method inlining and devirtualization
- **AVX10.2 Support:** Improved SIMD performance
- **Loop Optimization:** Enhanced loop inversion for better code generation
- **NativeAOT Enhancements:** Improved ahead-of-time compilation

#### C# 14 Language Features Applied

1. **`field` Keyword** - Cleaner property implementations
   - Eliminates need for explicit backing fields
   - Supports validation logic in setters
   - Applied in: Builder, Command, Observer, Strategy, and Decorator patterns

2. **Null-Conditional Assignment** - Safer null handling
   - Simplifies null-checking patterns
   - Applied in: Adapter pattern

3. **Enhanced Nullability** - Better null-safety
   - Applied nullable reference types throughout
   - Improved with `init` accessors for immutability

## Changes by Pattern

### Creational Patterns

#### Builder Pattern (`Creational/Builder/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
public string CPU { get; set; }

// After (.NET 10 with C# 14 field keyword)
public string CPU 
{ 
    get; 
    set => field = value ?? throw new ArgumentNullException(nameof(value)); 
}
```

**Benefits:**
- Eliminates explicit backing fields
- Adds null validation without extra code
- Cleaner, more maintainable property definitions

#### Singleton Pattern (`Creational/Singleton/Program.cs`)
**Changes:**
- Updated documentation comments to reflect .NET 10 compatibility
- No code changes needed - existing Lazy<T> pattern works perfectly with .NET 10

### Behavioral Patterns

#### Command Pattern (`Behavioral/Command/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
private string location;
public Light(string location) { this.location = location; }

// After (.NET 10 with C# 14 field keyword)
public string Location 
{ 
    get; 
    init => field = value ?? throw new ArgumentNullException(nameof(value)); 
}
public Light(string location) { Location = location; }
```

**Benefits:**
- Property-based design with `init` accessor for immutability
- Automatic null validation
- Eliminates private field clutter

#### Observer Pattern (`Behavioral/Observer/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
private string weather;
public string Weather
{
    get { return weather; }
    set { weather = value; Notify(); }
}

// After (.NET 10 with C# 14 field keyword)
public string Weather
{
    get;
    set
    {
        if (field == value) return;
        field = value;
        Notify();
    }
}
```

**Benefits:**
- No explicit backing field needed
- Built-in change detection with `field == value`
- Cleaner implementation of observable properties

#### Strategy Pattern (`Behavioral/Strategy/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
private string cardNumber;
public CreditCardPayment(string cardNumber) 
{ 
    this.cardNumber = cardNumber; 
}

// After (.NET 10 with C# 14 field keyword)
public string CardNumber 
{ 
    get; 
    init => field = value ?? throw new ArgumentNullException(nameof(value)); 
}
public CreditCardPayment(string cardNumber) 
{ 
    CardNumber = cardNumber; 
}
```

**Benefits:**
- Immutable properties with `init` accessor
- Null validation at initialization
- Applied to all strategy implementations (CreditCard, PayPal, Bitcoin)

### Structural Patterns

#### Adapter Pattern (`Structural/Adapter/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
private AdvancedMediaPlayer advancedPlayer;
private MediaAdapter mediaAdapter;

// After (.NET 10 with nullable annotations)
private AdvancedMediaPlayer AdvancedPlayer { get; init; }
private MediaAdapter? mediaAdapter;
```

**Benefits:**
- Property-based design with auto-initialization
- Explicit nullable annotations for better null safety
- Cleaner code structure

#### Decorator Pattern (`Structural/Decorator/Program.cs`)
**C# 14 Features Applied:**
```csharp
// Before (.NET 9)
protected ICoffee coffee;
public CoffeeDecorator(ICoffee coffee) 
{ 
    this.coffee = coffee; 
}

// After (.NET 10 with C# 14 field keyword)
protected ICoffee Coffee 
{ 
    get; 
    init => field = value ?? throw new ArgumentNullException(nameof(value)); 
}
public CoffeeDecorator(ICoffee coffee) 
{ 
    Coffee = coffee; 
}
```

**Benefits:**
- Protected property instead of field
- Null validation on initialization
- Immutable decorator composition

## Documentation Updates

### Main README (`README.md`)
Added section explaining:
- .NET 10 requirement
- C# 14 features used
- Link to official .NET 10 SDK download

### Singleton README (`Creational/Singleton/README.md`)
- Updated `dotnet new console` command from `-f net9.0` to `-f net10.0`

## Migration Guide

### For Running the Samples

1. **Install .NET 10 SDK**
   ```bash
   # Download from: https://dotnet.microsoft.com/download/dotnet/10.0
   ```

2. **Verify Installation**
   ```bash
   dotnet --version
   # Should show 10.0.x
   ```

3. **Run Any Sample**
   ```bash
   cd Creational/Singleton
   dotnet new console -n Singleton -f net10.0
   # Copy Program.cs
   dotnet run
   ```

### For Your Own Projects

To adopt these C# 14 patterns in your projects:

1. **Update Target Framework**
   ```xml
   <TargetFramework>net10.0</TargetFramework>
   ```

2. **Enable C# 14**
   ```xml
   <LangVersion>14.0</LangVersion>
   ```

3. **Enable Nullable Reference Types** (recommended)
   ```xml
   <Nullable>enable</Nullable>
   ```

## C# 14 Feature Reference

### `field` Keyword
**Official Documentation:** [What's new in C# 14 - field keyword](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#the-field-keyword)

**Use Cases:**
- Property validation without backing fields
- Change notification in setters
- Lazy initialization patterns

**Example:**
```csharp
public string Name
{
    get;
    set => field = value?.Trim() ?? throw new ArgumentNullException(nameof(value));
}
```

### Null-Conditional Assignment
**Official Documentation:** [What's new in C# 14 - Null-conditional assignment](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#null-conditional-assignment)

**Use Cases:**
- Safe property assignment on potentially null objects
- Simplifying null-check patterns

**Example:**
```csharp
// Before
if (customer is not null)
{
    customer.Order = GetCurrentOrder();
}

// After (C# 14)
customer?.Order = GetCurrentOrder();
```

### Enhanced Span Support
**Official Documentation:** [What's new in C# 14 - Implicit span conversions](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#implicit-span-conversions)

First-class support for `Span<T>` and `ReadOnlySpan<T>` with improved implicit conversions.

### Extension Members
**Official Documentation:** [What's new in C# 14 - Extension members](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#extension-members)

Support for:
- Extension properties
- Static extension methods
- User-defined operators as extensions

## References

### Microsoft Official Documentation
- [What's new in .NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/overview)
- [What's new in C# 14](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14)
- [What's new in the .NET 10 runtime](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/runtime)
- [What's new in the .NET 10 libraries](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/libraries)
- [Migrate from ASP.NET Core 9 to 10](https://learn.microsoft.com/en-us/aspnet/core/migration/90-to-100)

### Design Patterns
- Gang of Four Design Patterns (original reference)
- All pattern implementations maintain GoF pattern integrity

## Testing

All code samples have been verified to:
- ✅ Compile without errors on .NET 10
- ✅ Maintain original design pattern behavior
- ✅ Use C# 14 features appropriately
- ✅ Follow modern C# best practices
- ✅ Include proper null safety

## Future Enhancements

Potential areas for future updates:
- Add more extension member examples
- Leverage `partial` constructors/events where applicable
- Apply user-defined compound assignment operators
- Explore .NET 10 library improvements (JSON serialization, cryptography)

## Questions or Issues?

If you have questions about the upgrade or encounter any issues:
1. Check the [.NET 10 Breaking Changes](https://learn.microsoft.com/en-us/dotnet/core/compatibility/breaking-changes) documentation
2. Review [C# 14 Breaking Changes](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/breaking-changes/compiler%20breaking%20changes%20-%20dotnet%2010)
3. Consult the official Microsoft documentation links above

---

**Upgrade Date:** October 7, 2025  
**Source Documentation:** Official Microsoft Learn documentation for .NET 10 and C# 14  
**Compatibility:** .NET 10.0 SDK or later required
