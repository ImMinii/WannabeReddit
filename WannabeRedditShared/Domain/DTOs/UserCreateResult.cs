using System.Text.Json.Serialization;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class UserCreateResult {

    public User? User { get; set; }
    public string ValidationError { get; set; }

    [JsonIgnore]
    public bool HasValidationError => ValidationError != "";

    public UserCreateResult(User? user, string validationError) {
        User = user;
        ValidationError = validationError;
    }
}
