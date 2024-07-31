# Object Comparer

A C# library for performing deep comparisons between two instances of the same object type, ensuring that value types are directly compared and reference types are recursively compared for similarity. Collections are compared without considering order.

## Description

This library provides a flexible and recursive approach to compare objects deeply, considering value types, reference types, and collections. It supports any arbitrary type and ensures that collections are compared without maintaining order.

## Features

- Deep comparison of objects
- Supports value types, reference types, and collections
- Order-independent comparison for collections
- Handles nested objects and repeated references

## Installation

To use this library, you can include the source files in your project. Copy the `ObjectComparer` class to your project directory.

## Usage

Here is an example of how to use the `ObjectComparer` class:

```csharp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var a = new Student { Id = 1, Name = "Test", Marks = new List<int> { 1, 2, 3 } };
        var b = new Student { Id = 1, Name = "Test", Marks = new List<int> { 3, 2, 1 } };

        bool result = ObjectComparer.AreSimilar(a, b);
        Console.WriteLine(result); // True
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Marks { get; set; }
}
