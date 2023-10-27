namespace WannabeRedditShared;

public static class Extensions
{
    public static bool ContainsIgnoreCase(this string a, string b)
    {
        bool ret = a.Contains(b, StringComparison.OrdinalIgnoreCase);
        return ret;
    }

    public static bool EqualsIgnoreCase(this string a, string b)
    {
        bool ret = a.Equals(a, StringComparison.OrdinalIgnoreCase);
        return ret;
    }

    public static string Join(this IEnumerable<string> s, string separator)
    {
        string ret = string.Join(separator, s);
        return ret;
    }
}
