using System.Collections.Generic;

namespace DataVirtualization
{
    /// <summary>
    /// Represents a provider of collection details.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public interface IItemsProvider<T>
    {
        int FetchCount();
        
        IList<T> FetchRange(int skip, int take, out int totalCount);
    }
}
