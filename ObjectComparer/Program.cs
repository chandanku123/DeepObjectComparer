using ObjectComparer.Domain.Interface;
using ObjectComparer.Domain.Model;
using ObjectComparer.Infrastructure.Comparer;
using ObjectComparer.Infrastructure.Factory;

public class Program
{
    public static void Main(string[] args)
    {
        // var comparer = new SimilarObjectComparer();
        var comparerFactory = new ComparerFactory();
        var comparer = comparerFactory.CreateObjectComparer();


        var a = new Student { Id = 1, Name = "John", Marks = new List<int> { 90, 80, 70 } };
        var b = new Student { Id = 1, Name = "John", Marks = new List<int> { 90, 80, 70 } };
        var c = new Student { Id = 2, Name = "John", Marks = new List<int> { 90, 80, 70 } };
        var d = new Student { Id = 1, Name = "John", Marks = new List<int> { 70, 80, 90 } };

        Console.WriteLine(comparer.AreSimilar(a, b)); // True
        Console.WriteLine(comparer.AreSimilar(a, c)); // False
        Console.WriteLine(comparer.AreSimilar(a, d)); // True
        Console.ReadLine();
    }
}