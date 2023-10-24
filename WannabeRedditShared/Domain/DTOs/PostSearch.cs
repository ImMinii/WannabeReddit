namespace WannabeRedditShared.Domain.DTOs;

public class PostSearch
{
public string? authorName { get; }
public string? titleContains { get; }
public string? bodyContains { get; }

public PostSearch(string? authorName, string? titleContains, string? bodyContains)
{
    this.authorName = authorName;
    this.titleContains = titleContains;
    this.bodyContains = bodyContains;
}
}
