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
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseBase<RegisterCommandResult>>
    {
        private readonly IUserToDoCommunicator _userToDoCommunicator;


        public RegisterCommandHandler(IUserToDoCommunicator userToDoCommunicator)
        {
            _userToDoCommunicator = userToDoCommunicator;

        }
        public async Task<ResponseBase<RegisterCommandResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var register = await _userToDoCommunicator.Register(new RegisterToDoRequestModel
            {
                 UserName = request.UserName,
                 Password = request.Password,
                 FirstName = request.FirstName,
                 LastName = request.LastName,
                 Email = request.Email
            });
            
            var response = new RegisterCommandResult();

            response.isRegisterCompleted = register.Data.isRegisterCompleted;
            response.Token = register.Data.Token;

            return new ResponseBase<RegisterCommandResult>
            {
                Data = response, 
                Success = register.Success
            };

        }

    }
}

