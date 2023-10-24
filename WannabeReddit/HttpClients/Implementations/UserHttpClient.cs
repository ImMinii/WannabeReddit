using System.Net.Http.Json;
using System.Text.Json;
using WannabeReddit.HttpClients.ClientInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeReddit.HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<User> Create(UserCreate dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException();
        }
    }
}