using MediatR;
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
                MainTaskId = request.MainTaskId,
                Name = request.Name,
                SectionId = request.SectionId,
                ToDoPrimacy = (Communicator.ToDo.Model.ToDoPrimacy)request.ToDoPrimacy,
                ToDoState = (Communicator.ToDo.Model.ToDoState)request.ToDoState,
                UserName = request.UserName
            });

            return new ResponseBase<InsertToDoCommandResult>
            {
                Success = insertToDo.Success
            };

        }

    }
}