﻿using ExpenseTrackerWeb.Helpers;
using ExpenseTrackerWeb.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpenseTrackerWeb.Controllers.RestApi
{

    public class CategoryApiController : ApiController
    {
        // GET api/CategoryApi
        public async Task<IEnumerable<string>> GetAsync()
        {

            MongoHelper<Category> categoryHelper = new MongoHelper<Category>();
                
            IList<string> returnList = new List<string>();
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            await categoryHelper.Collection.Find(e => e.Name != null)
                .ForEachAsync(expenseDocument => 
                {
                    string docJson = expenseDocument.ToJson(jsonWriterSettings);
                    returnList.Add(docJson);
                }
            );

            return returnList.ToArray();
        }

        // GET api/ExpenseApi/5
        public string Get(int id)
        {
            // TODO get one
            return "value";
        }

        // POST api/ExpenseApi
        public async Task PostAsync(Category categoryPosted)
        {
            MongoHelper<Category> categoryHelper = new MongoHelper<Category>();

            Category category = new Category();
            category.Name = categoryPosted.Name;

            await categoryHelper.Collection.InsertOneAsync(category);
        }

        // PUT api/ExpenseApi/5
        public void Put(int id, [FromBody]string value)
        {            
            // TODO update
        }

        // DELETE api/ExpenseApi/5
        public void Delete(int id)
        {
            // TODO delete
        }
    }
}
