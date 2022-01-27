﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Runtime.ConstrainedExecution;

namespace MongoSample.Controllers
{
    public class MongoSampleController : BaseController
    {
        private readonly ILogger<MongoSampleController> _logger;
        //private readonly IMongoClient _mongoClient = new MongoClient("mongodb://47.94.85.108:27017");
        private readonly IMongoClient _mongoClient = new MongoClient("mongodb://localhost:27017");
        private readonly IMongoDatabase _mongoDatabase;

        public MongoSampleController(ILogger<MongoSampleController> logger)
        {
            _logger = logger;
            _mongoDatabase = _mongoClient.GetDatabase("zxc");
        }

        #region insert

        /// <summary>
        /// 添加单个文档
        /// </summary>
        [HttpPost]
        public async Task InsertSingleDocment()
        {
            var document = new BsonDocument
            {
                {"item", "canvas"},
                {"qty", 200},
                {"tags", new BsonArray {"cotton"}},
                {"size", new BsonDocument {{"h", 38}, {"w", 45.5}, {"zom", "dm"}}}
            };
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            collection.InsertOne(document);
        }

        /// <summary>
        /// 添加多个文档
        /// </summary>
        [HttpPost]
        public async Task InsertManyDocment()
        {
            var documents = new BsonDocument[]
            {
                new BsonDocument
                {
                    {"item", "journal"},
                    {"qty", 25},
                    {"tags", new BsonArray {"blank", "red"}},
                    {"size", new BsonDocument {{"h", 14}, {"w", 21}, {"uom", "cm"}}}
                },
                new BsonDocument
                {
                    {"item", "mat"},
                    {"qty", 85},
                    {"tags", new BsonArray {"gray"}},
                    {"size", new BsonDocument {{"h", 27.9}, {"w", 35.5}, {"uom", "cm"}}}
                },
                new BsonDocument
                {
                    {"item", "mousepad"},
                    {"qty", 25},
                    {"tags", new BsonArray {"gel", "blue"}},
                    {"size", new BsonDocument {{"h", 19}, {"w", 22.85}, {"uom", "cm"}}}
                },
            };
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            collection.InsertMany(documents);
        }

        #endregion

        #region Find

