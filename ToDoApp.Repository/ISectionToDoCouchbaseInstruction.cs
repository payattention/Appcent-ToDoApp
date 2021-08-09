using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.SectionToDoModels;

namespace ToDoApp.Repository
{
    public interface ISectionToDoCouchbaseInstruction
    {
        Task<ResponseBase<InsertSectionToDoResEntityModel>> InsertSection(InsertSectionToDoReqEntityModel request);

        Task<ResponseBase<UpdateSectionToDoResEntityModel>> UpdateSection(UpdateSectionToDoReqEntityModel request);

        Task<ResponseBase<DeleteSectionToDoResEntityModel>> DeleteSection(DeleteSectionToDoReqEntityModel request);

    }
}
