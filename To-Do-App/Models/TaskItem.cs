using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace To_Do_App.Models;

public class TaskItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }



    [BsonElement("title")]
    public required string Title { get; set; }



    [BsonElement("description")]
    public string? Description { get; set; }


    [BsonElement("status")]
    public required string Status { get; set; }


    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }


    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    [BsonElement("user")]
    public required string User { get; set; }
    
}
