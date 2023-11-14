namespace WannabeRedditShared.Domain.DTOs;

public class PostSearchParam {
    public string? authorName { get; }
    public string? titleContains { get; }
    public string? bodyContains { get; }

    public PostSearchParam(string? authorName, string? titleContains, string? bodyContains) {
        this.authorName = authorName;
        this.titleContains = titleContains;
        this.bodyContains = bodyContains;
    }
}
