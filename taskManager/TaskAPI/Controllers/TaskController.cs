 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        taskManager_BusinessLogic.BusinessLogic_Process taskBusinessProcess = new taskManager_BusinessLogic.BusinessLogic_Process();
        [HttpGet("GetAllTasks")]
        public IEnumerable<TaskManager_Common.Tasks> GetTasks()
        {
            var tasks = taskBusinessProcess.GetAllTasks();
            return tasks;
        }
        [HttpPost("AddTask")]
        public bool AddTask(string task)
        {
            return taskBusinessProcess.SaveTask(task);
        }
        [HttpPatch("Update Task")]
        public bool UpdateTask(int index)
        {
            return taskBusinessProcess.UpdateTask(index);
        }
        [HttpDelete("Remove Task")]
        public bool DeleteTask(int index)
        {
            return taskBusinessProcess.RemoveTask(index);
        }
    }
}
