namespace Proiect___Catalog_Online.Utils
{
    /// <summary>
    /// Custom OrderedDictionary implementation
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
    public class OrderedDictionary<TKey, TValue>:Dictionary<TKey, TValue>
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
    {
        private readonly List<TKey> keys = new List<TKey>();

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            keys.Add(key);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new bool Remove(TKey key)
        {
            if (base.Remove(key))
            {
                keys.Remove(key);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clear
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            keys.Clear();
        }

        /// <summary>
        /// Keys
        /// </summary>
        public new IEnumerable<TKey> Keys => keys;

        /// <summary>
        /// Values
        /// </summary>
        public new IEnumerable<TValue> Values => keys.Select(key => base[key]);
    }
}
