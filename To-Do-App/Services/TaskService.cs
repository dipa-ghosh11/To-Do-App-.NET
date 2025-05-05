using System;
using MongoDB.Driver;
using To_Do_App.Models;

namespace To_Do_App.Services{

public class TaskService
{
    private readonly IMongoCollection<TaskItem> _tasks;
}

}