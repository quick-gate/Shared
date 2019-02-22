using System.Collections.Generic;
using System.Linq;

namespace QGate.Core.Collections
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Gets whether is collection null or contains no elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }

            //Due to performance reason
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }

            return enumerable.Any();
        }
    }
}
