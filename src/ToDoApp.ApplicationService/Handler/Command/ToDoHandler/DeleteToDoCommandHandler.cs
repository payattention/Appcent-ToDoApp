using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.ToDoCommands;
using ToDoApp.ApiContract.Response.Command;
using ToDoApp.ApplicationService.Communicator.ToDo;
using ToDoApp.ApplicationService.Communicator.ToDo.Model;

namespace ToDoApp.ApplicationService.Handler.Command.ToDoHandler
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, ResponseBase<DeleteToDoCommandResult>>
    {
        private readonly IToDoCommunicator _toDoCommunicator;


        public DeleteToDoCommandHandler(IToDoCommunicator identityCommunicator)
        {
            _toDoCommunicator = identityCommunicator;

        }
        public async Task<ResponseBase<DeleteToDoCommandResult>> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var DeleteToDo = await _toDoCommunicator.DeleteToDo(new DeleteToDoRequestModel
            {
                 Id = request.TodoId
            });

            return new ResponseBase<DeleteToDoCommandResult>
            {
                Success = DeleteToDo.Success
            };

        }

    }
}
