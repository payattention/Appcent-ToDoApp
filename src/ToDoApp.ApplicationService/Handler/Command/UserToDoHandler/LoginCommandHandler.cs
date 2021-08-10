using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.UserCommands;
using ToDoApp.ApiContract.Response.Command.UserCommandsResult;
using ToDoApp.ApplicationService.Communicator.UserToDo;
using ToDoApp.ApplicationService.Communicator.UserToDo.Model;

namespace ToDoApp.ApplicationService.Handler.Command.UserToDoHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseBase<LoginCommandResult>>
    {
        private readonly IUserToDoCommunicator _userToDoCommunicator;


        public LoginCommandHandler(IUserToDoCommunicator userToDoCommunicator)
        {
            _userToDoCommunicator = userToDoCommunicator;

        }
        public async Task<ResponseBase<LoginCommandResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var Login = await _userToDoCommunicator.Login(new LoginToDoRequestModel
            {
                UserName = request.UserName,
                Password = request.Password
            });

            var response = new LoginCommandResult() { isLoginValidate = Login.Success ,   Token = Login.Data.Token };

            return new ResponseBase<LoginCommandResult>
            {
                Data = response,
                Success = Login.Success
            };

        }

    }
}
