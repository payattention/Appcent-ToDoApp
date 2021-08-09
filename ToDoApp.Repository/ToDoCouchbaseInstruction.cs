using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.BaseModels;
using ToDoApp.Domain.SectionToDoModels;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Repository
{
    public class ToDoCouchbaseInstruction : IToDoCouchbaseInstruction
    {
        private readonly IBucket _bucket;
        private readonly IBucket _bucketSection;

        private readonly ISectionToDoCouchbaseInstruction _sectionToDoCouchbaseInstruction;

        public ToDoCouchbaseInstruction(IBucketProvider bucketProvider, IBucketProvider bucketProviderSection, ISectionToDoCouchbaseInstruction sectionToDoCouchbaseInstruction)
        {
            _bucket = bucketProvider.GetBucket("ToDoApp"); // Confige atarsın sonra.
            _bucketSection = bucketProviderSection.GetBucket("SectionToDoApp");
            _sectionToDoCouchbaseInstruction = sectionToDoCouchbaseInstruction;
        }

        public async Task<ResponseBase<InsertToDoResEntityModel>> InsertToDo(InsertToDoReqEntityModel request)
        {
            var key = Guid.NewGuid().ToString();

            var result = await _bucket.InsertAsync(key, request);

            return new ResponseBase<InsertToDoResEntityModel>
            {
                Success = result.Success
            };
        }

        public async Task<ResponseBase<DeleteToDoResEntityModel>> DeleteToDo(DeleteToDoReqEntityModel request)
        {

            var result = await _bucket.RemoveAsync(request.Id);

            return new ResponseBase<DeleteToDoResEntityModel>
            {
                Success = result.Success
            };
        }

        public async Task<ResponseBase<UpdateToDoResEntityModel>> UpdateToDo(UpdateToDoReqEntityModel request)
        {
            var response = new UpdateToDoResEntityModel();
            var n1ql = @"select s.* from ToDoApp s where s.userName =$userName and META(s).id =$toDoId";
            var query = QueryRequest.Create(n1ql).AddNamedParameter("$userName", request.UserName)
                .AddNamedParameter("$toDoId", request.ToDoId);
            query.ScanConsistency(ScanConsistency.RequestPlus);

            var result = await _bucket.QueryAsync<ToDoEntityModel>(query);

            if (request.ToDo != null && result.Success)
            {
                foreach (var item in result)
                {
                    //If ToDo, ToDoState and ToDoPrimacy need to update.
                    if (request.ToDoState.ToString() != item.ToDoState.ToString() && request.ToDoPrimacy.ToString() != item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = request.ToDo,
                            toDoPrimacy = request.ToDoPrimacy,
                            ToDoState = request.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, request.ToDo, request.ToDoState, request.ToDoPrimacy);
                    }
                    //If ToDo and ToDoState need to update.
                    if (request.ToDoState.ToString() != item.ToDoState.ToString() && request.ToDoPrimacy.ToString() == item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = request.ToDo,
                            toDoPrimacy = item.ToDoPrimacy,
                            ToDoState = request.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, request.ToDo, request.ToDoState, item.ToDoPrimacy);
                    }
                    if (request.ToDoState.ToString() == item.ToDoState.ToString() && request.ToDoPrimacy.ToString() != item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = request.ToDo,
                            toDoPrimacy = request.ToDoPrimacy,
                            ToDoState = item.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, request.ToDo, item.ToDoState, request.ToDoPrimacy);
                    }
                    else
                    {
                        //If ToDo needs to update.
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = request.ToDo,
                            toDoPrimacy = item.ToDoPrimacy,
                            ToDoState = item.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, request.ToDo, item.ToDoState, item.ToDoPrimacy);
                    }
                }
            }
            else
            {
                //throw Exception;
            }

            if (request.ToDo == null && result.Success)
            {
                foreach (var item in result)
                {
                    //If ToDo, ToDoState and ToDoPrimacy need to update.
                    if (request.ToDoState.ToString() != item.ToDoState.ToString() && request.ToDoPrimacy.ToString() != item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = item.ToDo,
                            toDoPrimacy = request.ToDoPrimacy,
                            ToDoState = request.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, item.ToDo, request.ToDoState, request.ToDoPrimacy);
                    }
                    //If ToDo and ToDoState need to update.
                    if (request.ToDoState.ToString() != item.ToDoState.ToString() && request.ToDoPrimacy.ToString() == item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = item.ToDo,
                            toDoPrimacy = item.ToDoPrimacy,
                            ToDoState = request.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, item.ToDo, request.ToDoState, item.ToDoPrimacy);
                    }
                    if (request.ToDoState.ToString() == item.ToDoState.ToString() && request.ToDoPrimacy.ToString() != item.ToDoPrimacy.ToString())
                    {
                        var res = await _bucket.UpsertAsync(request.ToDoId, new
                        {
                            sectionName = item.SectionName,
                            toDo = item.ToDo,
                            toDoPrimacy = request.ToDoPrimacy,
                            ToDoState = item.ToDoState,
                            userName = request.UserName
                        });

                        response = MatchToDoModel(request.ToDoId, item.SectionName, item.ToDo, item.ToDoState, request.ToDoPrimacy);
                    }
                }
            }
            else
            {
                //throw Exception;
            }

            return new ResponseBase<UpdateToDoResEntityModel>
            {
                Data = response,
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
                //var n1ql = @"select META(s).id from SectionToDoApp s where s.userName =$userName and s.sectionName =$sectionName";
                //var query = QueryRequest.Create(n1ql).AddNamedParameter("$userName", request.UserName)
                //    .AddNamedParameter("$sectionName", item.SectionName);
                //query.ScanConsistency(ScanConsistency.RequestPlus);

                //var result = await _bucketSection.QueryAsync<MetaId>(query);


                var n2ql = @"select s.*, META(s).id from ToDoApp s where s.userName =$userName and s.sectionName =$sectionName";
                var query2 = QueryRequest.Create(n2ql).AddNamedParameter("$userName", request.UserName)
                    .AddNamedParameter("$sectionName", item.SectionName);
                query2.ScanConsistency(ScanConsistency.RequestPlus);

                var resultDetails = await _bucket.QueryAsync<ToDoEntityModel>(query2);

                var SectionDetail = new SectionDetailEntityModel()
                {
                    TodoList = resultDetails.Rows,
                    SectionName = item.SectionName
                };

                SectionDetailList.Add(SectionDetail);


                response.Success = resultDetails.Success;
                response.Data.SectionDetail = SectionDetailList;
            }

            return new ResponseBase<GetAllSectionDetailToDoResEntityModel>
            {
                Data = response.Data,
                Success = response.Success
            };


        }

        public UpdateToDoResEntityModel MatchToDoModel(string id, string sectionName, string toDo, Domain.BaseModels.ToDoState toDoState, Domain.BaseModels.ToDoPrimacy toDoPrimacy)
        {
            var response = new UpdateToDoResEntityModel()
            {
                ToDo = new Domain.BaseModels.ToDoModel()
                {
                    Id = id,
                    SectionName = sectionName,
                    ToDo = toDo,
                    ToDoPrimacy = toDoPrimacy,
                    ToDoState = toDoState
                }
            };

            return response;
        }

    }
}
