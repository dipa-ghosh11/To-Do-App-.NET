using System;
using MongoDB.Driver;
using To_Do_App.Models;
using BCrypt.Net;

namespace To_Do_App.Services;

public class UserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(ToDoDatabaseSettings settings){
        
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>(settings.UserCollectionName);
    }

    public async Task<List<User>> GetAll() => await _users.Find(user => true).ToListAsync();

    public async Task<User> GetById(String id) => await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

    public async Task Add(User user){
        user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(10));

        await _users.InsertOneAsync(user);
    }
}
