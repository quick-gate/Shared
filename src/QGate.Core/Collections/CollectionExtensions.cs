using QGate.Core.Exceptions;
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

        /// <summary>
        /// Safely set value to dictionary. If value does not exists it will be added. In case of exists will be updated or ignored according to updateIfExists flag
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="updateIfExists"></param>
        /// <returns></returns>
        public static bool TrySetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value, bool updateIfExists = false)
        {
            Throw.IfNull(dictionary, nameof(dictionary));

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return true;
            }

            if (!updateIfExists)
            {
                return false;
            }

            dictionary[key] = value;

            return true;
        }
    }
}
