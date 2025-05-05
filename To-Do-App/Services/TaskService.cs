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

    public async Task<TaskItem> GetById(string id) =>
        await _tasks.Find(task => task.Id == id).FirstOrDefaultAsync();

    public async Task Add(TaskItem task) =>
        await _tasks.InsertOneAsync(task);

    public async Task Update(string id, TaskItem updateTask)=>
        await _tasks.ReplaceOneAsync(task => task.Id == id, updateTask);

    public async Task Delete(string id)=>
        await _tasks.DeleteOneAsync(task => task.Id ==id);
    
    // public async Task<List<TaskItem>> GetByUserId(string userId)=>
    //     await _tasks.Find(task=> task.UserId ==userId).ToListAsync();
}

}