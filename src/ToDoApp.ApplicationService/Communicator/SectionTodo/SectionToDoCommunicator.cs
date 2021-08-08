using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApplicationService.Communicator.SectionTodo.Model;
using ToDoApp.Domain.SectionToDoModels;
using ToDoApp.Repository;

namespace ToDoApp.ApplicationService.Communicator.SectionTodo
{
    public class SectionToDoCommunicator : ISectionToDoCommunicator
    {
        private readonly ISectionToDoCouchbaseInstruction _sectionToDoCouchbaseInstruction;
        private readonly IToDoCouchbaseInstruction _toDoCouchbaseInstruction;
        public SectionToDoCommunicator(ISectionToDoCouchbaseInstruction sectionToDoCouchbaseInstruction, IToDoCouchbaseInstruction toDoCouchbaseInstruction)
        {
            _sectionToDoCouchbaseInstruction = sectionToDoCouchbaseInstruction;
            _toDoCouchbaseInstruction = toDoCouchbaseInstruction;
        }

        public async Task<ResponseBase<InsertSectionToDoResponseModel>> InsertSection(InsertSectionToDoRequestModel request)
        {
            var InsertSectionToDoResponse = await _sectionToDoCouchbaseInstruction.InsertSection(new InsertSectionToDoReqEntityModel()
            {
                SectionName = request.SectionName,
                UserName = request.UserName
            });

            return new ResponseBase<InsertSectionToDoResponseModel>
            {
                Success = InsertSectionToDoResponse.Success
            };
        }

        public async Task<ResponseBase<GetSectionToDoResponseModel>> GetSections(GetSectionToDoRequestModel request)
        {
            var GetSectionsToDoResponse = await _sectionToDoCouchbaseInstruction.GetSections(new GetSectionToDoReqEntityModel()
            {
                UserName = request.UserName
            });

            var response = new GetSectionToDoResponseModel();

            var sectionList = GetSectionsToDoResponse.Data.SectionList
           .Select(x => new SectionModel() { SectionName = x.sectionName })
           .ToList();

            response.SectionNames = sectionList;

            return new ResponseBase<GetSectionToDoResponseModel>
            {
                Data = response,
                Success = GetSectionsToDoResponse.Success
            };
        }

        public async Task<ResponseBase<GetAllSectionToDoResponseModel>> GetSectionsWithDetails(GetAllSectionToDoRequestModel request)
        {
            var GetSectionsToDoResponse = await _toDoCouchbaseInstruction.GetSectionsWithDetail(new GetAllSectionDetailToDoReqEntityModel()
            {
                UserName = request.UserName
            });

            var SectionDetailList = new List<SectionDetailModel>();

            var response = new GetAllSectionToDoResponseModel();

            foreach (var item in GetSectionsToDoResponse.Data.SectionDetail)
            {

                var ToDoList = item.TodoList.Select(x => new ToDoModel()
                {
                    CreateDate = x.CreateDate,
                    Id = x.Id,
                    SectionName = x.SectionName,
                    ToDo = x.ToDo,
                    ToDoPrimacy = x.ToDoPrimacy,
                    ToDoState = x.ToDoState
                });

                var SectionDetail = new SectionDetailModel()
                {
                    TodoList = ToDoList,
                    SectionName = item.SectionName
                };

                SectionDetailList.Add(SectionDetail);

            }

            response.SectionDetail = SectionDetailList;

            return new ResponseBase<GetAllSectionToDoResponseModel>
            {
                Data = response,
                Success = GetSectionsToDoResponse.Success
            };
        }
    }
}
