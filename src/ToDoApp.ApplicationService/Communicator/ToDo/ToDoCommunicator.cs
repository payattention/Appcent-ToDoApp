using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.ToDo.Model;
using ToDoApp.Domain.ToDoAppModels;
using ToDoApp.Repository;

namespace ToDoApp.ApplicationService.Communicator.ToDo
{
    public class ToDoCommunicator : IToDoCommunicator
    {
        public readonly IConfiguration _configValue;
        public readonly IToDoCouchbaseInstruction _toDoCouchbaseInstruction;
        public ToDoCommunicator(IConfiguration configValue, IToDoCouchbaseInstruction toDoCouchbaseInstruction)
        {
            _configValue = configValue;
            _toDoCouchbaseInstruction = toDoCouchbaseInstruction;
        }

        public async Task<ResponseBase<InsertToDoResponseModel>> InsertToDo(InsertToDoRequestModel request)
        {
            var response = new ResponseBase<InsertToDoResponseModel>();

            //response = await _toDoCouchbaseInstruction.Insert(new InsertToDoReqEntityModel()
            //{
            //     MainTaskId = request.MainTaskId,
            //     Name = request.Name,
            //     SectionId = request.SectionId,
            //     ToDoPrimacy = request.ToDoPrimacy,
            //     ToDoState = request.ToDoState,
            //     UserName = request.UserName
            //});


                return response;
            
        }
    }
}
