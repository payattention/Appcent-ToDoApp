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
        Task<ResponseBase<InsertToDoResEntityModel>> Insert(InsertToDoReqEntityModel request);
        Task<ResponseBase<GetAllSectionDetailToDoResEntityModel>> GetSectionsWithDetail(GetAllSectionDetailToDoReqEntityModel request);
    }
}
