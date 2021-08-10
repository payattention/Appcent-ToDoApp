using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.ToDoCommands;
using ToDoApp.ApiContract.Response.Command.ToDoCommandsResult;
using ToDoApp.ApplicationService.Communicator.ToDo;
using ToDoApp.ApplicationService.Communicator.ToDo.Model;

namespace ToDoApp.ApplicationService.Handler.Command.ToDoHandler
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ResponseBase<UpdateToDoCommandResult>>
    {
        private readonly IToDoCommunicator _toDoCommunicator;


        public UpdateToDoCommandHandler(IToDoCommunicator identityCommunicator)
        {
            _toDoCommunicator = identityCommunicator;

        }
        public async Task<ResponseBase<UpdateToDoCommandResult>> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var UpdateToDo = await _toDoCommunicator.UpdateToDo(new UpdateToDoRequestModel
            {
                ToDo = request.ToDo,
                ToDoId = request.ToDoId,
                UserName = request.UserName,
                ToDoState = (Communicator.ToDo.Model.ToDoState)request.ToDoState,
                ToDoPrimacy = (Communicator.ToDo.Model.ToDoPrimacy)request.ToDoPrimacy
            });

            var response = new UpdateToDoCommandResult()
            {
                ToDo = new ApiContract.Contracts.ToDoModel()
                {
                    Id = UpdateToDo.Data.ToDo.Id,
                    ToDo = UpdateToDo.Data.ToDo.ToDo,
                    SectionName = UpdateToDo.Data.ToDo.SectionName,
                    ToDoPrimacy = (ApiContract.Contracts.ToDoPrimacy)UpdateToDo.Data.ToDo.ToDoPrimacy,
                    ToDoState = (ApiContract.Contracts.ToDoState)UpdateToDo.Data.ToDo.ToDoState
                }
            };

            return new ResponseBase<UpdateToDoCommandResult>
            {
                Data = response,
                Success = UpdateToDo.Success
            };

        }

    }
}
