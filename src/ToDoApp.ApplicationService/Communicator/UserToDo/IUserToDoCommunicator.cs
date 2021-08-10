using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.UserToDo.Model;

namespace ToDoApp.ApplicationService.Communicator.UserToDo
{
    public interface IUserToDoCommunicator
    {
        Task<ResponseBase<RegisterToDoResponseModel>> Register(RegisterToDoRequestModel request);
        Task<ResponseBase<LoginToDoResponseModel>> Login(LoginToDoRequestModel request);
    }
}
