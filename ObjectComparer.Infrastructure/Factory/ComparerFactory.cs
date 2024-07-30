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
            UnorderedCollectionComparer collectionComparer = null;
            DeepObjectComparer objectComparer = new DeepObjectComparer(collectionComparer);
            collectionComparer = new UnorderedCollectionComparer(objectComparer);
            objectComparer = new DeepObjectComparer(collectionComparer);
            return objectComparer;
        }
    }
}

