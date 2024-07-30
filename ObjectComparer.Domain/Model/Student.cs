using System;
using System.Collections.Generic;

namespace ObjectComparer.Domain.Model
{
    /// <summary>
    /// Sample class to demonstrate property logic
    /// </summary>
	public class Student
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Marks { get; set; }
    }
}

