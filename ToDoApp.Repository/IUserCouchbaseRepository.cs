using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.UserToDoModels;

namespace ToDoApp.Repository
{
    public interface IUserCouchbaseRepository
    {
        Task<ResponseBase<RegisterToDoResEntityModel>> Register(RegisterToDoReqEntityModel request);

        Task<ResponseBase<LoginToDoResEntityModel>> Login(LoginToDoReqEntityModel request);

    }
}
