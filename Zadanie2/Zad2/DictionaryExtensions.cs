namespace Zad2;

public static class DictionaryExtensions
{
    // TODO: Merge

    public static TValue? Merge<TKey, TValue>(this IDictionary<TKey, TValue?> dictionary, TKey key, TValue? value,
        Func<TKey, TValue?, TValue?> mergeFunc)
    {
        if (!dictionary.ContainsKey(key))
        {
            if (value != null)
            {
                dictionary.Add(key, value);
                return value;
            }

            return default;
        }
        else if (dictionary[key] == null)
        {
            if (value != null)
            {
                dictionary.Add(key, value);
                return value;
            }
            
            dictionary.Remove(key);
            return default;
        }
        else if (value == null)
        {
            dictionary.Remove(key);
            return default;
        }
        
        dictionary[key] = mergeFunc(key, value);
        return dictionary[key];
    }
    
    public static IDictionary<DateTime, string> MergeLogs(IDictionary<DateTime, string> source, IDictionary<DateTime, string> appendix)
    {
        foreach (var item in appendix)
        {
            source.Merge(item.Key, item.Value,
            (key, newValue) => string.Concat(source[key], newValue));
        }
        return source;
    }
}