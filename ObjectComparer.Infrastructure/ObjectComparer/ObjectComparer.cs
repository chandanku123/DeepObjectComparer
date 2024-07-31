using System;
using System.Collections;
using System.Reflection;
using ObjectComparer.Domain.Interface;

namespace ObjectComparer.Infrastructure.ObjectComparer
{
    /// <summary>
    /// This class handles the deep comparison of two objects,
    /// checking for similarity of value types and reference types.
    /// </summary>
    public class DeepObjectComparer : IObjectComparer
    {
        private readonly ICollectionComparer _collectionComparer;

        public DeepObjectComparer(ICollectionComparer collectionComparer)
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


            //Value Type and String Comparison
            if (obj1.GetType().IsValueType || obj1 is string)
                return obj1.Equals(obj2);

            //delegate the comparison to _collectionComparer.which is responsible for comparing collections.
            if (obj1 is IEnumerable && obj2 is IEnumerable)
                return _collectionComparer.AreSimilarCollections((IEnumerable)obj1, (IEnumerable)obj2);


            // If the objects are reference types, compare their properties
            var properties = obj1.GetType().GetProperties();
            //BindingFlags.Instance | BindingFlags.Public : is used to retrieve all the public instance properties if student class contain static field but I have require public properties on that time use


            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length > 0) // Check if the property is an indexer property
                {
                    //it means the property is an indexer, we skip this
                    continue; 
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