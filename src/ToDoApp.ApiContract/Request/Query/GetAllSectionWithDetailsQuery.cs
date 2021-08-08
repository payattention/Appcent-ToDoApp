using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Query;

namespace ToDoApp.ApiContract.Request.Query
{
    public class GetAllSectionWithDetailsQuery : IRequest<ResponseBase<GetAllSectionWithDetailQueryResult>>
    {
        [Required]
        public string UserName{ get; set; }

    }
}
