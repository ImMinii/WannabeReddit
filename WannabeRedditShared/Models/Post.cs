﻿namespace WannabeRedditShared.Domain.Models;

public class Post
{
    public User Author { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }

    public Post(string title, string body, User author)
    {
        Title = title;
        Body = body;
        Author = author;
    }
}
