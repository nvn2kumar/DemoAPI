using DemoAPI.Contract.Request;
using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repository.Contract
{
    public interface IUsers
    {
        //Task<<Result>Response> SignIn(SignInModel signInModel);
        Users SignIn(SignInModel model);
        Users SignUp(SignUpModel model);
    }
}
