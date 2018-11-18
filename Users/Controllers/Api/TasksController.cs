using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Users.Controllers.DataLayer;
using Users.Models;

namespace Users.Controllers.Api
{
    public class TasksController : ApiController
    {

        UsersContext _context = new UsersContext();
        // GET: api/Tasks/get
        public List<Task> Get()
        {
            return _context.tasks.ToList();
        }

        // GET: api/Tasks/GetUserTasks/{id}
        public List<Task> GetUserTasks(int id)
        {
            return _context.tasks.Where(x => x.User_id == id).ToList();
        }

        // GET: api/Tasks/GetUserTasksCount/{id}
        public int GetUserTasksCount(int id)
        {
            return GetUserTasks(id).Count();
        }

        // GET: api/Tasks/GetUserCompletedTasks/{id}
        public int GetUserCompletedTasks(int id)
        {
            return GetUserTasks(id).Where(x => x.Completed == true).Count();
        }

        // POST: api/Tasks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tasks/5
        public void Delete(int id)
        {
        }
    }
}