        /// <summary>
        /// 查询所有文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindAll()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 相等条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindEq()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "D");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 指定条件运算符查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindIn()
        {
            var filter = Builders<BsonDocument>.Filter.In("status", new[] { "A", "D" });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 指定 And 条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindAnd()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Eq("status", "A"), builder.Lt("qty", 30));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 指定 Or 条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindOr()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Or(builder.Eq("status", "D"), builder.Lt("qty", 30));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 指定 And 和 Or 条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindAnd_Or()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(
                builder.Eq("status", "A"),
                builder.Or(builder.Lt("qty", 30), builder.Regex("item", new BsonRegularExpression("^p"))));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 匹配嵌套文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindEqDocument()
        {
            var filter =
                Builders<BsonDocument>.Filter.Eq("size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 嵌套字段相等匹配
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindEqNestedField()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("size.uom", "in");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 指定运算符查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindNestedFieldOperator()
        {
            var filter = Builders<BsonDocument>.Filter.Lt("size.h", 15);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 嵌套文档 - And
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindNestedFieldAnd()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Lt("size.h", 15), builder.Eq("size.uom", "in"), builder.Eq("status", "D"));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 匹配一个数组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindEqArray()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("tags", new[] { "red", "blank" });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 匹配数组忽略元素和顺序
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindEqArrayIgnoreElementAndElementOrder()
        {
            var filter = Builders<BsonDocument>.Filter.All("tags", new[] { "red", "blank" });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 查询数组中包含某个元素的文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayElement()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("tags", "plain");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 查询数组包含指定条件的元素
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayElementOperator()
        {
            var filter = Builders<BsonDocument>.Filter.Gt("dim_cm", 25);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 复合过滤条件查询数组
        /// </summary>
        [HttpPost]
        public async Task<object> FindArrayElementManyOperator()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Gt("dim_cm", 15), builder.Lt("dim_cm", 20));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }


        /// <summary>
        /// 查询数组 - 数组中至少包含一个元素满足所有条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayElemMatch()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.ElemMatch<BsonValue>("dim_cm", new BsonDocument { { "$gt", 22 }, { "$lt", 30 } });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }


        /// <summary>
        /// 查询数组 - 通过数组索引位置查询元素
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayElementByIndex()
        {
            var filter = Builders<BsonDocument>.Filter.Gt("dim_cm.1", 25);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 通过数组长度查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayElementByLength()
        {
            var filter = Builders<BsonDocument>.Filter.Size("tags", 3);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组文档 -  匹配数组文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocmentAnyEq()
        {
            var filter =
                Builders<BsonDocument>.Filter.AnyEq("instock",
                    new[]
                    {
                        new BsonDocument {{"warehouse", "A"}, {"qty", 5}},
                        new BsonDocument {{"warehouse", "C"}, {"qty", 15}}
                    }
                );
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组文档 -  匹配数组文档 （忽略其他元素和顺序）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocmentIgnoreDocumentAndDocumentOrder()
        {
            var filter =
                Builders<BsonDocument>.Filter.All("instock",
                    new[]
                    {
                        new BsonDocument {{"warehouse", "C"}, {"qty", 15}}
                    });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 查询数组 - 查询嵌套在数组中包含文档的文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocmentSingeAnyEq()
        {
            var filter =
                Builders<BsonDocument>.Filter.AnyEq("instock", new BsonDocument { { "warehouse", "A" }, { "qty", 5 } });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 文档字段指定查询条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocmentFieldOperator()
        {
            var filter = Builders<BsonDocument>.Filter.Lte("instock.qty", 20);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 根据索引查询文档中的字段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocumentFieldOperatorByIndex()
        {
            var filter = Builders<BsonDocument>.Filter.Lte("instock.0.qty", 5);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 单个嵌套文档在嵌套字段上满足多个查询条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocumentManyFileOperator()
        {
            var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
                "instock",
                new BsonDocument
                {
                    {"qty", 5},
                    {"warehouse", "A"}
                });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 单个嵌套文档在嵌套字段上满足多个查询条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocumentManyFileOperator1()
        {
            var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
                "instock",
                new BsonDocument
                {
                    {
                        "qty", new BsonDocument
                        {
                            {"$gt", 10},
                            {"$lte", 20}
                        }
                    },
                });
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 元素组合满足标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocumentNotElemMatch()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(
                builder.Gt("instock.qty", 35),
                builder.Lt("instock.qty", 60));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 元素组合满足标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindArrayDocumentNotElemMatch1()
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(
                builder.Eq("instock.qty", 5),
                builder.Eq("instock.warehouse", "A"));
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        #endregion

        #region  Projection

        /// <summary>
        /// 返回指定的字段和_id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Projection_Include()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Include("status").Include("instock");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 排除特定字段返回其余字段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Projection_Exclude()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Exclude("status").Exclude("instock").Exclude("_id");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        /// <summary>
        /// 排除_Id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Projection_ExcludeId()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Include("status").Include("instock").Exclude("_id");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }


        /// <summary>
        /// 返回嵌套文档特定字段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> NestedDocument_Projection_Include()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Include("size.h");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }

        /// <summary>
        /// 抑制嵌套文档特定字段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> NestedDocument_Projection_Exclude()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Exclude("size.h");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }
        /// <summary>
        /// 数组中嵌套文档的投影
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<object> ArrayNestedDocument_Projection_Include()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Include("instock.qty");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }

        /// <summary>
        /// 在返回的数组中投影特定的数组元素
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> ArrayNestedDocument_Projection_Include_Slice()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Slice("instock", -1);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }


        #region 查询空字段或缺失字段

        /// <summary>
        /// 查询某个字段等于null 的文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> QueryNull()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("item", BsonNull.Value);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }

        /// <summary>
        /// 查询某个字段等于null 的文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> QueryTypeNull()
        {
            var filter = Builders<BsonDocument>.Filter.Type("item", BsonType.Null);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }


        /// <summary>
        /// 存在检查
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> QueryExists()
        {
            var filter = Builders<BsonDocument>.Filter.Exists("item", false);
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }
            return data;
        }

        #endregion





        #endregion

        #region Update
        /// <summary>
        /// 查询某个字段等于null 的文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> ReplaceOne()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("item", "paper");


            var replacement = new BsonDocument
                                                {
                                                     { "item", "paper" },
                                                     { "instock", new BsonArray
                                                     {
                                                        new BsonDocument { { "warehouse", "A" }, { "qty", 60 } },
                                                        new BsonDocument { { "warehouse", "B" }, { "qty", 40 } } }
                                                     }
                                                };
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.ReplaceOne(filter, replacement);
            var data = result.IsModifiedCountAvailable;
            return data;


        }
        #endregion

        #region  Aggergation

        [HttpPost]
        public async Task<bool> Aggergation()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("item", "paper");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = new BsonDocument[]
            {
             new BsonDocument { { "$match", new BsonDocument("x", 1) } },
             new BsonDocument { { "$sort", new BsonDocument("y", 1) } }
           };

            var result = collection.Find(filter).ToCursor();

            while (result.MoveNext())
            {

            }

            collection.Aggregate(pipeline);
            return false;
        }
        #endregion

    }
}