using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WannabeRedditShared.Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string PassWord { get; set; }

    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }

    private User() {}

    public User(string name, string passWord)
    {
        Name = name;
        PassWord = passWord;
    }
}
