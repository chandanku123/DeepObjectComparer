using System;
using ObjectComparer.Domain.Interface;
using ObjectComparer.Infrastructure.ObjectComparer;
using ObjectComparer.Infrastructure.UnorderdComparer;

namespace ObjectComparer.Infrastructure.Factory
{
	public class ComparerFactory
	{
        public IObjectComparer CreateObjectComparer()
        {
            CollectionComparer collectionComparer = null;
            DeepObjectComparer objectComparer = new DeepObjectComparer(collectionComparer);
            collectionComparer = new CollectionComparer(objectComparer);
            objectComparer = new DeepObjectComparer(collectionComparer);
            return objectComparer;
        }
    }
}

