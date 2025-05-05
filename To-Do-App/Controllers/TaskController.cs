using System;
using Microsoft.AspNetCore.Mvc;
using To_Do_App.Models;
using To_Do_App.Services;


namespace To_Do_App.Controllers{


    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService){
            _taskService = taskService;
        }

        
    }

}