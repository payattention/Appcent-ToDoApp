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
    public class DeleteSectionToDoCommandHandler : IRequestHandler<DeleteSectionToDoCommand, ResponseBase<DeleteSectionToDoCommandResult>>
    {
        private readonly ISectionToDoCommunicator _deleteSectionToDoCommunicator;


        public DeleteSectionToDoCommandHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _deleteSectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<DeleteSectionToDoCommandResult>> Handle(DeleteSectionToDoCommand request, CancellationToken cancellationToken)
        {
            var DeleteSectionToDo = await _deleteSectionToDoCommunicator.DeleteSection(new DeleteSectionToDoRequestModel
            {
                SectionName = request.SectionName,
                UserName = request.UserName,
                SectionId = request.SectionId
            });

            return new ResponseBase<DeleteSectionToDoCommandResult>
            {
                Success = DeleteSectionToDo.Success
            };
        }
    }
}
