using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.SectionCommands;
using ToDoApp.ApiContract.Response.Command.SectionCommands;
using ToDoApp.ApplicationService.Communicator.SectionTodo;
using ToDoApp.ApplicationService.Communicator.SectionTodo.Model;

namespace ToDoApp.ApplicationService.Handler.Command.SectionToDoHandler
{
    public class InsertSectionToDoCommandHandler : IRequestHandler<InsertSectionToDoCommand, ResponseBase<InsertSectionToDoCommandResult>>
    {
        private readonly ISectionToDoCommunicator _sectionToDoCommunicator;


        public InsertSectionToDoCommandHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _sectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<InsertSectionToDoCommandResult>> Handle(InsertSectionToDoCommand request, CancellationToken cancellationToken)
        {
            var insertToDo = await _sectionToDoCommunicator.InsertToDo(new InsertSectionToDoRequestModel
            {
                MainTaskId = request.MainTaskId,
                Name = request.Name,
                SectionId = request.SectionId,
                ToDoPrimacy = (Communicator.ToDo.Model.ToDoPrimacy)request.ToDoPrimacy,
                ToDoState = (Communicator.ToDo.Model.ToDoState)request.ToDoState,
                UserName = request.UserName
            });

            return new ResponseBase<InsertSectionToDoCommandResult>
            {
                Success = insertToDo.Success
            };

        }

    }
}
