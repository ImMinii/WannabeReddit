﻿using System.Net.Http.Json;
using System.Text.Json;
using WannabeReddit.HttpClients.ClientInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeReddit.HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
        this.jsonOptions = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<UserCreateResult> Create(UserCreate dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/user", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        UserCreateResult result = JsonSerializer.Deserialize<UserCreateResult>(content, jsonOptions)!;
        return result;
    }
}
