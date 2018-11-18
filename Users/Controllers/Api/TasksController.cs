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
            return _context.tasks.OrderBy(x=>x.Name).ToList();
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

        // POST: api/Tasks/Create
        public void Create(Task task)
        {
            _context.tasks.Add(task);
            _context.SaveChanges();
        }

        // PUT: api/Tasks/Update/{id}
        [HttpPut]
        public void Update(Task task)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.tasks.ToList().Where(x => x.Id == task.Id).First().Name = task.Name;
            _context.tasks.ToList().Where(x => x.Id == task.Id).First().Completed = task.Completed;
            _context.SaveChanges();
        }

        // DELETE: api/Tasks/Delete/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            _context.tasks.Remove(_context.tasks.Where(x => x.Id == id).First());
            _context.SaveChanges();
        }
    }
}
