using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.UserToDo;
using ToDoApp.ApplicationService.Communicator.UserToDo.Model;
using ToDoApp.Domain.UserToDoModels;
using ToDoApp.Repository;

namespace ToDoApp.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private Mock<IUserCouchbaseRepository> _iUserCouchbaseRepository;
        private UserToDoCommunicator _userToDoCommunicator;

        [SetUp]
        public void SetUp()
        {
            _iUserCouchbaseRepository = new Mock<IUserCouchbaseRepository>();


            _iUserCouchbaseRepository
                .Setup(s => s.Login(It.IsAny<LoginToDoReqEntityModel>()))
                .ReturnsAsync(
                (LoginToDoReqEntityModel s) =>
                  {

                      return new ResponseBase<LoginToDoResEntityModel>()
                      {
                          Success = true,
                          Data = new LoginToDoResEntityModel()
                          {
                              Token = "123"
                          },
                          Message = "asd",
                          MessageCode = "11",
                          UserMessage = "trty"
                      };
                  });

            _userToDoCommunicator = new UserToDoCommunicator(_iUserCouchbaseRepository.Object);
        }

        [Test]
        public async Task Login_CorrectPasswordUserName_ReturnLogged()
        {
            // Arrange

            string expectedUserName = "Erkut";
            string expectedPassword = "test123";
            LoginToDoRequestModel LoginModel = new LoginToDoRequestModel() { UserName = expectedUserName, Password = expectedPassword };

            //Mock<IUserCouchbaseRepository> _userCouchbaseRepo = new Mock<IUserCouchbaseRepository>();
            //UserToDoCommunicator _userToDoCommunicator = new UserToDoCommunicator(_userCouchbaseRepo.Object);


            // Act

            var LoginResponse = await _userToDoCommunicator.Login(LoginModel);

            // Assert

            bool isSuccess = LoginResponse.Success;
            Assert.IsTrue(isSuccess);
        }
    }
}
