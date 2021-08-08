using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.SectionToDoModels;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public class ToDoCouchbaseInstruction : IToDoCouchbaseInstruction
    {
        private readonly IBucket _bucket;
        private readonly ISectionToDoCouchbaseInstruction _sectionToDoCouchbaseInstruction;

        public ToDoCouchbaseInstruction(IBucketProvider bucketProvider, ISectionToDoCouchbaseInstruction sectionToDoCouchbaseInstruction)
        {
            _bucket = bucketProvider.GetBucket("ToDoApp"); // Confige atarsın sonra.
            _sectionToDoCouchbaseInstruction = sectionToDoCouchbaseInstruction;
        }

        public async Task<ResponseBase<InsertToDoResEntityModel>> Insert(InsertToDoReqEntityModel request)
        {
            var key = Guid.NewGuid().ToString();

            var result =  await _bucket.InsertAsync(key, request);

            return new ResponseBase<InsertToDoResEntityModel>
            {
                Success = result.Success
            };
        }

        public async Task<ResponseBase<GetAllSectionDetailToDoResEntityModel>> GetSectionsWithDetail(GetAllSectionDetailToDoReqEntityModel request)
        {

            var response = new ResponseBase<GetAllSectionDetailToDoResEntityModel>()
            {
                 Data = new GetAllSectionDetailToDoResEntityModel()
            };

            var SectionDetailList = new List<SectionDetailEntityModel>();

            var innerRequest = new GetSectionToDoReqEntityModel() 
            { 
                UserName = request.UserName 
            };

            var sections = _sectionToDoCouchbaseInstruction.GetSections(innerRequest);

            var sectionList = sections.Result.Data.SectionList
            .Select(x => new SectionModel() { SectionName = x.sectionName })
            .ToList();

            foreach (var item in sectionList)
            {
                var n1ql = @"select s.*, META(s).id from ToDoApp s where s.userName =$userName and s.sectionName =$sectionName";
                var query = QueryRequest.Create(n1ql).AddNamedParameter("$userName", request.UserName)
                    .AddNamedParameter("$sectionName", item.SectionName);
                query.ScanConsistency(ScanConsistency.RequestPlus);

                var result = await _bucket.QueryAsync<ToDoEntityModel>(query);

                var SectionDetail = new SectionDetailEntityModel()
                {
                    TodoList = result.Rows,
                    SectionName = item.SectionName
                };

                SectionDetailList.Add(SectionDetail);

                
                response.Success = result.Success;
                response.Data.SectionDetail = SectionDetailList;
            }

            return new ResponseBase<GetAllSectionDetailToDoResEntityModel>
            {
                Data = response.Data,
                Success = response.Success
            };


        }

    }
}
