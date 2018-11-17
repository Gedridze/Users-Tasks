using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Users.Models;

namespace Users.Controllers.DataLayer
{
    public class UsersContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Task> tasks { get; set; }

        public UsersContext() : base("UsersConnection")
        {
            Database.SetInitializer(new UserInitializer());
        }
    }
}