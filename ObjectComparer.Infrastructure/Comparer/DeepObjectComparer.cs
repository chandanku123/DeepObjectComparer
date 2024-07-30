using System;
using System.Collections;
using System.Reflection;
using ObjectComparer.Domain.Interface;

namespace ObjectComparer.Infrastructure.Comparer
{
    /// <summary>
    /// This class handles the deep comparison of two objects,
    /// checking for similarity of value types and reference types.
    /// </summary>
    public class DeepObjectComparer : IObjectComparer
    {
        private readonly IValueComparer _collectionComparer;

        public DeepObjectComparer(IValueComparer collectionComparer)
        {
            _collectionComparer = collectionComparer;
        }
        public bool AreSimilar(object obj1, object obj2)
        {
            //Checks if both objects are null
            if (obj1 == null && obj2 == null)
                return true;


            // If one object is null and the other is not
            if (obj1 == null || obj2 == null)
                return false;


            // If the objects are of different types
            if (obj1.GetType() != obj2.GetType()) return false;


            //If the objects are value types (like int, bool, etc.) or strings,
            //it directly compares their values.
            if (obj1.GetType().IsValueType || obj1 is string)
                return obj1.Equals(obj2);

            //If both objects are collections (implement IEnumerable),
            //delegate the comparison to _collectionComparer.which is responsible for comparing collections.
            if (obj1 is IEnumerable && obj2 is IEnumerable)
                return _collectionComparer.AreSimilarCollections((IEnumerable)obj1, (IEnumerable)obj2);


            // If the objects are reference types, compare their properties
            var properties = obj1.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length > 0) // Check if the property is an indexer property
                {
                    // Handle indexer properties separately
                    var indexerValues1 = property.GetValue(obj1, new object[] { 0 }); // Assuming the indexer has one parameter
                    var indexerValues2 = property.GetValue(obj2, new object[] { 0 }); // Assuming the indexer has one parameter
                    //  Recursively call AreSimilar to compare these values.
                    if (!AreSimilar(indexerValues1, indexerValues2))
                    // if any property values are not similar, return false.
                        return false;
                }
                else
                {
                    var value1 = property.GetValue(obj1);
                    var value2 = property.GetValue(obj2);

                    // If the property values are not similar, the objects are not similar
                    if (!AreSimilar(value1, value2)) return false;
                }
            }


            // If all property values are similar, the objects are similar
            return true;
        }
    }

}

