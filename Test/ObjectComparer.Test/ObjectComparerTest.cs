namespace ObjectComparer.Test;
using System;
using System.Collections.Generic;
using Xunit;

public class ObjectComparerTests
{
    [Fact]
    public void TestSimilarObjectsWithValueTypes_ShouldReturnTrue()
    {
        var a = new Student { Id = 1, Name = "Test", Marks = new List<int> { 1, 2, 3 } };
        var b = new Student { Id = 1, Name = "Test", Marks = new List<int> { 3, 2, 1 } };

        bool result = ObjectComparer.AreSimilar(a, b);
        Assert.True(result);
    }

    [Fact]
    public void TestDifferentObjectsWithValueTypes_ShouldReturnFalse()
    {
        var a = new Student { Id = 1, Name = "Test", Marks = new List<int> { 1, 2, 3 } };
        var b = new Student { Id = 2, Name = "Test", Marks = new List<int> { 3, 2, 1 } };

        bool result = ObjectComparer.AreSimilar(a, b);
        Assert.False(result);
    }

    [Fact]
    public void TestSimilarNestedObjects_ShouldReturnTrue()
    {
        var e = new NestedTestClass
        {
            InnerObject = new Student { Id = 1, Name = "Nested", Marks = new List<int> { 5, 6, 7 } }
        };
        var f = new NestedTestClass
        {
            InnerObject = new Student { Id = 1, Name = "Nested", Marks = new List<int> { 7, 6, 5 } }
        };

        bool result = ObjectComparer.AreSimilar(e, f);
        Assert.True(result);
    }

    [Fact]
    public void TestDifferentNestedObjects_ShouldReturnFalse()
    {
        var e = new NestedTestClass
        {
            InnerObject = new Student { Id = 1, Name = "Nested", Marks = new List<int> { 5, 6, 7 } }
        };
        var f = new NestedTestClass
        {
            InnerObject = new Student { Id = 2, Name = "Nested", Marks = new List<int> { 7, 6, 5 } }
        };

        bool result = ObjectComparer.AreSimilar(e, f);
        Assert.False(result);
    }

    [Fact]
    public void TestNullObjects_ShouldReturnTrue()
    {
        Student a = null;
        Student b = null;

        bool result = ObjectComparer.AreSimilar(a, b);
        Assert.True(result);
    }

    [Fact]
    public void TestOneNullObject_ShouldReturnFalse()
    {
        Student a = new Student { Id = 1, Name = "Test", Marks = new List<int> { 1, 2, 3 } };
        Student b = null;

        bool result = ObjectComparer.AreSimilar(a, b);
        Assert.False(result);
    }

    [Fact]
    public void TestDifferentTypes_ShouldReturnFalse()
    {
        var a = new Student { Id = 1, Name = "Test", Marks = new List<int> { 1, 2, 3 } };
        var b = new { Id = 1, Name = "Test", Marks = new List<int> { 3, 2, 1 } }; // Anonymous type

        bool result = ObjectComparer.AreSimilar(a, b);
        Assert.False(result);
    }
}


public class NestedTestClass
{
    public Student InnerObject { get; set; }
}


