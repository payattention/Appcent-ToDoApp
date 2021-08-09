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
    public class UpdateSectionToDoCommandHandler : IRequestHandler<UpdateSectionToDoCommand, ResponseBase<UpdateSectionToDoCommandResult>>
    {
        private readonly ISectionToDoCommunicator _sectionToDoCommunicator;


        public UpdateSectionToDoCommandHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _sectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<UpdateSectionToDoCommandResult>> Handle(UpdateSectionToDoCommand request, CancellationToken cancellationToken)
        {
            var UpdateSectionToDo = await _sectionToDoCommunicator.UpdateSection(new UpdateSectionToDoRequestModel
            {
                SectionId = request.SectionId,
                UserName = request.UserName,
                NewName = request.NewName
            });

            var response = new UpdateSectionToDoCommandResult()
            { 
                 Section = new SectionModel()
            };

            response.Section.SectionName = UpdateSectionToDo.Data.Section.SectionName;

            return new ResponseBase<UpdateSectionToDoCommandResult>
            {
                Data = response,
                Success = UpdateSectionToDo.Success
            };

        }

    }
}
