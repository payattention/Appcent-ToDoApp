﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.UserCommandsResult
{
    public class LoginCommandResult : ResponseBase
    {
        public bool isLoginValidate { get; set; }

        public string Token { get; set; }
    }
}
