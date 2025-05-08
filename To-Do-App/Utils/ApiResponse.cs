using System;
using System.Text.Json.Serialization;
using To_Do_App.Models;

namespace To_Do_App.Utils;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public T? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    public string? Token { get; set;  }
}
