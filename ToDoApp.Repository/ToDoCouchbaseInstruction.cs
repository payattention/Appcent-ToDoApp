using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.BaseModels;
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

        public InsertToDoResEntityModel Insert(InsertToDoReqEntityModel request)
        {
            var response = new InsertToDoResEntityModel();



            return response;
        }

        //public ToDoSection InsertSection()
        //{

        //}

    }
}
