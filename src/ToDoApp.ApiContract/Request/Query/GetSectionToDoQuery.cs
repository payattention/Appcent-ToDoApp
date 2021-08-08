using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Query;

namespace ToDoApp.ApiContract.Request.Query
{
    public class GetSectionToDoQuery : IRequest<ResponseBase<GetSectionToDoQueryResult>>
    {
        [Required]
        public string UserName { get; set; }

    }
}
