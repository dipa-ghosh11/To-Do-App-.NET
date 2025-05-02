using System;
using MongoDB.Driver;
using To_Do_App.Models;

namespace To_Do_App.Services;

public class UserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(ToDoDatabaseSettings settings){
        
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>(settings.UserCollectionName);
    }
}
