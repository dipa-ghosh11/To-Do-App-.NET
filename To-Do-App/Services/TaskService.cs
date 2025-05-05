using System;
using MongoDB.Driver;
using To_Do_App.Models;

namespace To_Do_App.Services{

public class TaskService
{
    private readonly IMongoCollection<TaskItem> _tasks;

    public TaskService(ToDoDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _tasks = database.GetCollection<TaskItem>(settings.TaskCollectionName);
        }

    public async Task<List<TaskItem>> GetAll() =>
        await _tasks.Find(task => true).ToListAsync();
}

}