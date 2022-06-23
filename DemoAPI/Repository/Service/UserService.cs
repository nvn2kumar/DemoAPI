using DemoAPI.Contract.Request;
using DemoAPI.Models;
using DemoAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repository.Service
{
    public class UserService : IUsers
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Users SignIn(SignInModel model)
        {
            var user = dbContext.Users.SingleOrDefault(e => e.Email == model.Email && e.Pasword == model.Pasword);
            if (user!=null)
            {
                return user;

            }
            else
            {
                return null;
            }
        }

        public Users SignUp(SignUpModel model)
        {
            var user = new Users()
            {

                Name = model.Name,
                Email = model.Email,
                Pasword = model.Pasword,
                Gender=model.Gender


            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}
