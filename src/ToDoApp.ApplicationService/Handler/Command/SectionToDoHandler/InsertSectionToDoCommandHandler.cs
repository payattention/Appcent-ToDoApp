using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.SectionCommands;
using ToDoApp.ApiContract.Response.Command.SectionCommandsResult;
using ToDoApp.ApplicationService.Communicator.SectionTodo;
using ToDoApp.ApplicationService.Communicator.SectionTodo.Model;

namespace ToDoApp.ApplicationService.Handler.Command.SectionToDoHandler
{
    public class InsertSectionToDoCommandHandler : IRequestHandler<InsertSectionToDoCommand, ResponseBase<InsertSectionToDoCommandResult>>
    {
        private readonly ISectionToDoCommunicator _insertSectionToDoCommunicator;


        public InsertSectionToDoCommandHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _insertSectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<InsertSectionToDoCommandResult>> Handle(InsertSectionToDoCommand request, CancellationToken cancellationToken)
        {
            var insertToDo = await _insertSectionToDoCommunicator.InsertSection(new InsertSectionToDoRequestModel
            {
                SectionName = request.SectionName,
                UserName = request.UserName
            });

            return new ResponseBase<InsertSectionToDoCommandResult>
            {
                Success = insertToDo.Success
            };

        }

    }
}
