using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.IO;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            this._configuration = configuration;
            this._env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Connection to MongoDB via _configuration String...
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            // Getting Collection 'testdb.Employee' and change compile time type to 'IQueryable'...
            var dblist = dbClient.GetDatabase("testdb").GetCollection<Employee>("Employee").AsQueryable();

            return new JsonResult(dblist);
        }
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            // Connection to MongoDB via _configuration String...
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            // Getting Collection 'testdb.Employee' and change compile time type to 'IQueryable'...
            int LastEmployeeId = dbClient.GetDatabase("testdb").GetCollection<Employee>("Employee").AsQueryable().Count();
            emp.EmployeeId = LastEmployeeId + 1;

            dbClient.GetDatabase("testdb").GetCollection<Employee>("Employee").InsertOne(emp);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            // Connection to MongoDB via _configuration String...
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            // Filtering via EmployeeId
            var filter = Builders<Employee>.Filter.Eq("EmployeeId", emp.EmployeeId);

            // Creating variable to include the updated EmployeeName, Department, DOJ, and PFN by the user's input...
            System.Diagnostics.Debug.WriteLine(emp.Department);
            var update = Builders<Employee>.Update.Set("EmployeeName", emp.EmployeeName)
                .Set("Department", emp.Department)
                .Set("DateOfJoining", emp.DateOfJoining)
                .Set("PhotoFileName", emp.PhotoFileName);

            // Getting Collection 'testdb.Employee' and updating an element...
            dbClient.GetDatabase("testdb").GetCollection<Employee>("Employee").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            // Connection to MongoDB via _configuration String...
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            // Filtering via EmployeeId
            var filter = Builders<Employee>.Filter.Eq("EmployeeId", id);

            // Getting Collection 'testdb.Employee' and updating an element...
            dbClient.GetDatabase("testdb").GetCollection<Employee>("Employee").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (System.Exception)
            {

                return new JsonResult("Anonymous.png");
            }
        }
    }
}
