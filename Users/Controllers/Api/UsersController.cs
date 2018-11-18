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
    public class UsersController : ApiController
    {
        UsersContext _context = new UsersContext();
        // GET: api/Users/get
        public List<User> Get()
        {
            return _context.users.ToList();
        }

        // GET: api/Users/Get/5
        public User Get(int id)
        {
            return _context.users.ToList().First(usr => usr.Id == id);
        }

        // POST: api/Users/create
        [HttpPost]
        public User Create(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // PUT: api/Users/Update/5
        [HttpPut]
        public void Update(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.users.ToList().Where(x => x.Id == user.Id).First().First_Name = user.First_Name;
            _context.users.ToList().Where(x => x.Id == user.Id).First().Last_Name = user.Last_Name;
            _context.users.ToList().Where(x => x.Id == user.Id).First().Age = user.Age;
            _context.SaveChanges();
        }

        // DELETE: api/Users/delete/5
        public void Delete(int id)
        {
            _context.users.Remove(_context.users.Where(x => x.Id == id).First());
            _context.tasks.RemoveRange(_context.tasks.Where(x => x.User_id == id));
            _context.SaveChanges();
        }
    }
}
