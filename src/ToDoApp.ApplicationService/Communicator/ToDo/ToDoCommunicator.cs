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
            //Going to Repo
            var InsertToDoResponse = await _toDoCouchbaseInstruction.Insert(new InsertToDoReqEntityModel()
            {
                MainTaskId = request.MainTaskId,
                Name = request.Name,
                SectionId = request.SectionId,
                ToDoPrimacy = (Domain.BaseModels.ToDoPrimacy)request.ToDoPrimacy,
                ToDoState = (Domain.BaseModels.ToDoState)request.ToDoState,
                UserName = request.UserName
            });

            return new ResponseBase<InsertToDoResponseModel>
            {
                Success = InsertToDoResponse.Success
            };

        }
    }
}
