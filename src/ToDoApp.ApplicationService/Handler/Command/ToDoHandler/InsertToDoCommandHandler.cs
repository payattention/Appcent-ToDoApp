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
    public class InsertToDoCommandHandler : IRequestHandler<InsertToDoCommand, ResponseBase<InsertToDoCommandResult>>
    {
        private readonly IToDoCommunicator _toDoCommunicator;

        public InsertToDoCommandHandler(IToDoCommunicator identityCommunicator)
        {
            _toDoCommunicator = identityCommunicator;
        }
        public async Task<ResponseBase<InsertToDoCommandResult>> Handle(InsertToDoCommand request, CancellationToken cancellationToken)
        {
            var insertToDo = await _toDoCommunicator.InsertToDo(new InsertToDoRequestModel
            {
                
            });

            return new ResponseBase<InsertToDoCommandResult>
            {
                Data = new InsertToDoCommandResult 
                { 
                    // Dolduracaksın.
                },
                Success = insertToDo.Success

            };

        }

    }
}