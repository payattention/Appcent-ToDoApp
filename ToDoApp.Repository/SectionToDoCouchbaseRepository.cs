using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.SectionToDoModels;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public class SectionToDoCouchbaseRepository : ISectionToDoCouchbaseRepository
    {
        private readonly IBucket _bucket;
        private readonly IToDoCouchbaseRepository _toDoInstruction;

        public SectionToDoCouchbaseRepository(IBucketProvider bucketProvider, IToDoCouchbaseRepository toDoInstruction)
        {
            _bucket = bucketProvider.GetBucket("SectionToDoApp"); // Confige atarsın sonra.
            _toDoInstruction = toDoInstruction;
        }

        public async Task<ResponseBase<InsertSectionToDoResEntityModel>> InsertSection(InsertSectionToDoReqEntityModel request)
        {
            var key = Guid.NewGuid().ToString();

            var result = await _bucket.InsertAsync(key, request);

            return new ResponseBase<InsertSectionToDoResEntityModel>
            {
                Success = result.Success
            };
        }

        public async Task<ResponseBase<DeleteSectionToDoResEntityModel>> DeleteSection(DeleteSectionToDoReqEntityModel request)
        {
            var Ids = new List<string>();
            var response = new ResponseBase<DeleteSectionToDoResEntityModel>();

            //Getting ToDoIds from which deleting Section.
            var ToDoIds = await _toDoInstruction.SelectToDos(request.UserName, request.SectionName);

            foreach (var item in ToDoIds.Data)
            {
                Ids.Add(item.Id.ToString());
            }

            //Delete them with DeleteToDo.
            var AllDeleteToDo = await _toDoInstruction.DeleteToDo(new WhenSectionDiesToDosDieAlsoRequest()
            { 
                Id = Ids
            });

            //Don't forget delete the section. :)
            var result = await _bucket.RemoveAsync(request.SectionId);

            if (ToDoIds.Success && AllDeleteToDo.Success && result.Success)
            {
                response.Success = true;
            }
            else
            {
                throw new Exception("Something went wrong!");
            }


            return new ResponseBase<DeleteSectionToDoResEntityModel>
            {
                Success = response.Success
            };
        }

        public async Task<ResponseBase<UpdateSectionToDoResEntityModel>> UpdateSection(UpdateSectionToDoReqEntityModel request)
        {

            var res = await _bucket.UpsertAsync(request.SectionId, new
            {
                sectionName = request.NewName,
                userName = request.UserName
            });

            var response = new UpdateSectionToDoResEntityModel() 
            { 
                 Section = new UpdatedSectionEntityModel()
            };

            response.Section.SectionName = request.NewName;

            return new ResponseBase<UpdateSectionToDoResEntityModel>
            {
                Data = response,
                Success = res.Success
            };
        }

        
    }
}
