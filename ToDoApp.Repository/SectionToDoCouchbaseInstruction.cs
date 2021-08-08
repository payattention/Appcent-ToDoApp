using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.SectionToDoModels;

namespace ToDoApp.Repository
{
    public class SectionToDoCouchbaseInstruction : ISectionToDoCouchbaseInstruction
    {
        private readonly IBucket _bucket;

        public SectionToDoCouchbaseInstruction(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("SectionToDoApp"); // Confige atarsın sonra.
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

        public async Task<ResponseBase<GetSectionToDoResEntityModel>> GetSections(GetSectionToDoReqEntityModel request)
        {
            var n1ql = @"select s.* from SectionToDoApp s where s.userName =$userName";
            var query = QueryRequest.Create(n1ql).AddNamedParameter("$userName", request.UserName);
            query.ScanConsistency(ScanConsistency.RequestPlus);

            var result = await _bucket.QueryAsync<SectionEntityModel>(query);

            var response = new GetSectionToDoResEntityModel()
            {
                 SectionList = result.Rows
            };

            return new ResponseBase<GetSectionToDoResEntityModel>
            {
                Data = response,
                Success = result.Success
            };
        }
    }
}
