namespace WannabeRedditShared;

public static class Extensions
{
    public static bool ContainsIgnoreCase(this string a, string b)
    {
        bool ret = a.Contains(b, StringComparison.OrdinalIgnoreCase);
        return ret;
    }
}
