using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using WannabeReddit.HttpClients.ClientInterfaces;
using WannabeReddit.Services;
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

    public async Task<IEnumerable<Post>> GetPostsAsync(PostSearchParam postSearchParam)
    {
        // NOTE(rune): REST convention er dumt??? Hvorfor ikke bare sende PostSearch
        // som json ligesom alt andent? Er der en C# api til query parametre, eller
        // burdre vi lave vores egen wrapper?

        var queryArgs = new List<string>();
        if (postSearchParam.authorName != null)
        {
            queryArgs.Add("authorName=" + WebUtility.UrlEncode(postSearchParam.authorName));
        }

        if (postSearchParam.titleContains != null)
        {
            queryArgs.Add("titleContains=" + WebUtility.UrlEncode(postSearchParam.titleContains));
        }

        if (postSearchParam.bodyContains != null)
        {
            queryArgs.Add("bodyContains=" + WebUtility.UrlEncode(postSearchParam.bodyContains));
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

    public async Task<Post> GetPostAsync(int id)
    {
        var post = await client.GetFromJsonAsync<Post>("/post/" + id, jsonOptions);
        if (post == null)
        {
            throw new Exception("GetFromJsonAsync() returned null. MSDN documentation does not say why.");
        }
        return post;
    }

    public async Task CreateAsync(PostCreate dto)
    {
        JwtAuthService.ApplyJwt(client);

        HttpResponseMessage response = await client.PostAsJsonAsync("/post", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception("CreateAsync failed with status code " + response.StatusCode + ". Content: " + content);
        }
    }
}
