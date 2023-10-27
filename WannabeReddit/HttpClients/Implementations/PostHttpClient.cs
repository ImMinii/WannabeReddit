using System.Net;
using System.Text.Json;
using System.Web;
using WannabeReddit.HttpClients.ClientInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;
using WannabeRedditShared;

namespace WannabeReddit.HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
        this.jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<IEnumerable<Post>> GetPostsAsync(PostSearch postSearch)
    {
        // NOTE(rune): REST convention er dumt??? Hvorfor ikke bare sende PostSearch
        // som json ligesom alt andent? Er der en C# api til query parametre, eller
        // burdre vi lave vores egen wrapper?

        var queryArgs = new List<string>();
        if (postSearch.authorName != null)
        {
            queryArgs.Add("authorName=" + WebUtility.UrlEncode(postSearch.authorName));
        }

        if (postSearch.titleContains != null)
        {
            queryArgs.Add("titleContains=" + WebUtility.UrlEncode(postSearch.titleContains));
        }

        if (postSearch.bodyContains != null)
        {
            queryArgs.Add("bodyContains=" + WebUtility.UrlEncode(postSearch.bodyContains));
        }

        var queryString = "";
        if (queryArgs.Count > 0)
        {
            queryString = "?" + queryArgs.Join("&");
        }

        var posts = await client.GetFromJsonAsync<List<Post>>("/post" + queryString, jsonOptions);
        if (posts == null)
        {
            throw new Exception("GetFromJsonAsync() returned null. MSDN documentation does not say why.");
        }

        return posts;
    }
}
