using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.SectionToDoModels;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public interface IToDoCouchbaseInstruction
    {
        Task<ResponseBase<InsertToDoResEntityModel>> InsertToDo(InsertToDoReqEntityModel request);
        Task<ResponseBase<DeleteToDoResEntityModel>> DeleteToDo(DeleteToDoReqEntityModel request);
        Task<ResponseBase<UpdateToDoResEntityModel>> UpdateToDo(UpdateToDoReqEntityModel request);
        Task<ResponseBase<GetAllSectionDetailToDoResEntityModel>> GetSectionsWithDetail(GetAllSectionDetailToDoReqEntityModel request);
    }
}
