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
        public readonly IToDoCouchbaseRepository _toDoCouchbaseInstruction;
        public ToDoCommunicator(IConfiguration configValue, IToDoCouchbaseRepository toDoCouchbaseInstruction)
        {
            _configValue = configValue;
            _toDoCouchbaseInstruction = toDoCouchbaseInstruction;
        }

        public async Task<ResponseBase<InsertToDoResponseModel>> InsertToDo(InsertToDoRequestModel request)
        {
            //Going to Repo
            var InsertToDoResponse = await _toDoCouchbaseInstruction.InsertToDo(new InsertToDoReqEntityModel()
            {
                ToDo = request.ToDo,
                SectionName = request.SectionName,
                ToDoPrimacy = (Domain.BaseModels.ToDoPrimacy)request.ToDoPrimacy,
                ToDoState = (Domain.BaseModels.ToDoState)request.ToDoState,
                UserName = request.UserName
            });

            return new ResponseBase<InsertToDoResponseModel>
            {
                Success = InsertToDoResponse.Success
            };

        }

        public async Task<ResponseBase<DeleteToDoResponseModel>> DeleteToDo(DeleteToDoRequestModel request)
        {
            //Going to Repo
            var InsertToDoResponse = await _toDoCouchbaseInstruction.DeleteToDo(new DeleteToDoReqEntityModel()
            {
                Id = request.Id
            });

            return new ResponseBase<DeleteToDoResponseModel>
            {
                Success = InsertToDoResponse.Success
            };

        }

        public async Task<ResponseBase<UpdateToDoResponseModel>> UpdateToDo(UpdateToDoRequestModel request)
        {
            //Going to Repo
            var UpdateToDoResponse = await _toDoCouchbaseInstruction.UpdateToDo(new UpdateToDoReqEntityModel()
            {
                ToDo = request.ToDo,
                ToDoId = request.ToDoId,
                UserName = request.UserName,
                ToDoState = (Domain.BaseModels.ToDoState)request.ToDoState,
                ToDoPrimacy = (Domain.BaseModels.ToDoPrimacy)request.ToDoPrimacy
            });

            var response = new UpdateToDoResponseModel()
            {
                ToDo = new Model.ToDoModel() 
            };

            response.ToDo.Id = UpdateToDoResponse.Data.ToDo.Id;
            response.ToDo.ToDo = UpdateToDoResponse.Data.ToDo.ToDo;
            response.ToDo.SectionName = UpdateToDoResponse.Data.ToDo.SectionName;
            response.ToDo.ToDoPrimacy = (Model.ToDoPrimacy)UpdateToDoResponse.Data.ToDo.ToDoPrimacy;
            response.ToDo.ToDoState = (Model.ToDoState)UpdateToDoResponse.Data.ToDo.ToDoState;

            return new ResponseBase<UpdateToDoResponseModel>
            {
                Data = response,
                Success = UpdateToDoResponse.Success
            };

        }
    }
}
