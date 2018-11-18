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
        public void Update(int id, User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.users.ToList().RemoveAt(id);
            _context.users.ToList()[id] = user;
        }

        // DELETE: api/Users/delete/5
        public void Delete(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.users.ToList().RemoveAt(id);
        }
    }
}
