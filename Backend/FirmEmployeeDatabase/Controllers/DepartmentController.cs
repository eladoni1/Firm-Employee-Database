using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            var dblist = dbClient.GetDatabase("testdb").GetCollection<Department>("Department").AsQueryable();

            return new JsonResult(dblist);
        }
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            int LastDepartmentId = dbClient.GetDatabase("testdb").GetCollection<Department>("Department").AsQueryable().Count();
            dep.DepartmentId = LastDepartmentId + 1;

            dbClient.GetDatabase("testdb").GetCollection<Department>("Department").InsertOne(dep);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            var filter = Builders<Department>.Filter.Eq("DepartmentId", dep.DepartmentId);
            var update = Builders<Department>.Update.Set("DepartmentName", dep.DepartmentName);

            dbClient.GetDatabase("testdb").GetCollection<Department>("Department").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            var filter = Builders<Department>.Filter.Eq("DepartmentId", id);

            dbClient.GetDatabase("testdb").GetCollection<Department>("Department").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
