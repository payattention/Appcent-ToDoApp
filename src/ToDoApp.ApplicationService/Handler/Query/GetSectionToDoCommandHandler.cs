using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Query;
using ToDoApp.ApiContract.Response.Query;
using ToDoApp.ApplicationService.Communicator.SectionTodo;
using ToDoApp.ApplicationService.Communicator.SectionTodo.Model;

namespace ToDoApp.ApplicationService.Handler.Query
{
    public class GetSectionToDoCommandHandler : IRequestHandler<GetSectionToDoQuery, ResponseBase<GetSectionToDoQueryResult>>
    {
        private readonly ISectionToDoCommunicator _sectionToDoCommunicator;

        public GetSectionToDoCommandHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _sectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<GetSectionToDoQueryResult>> Handle(GetSectionToDoQuery request, CancellationToken cancellationToken)
        {
            var GetSections = await _sectionToDoCommunicator.GetSections(new GetSectionToDoRequestModel
            {
                 UserName = request.UserName
            });

            var response = new GetSectionToDoQueryResult()
            {
                 SectionList = GetSections.Data.SectionNames
            };

            return new ResponseBase<GetSectionToDoQueryResult>
            {
                Data = response,
                Success = GetSections.Success
            };

        }
    }
}
