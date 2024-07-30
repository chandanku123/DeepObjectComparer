using System;
using System.Collections;
using System.Linq;
using ObjectComparer.Domain.Interface;

namespace ObjectComparer.Infrastructure.UnorderdComparer
{
    public class UnorderedCollectionComparer : IValueComparer
    {
        private readonly IObjectComparer _objectComparer;
        

        public UnorderedCollectionComparer(IObjectComparer objectComparer)
        {
            _objectComparer = objectComparer;
        }

        public bool AreSimilarCollections(IEnumerable obj1, IEnumerable obj2)
        {
            // Convert the collections to lists
            var list1 = ((ICollection)obj1).Cast<object>().ToList();
            var list2 = ((ICollection)obj2).Cast<object>().ToList();

            // If the lists have different counts, they are not similar
            if (list1.Count != list2.Count) return false;

            // Compare the elements of the lists
            foreach (var element1 in list1)
            {
                var similarElement2 = list2.FirstOrDefault(element2 => _objectComparer.AreSimilar(element1, element2));
                if (similarElement2 == null) return false;
                list2.Remove(similarElement2);
            }

            // If all elements are similar, the collections are similar
            return true;
        }
    }
}

