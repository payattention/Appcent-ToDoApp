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
    public class GetAllSectionWithDetailsQueryHandler : IRequestHandler<GetAllSectionWithDetailsQuery, ResponseBase<GetAllSectionWithDetailQueryResult>>
    {
        private readonly ISectionToDoCommunicator _sectionToDoCommunicator;

        public GetAllSectionWithDetailsQueryHandler(ISectionToDoCommunicator sectionToDoCommunicator)
        {
            _sectionToDoCommunicator = sectionToDoCommunicator;

        }
        public async Task<ResponseBase<GetAllSectionWithDetailQueryResult>> Handle(GetAllSectionWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var GetSections = await _sectionToDoCommunicator.GetSectionsWithDetails(new GetAllSectionToDoRequestModel
            {
                UserName = request.UserName
            });

            var response = new GetAllSectionWithDetailQueryResult()
            {
                SectionDetail = GetSections.Data.SectionDetail
            };

            return new ResponseBase<GetAllSectionWithDetailQueryResult>
            {
                Data = response,
                Success = GetSections.Success
            };

        }
    }
}
