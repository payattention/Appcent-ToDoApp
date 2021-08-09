using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.ToDo.Model;

namespace ToDoApp.ApplicationService.Communicator.ToDo
{
    public interface IToDoCommunicator
    {
        Task<ResponseBase<InsertToDoResponseModel>> InsertToDo(InsertToDoRequestModel request);
        Task<ResponseBase<DeleteToDoResponseModel>> DeleteToDo(DeleteToDoRequestModel request);
        Task<ResponseBase<UpdateToDoResponseModel>> UpdateToDo(UpdateToDoRequestModel request);
    }
}
