namespace Proiect___Catalog_Online.Utils
{
    /// <summary>
    /// Custom OrderedDictionary implementation
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class OrderedDictionary<TKey, TValue>:Dictionary<TKey, TValue>
    {
        private readonly List<TKey> keys = new List<TKey>();

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            keys.Add(key);
        }

        public new bool Remove(TKey key)
        {
            if (base.Remove(key))
            {
                keys.Remove(key);
                return true;
            }
            return false;
        }

        public new void Clear()
        {
            base.Clear();
            keys.Clear();
        }

        public new IEnumerable<TKey> Keys => keys;

        public new IEnumerable<TValue> Values => keys.Select(key => base[key]);
    }
}
