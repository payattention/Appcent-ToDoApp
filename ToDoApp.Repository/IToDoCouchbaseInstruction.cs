using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public interface IToDoCouchbaseInstruction
    {
        InsertToDoResEntityModel Insert(InsertToDoReqEntityModel request);
    }
}
