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

        // Get : api/task
        [HttpGet]

        public async Task<ActionResult<List<TaskItem>>> GetAll(){
            var tasks = await _taskService.GetAll();
            return Ok(tasks);
        }

        // GET: api/task/{id}
        [HttpGet("{id:length(24)}",Name ="GetTask")]
        public async Task<ActionResult<TaskItem>> GetById(string id){
            var task= await _taskService.GetById(id);

            if(task==null){
                return NotFound();
            }

            return Ok(task);
        }
    }

}