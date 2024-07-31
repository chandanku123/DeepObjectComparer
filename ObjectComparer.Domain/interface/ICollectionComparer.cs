using System;
using System.Collections;

namespace ObjectComparer.Domain.Interface
{
    /// <summary>
    /// This interface defines a contract for comparing two collections to determine if they are similar.
    /// </summary>
    public interface ICollectionComparer
    {
        bool AreSimilarCollections(IEnumerable collection1, IEnumerable collection2);
    }
}