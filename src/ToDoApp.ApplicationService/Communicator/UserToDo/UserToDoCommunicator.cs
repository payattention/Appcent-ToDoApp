using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.UserToDo.Model;
using ToDoApp.Domain.UserToDoModels;
using ToDoApp.Repository;

namespace ToDoApp.ApplicationService.Communicator.UserToDo
{
    public class UserToDoCommunicator : IUserToDoCommunicator
    {
        public readonly IUserCouchbaseRepository _userCouchbaseInstruction;
        public UserToDoCommunicator(IUserCouchbaseRepository userCouchbaseInstruction)
        {
            _userCouchbaseInstruction = userCouchbaseInstruction;
        }

        public async Task<ResponseBase<RegisterToDoResponseModel>> Register(RegisterToDoRequestModel request)
        {
            //Going to Repo
            var RegisterResponse = await _userCouchbaseInstruction.Register(new RegisterToDoReqEntityModel()
            {
                 UserName = request.UserName,
                 Email = request.Email,
                 Password = request.Password,
            });

            var response = new RegisterToDoResponseModel()
            {
                isRegisterCompleted = RegisterResponse.Data.isRegisterCompleted,
                Token = RegisterResponse.Data.Token
            };


            return new ResponseBase<RegisterToDoResponseModel>
            {
                Data = response,
                Success = RegisterResponse.Success
            };

        }

        public async Task<ResponseBase<LoginToDoResponseModel>> Login(LoginToDoRequestModel request)
        {
            var response = new ResponseBase<LoginToDoResponseModel>();
            //Going to Repo
            var LoginResponse = await _userCouchbaseInstruction.Login(new LoginToDoReqEntityModel()
            {
                UserName = request.UserName,
                Password = request.Password
            });

            response.Data = new LoginToDoResponseModel() 
            { 
               Token = LoginResponse.Data.Token
            };

            return new ResponseBase<LoginToDoResponseModel>
            {
                Data = response.Data,
                Success = LoginResponse.Success
            };

        }
    }
}
