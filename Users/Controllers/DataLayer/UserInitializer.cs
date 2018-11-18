using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Users.Models;

namespace Users.Controllers.DataLayer
{
    public class UserInitializer : IDatabaseInitializer<UsersContext>
    {
        public void InitializeDatabase(UsersContext context)
        {
            if(context.users.Count() == 0)
            {
                var users = new List<User>
                {
                    new User{First_Name = "Edvinas", Last_Name = "Kilciauskas", Age = 21}
                };
                users.ForEach(x => context.users.Add(x));
                context.SaveChanges();
            }
            
        }
    }
}