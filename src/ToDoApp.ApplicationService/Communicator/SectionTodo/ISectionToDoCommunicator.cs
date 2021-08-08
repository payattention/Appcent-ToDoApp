using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.SectionTodo.Model;

namespace ToDoApp.ApplicationService.Communicator.SectionTodo
{
    public interface ISectionToDoCommunicator
    {
        Task<ResponseBase<InsertSectionToDoResponseModel>> InsertSection(InsertSectionToDoRequestModel request);
        Task<ResponseBase<GetSectionToDoResponseModel>> GetSections(GetSectionToDoRequestModel request);
        Task<ResponseBase<GetAllSectionToDoResponseModel>> GetSectionsWithDetails(GetAllSectionToDoRequestModel request);
    }
}
