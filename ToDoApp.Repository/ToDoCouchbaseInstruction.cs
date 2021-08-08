using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public class ToDoCouchbaseInstruction : IToDoCouchbaseInstruction
    {
        private readonly IBucket _bucket;

        public ToDoCouchbaseInstruction(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("ToDoApp"); // Confige atarsın sonra.
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

        //public ToDoSection InsertSection()
        //{

        //}

    }
}
