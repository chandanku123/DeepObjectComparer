using System;
using ObjectComparer.Domain.Interface;
using ObjectComparer.Infrastructure.Comparer;
using ObjectComparer.Infrastructure.UnorderdComparer;

namespace ObjectComparer.Infrastructure.Factory
{
	public class ComparerFactory
	{
        public IObjectComparer CreateObjectComparer()
        {
            CollectionCompare collectionComparer = null;
            ObjectComparer objectComparer = new ObjectComparer(collectionComparer);
            collectionComparer = new CollectionCompare(objectComparer);
            objectComparer = new ObjectComparer(collectionComparer);
            return objectComparer;
        }
    }
}

