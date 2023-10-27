using System.Text.Json;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }

    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return dataContainer!.Posts;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
        }
        else
        {
            dataContainer = new()
            {
                Users = new List<User>(),
                Posts = new List<Post>()
            };

            string content = JsonSerializer.Serialize(dataContainer);
            File.WriteAllText(filePath, content);
        }
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}
