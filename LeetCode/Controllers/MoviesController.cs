using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.DAL;
using LeetCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private clsDynamoDB clsDBOperations = new clsDynamoDB();
        // GET: api/Movies
        [HttpGet]
        [Route("GetMovies")]
        public async Task<JsonResult> GetAsync()
        {
            var strngARRAY = new List<DataRow>();
            strngARRAY = await clsDBOperations.GetMoviesAsync();

            return new JsonResult(strngARRAY);
        }

        // GET: api/Movies/5
        [HttpGet("{movieName}", Name = "GetDetails")]
        [Route("GetDetails")]
        public async Task<JsonResult> Get(string movieName)
        {
            var strngARRAY = new List<DataRow>();
            strngARRAY = await clsDBOperations.GetMoviesAsync(movieName);

            return new JsonResult(strngARRAY);
        }

        [HttpGet]
        [Route("")]

        // POST: api/Movies
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        // PUT: api/Movies/5
        [HttpPost("{movieName}")]
        public async Task Edit(string movieName, [FromBody] Movies test)
        {
            var Result = await clsDBOperations.GetMoviesAsync(movieName);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{movieName}")]
        public async Task<string> Delete(string movieName)
        {
            string successMessage = "";
            await clsDBOperations.DeleteItem(movieName, successMessage);
            return successMessage;
        }



        [HttpGet(Name = "GetActors")]
        [Route("GetActors")]
        public JsonResult GetActorsData()
        {

            var strngARRAY = new DataTable();
            strngARRAY = clsDBOperations.GetActorsDataAsync().Result;

            return new JsonResult(strngARRAY);
        }

        [HttpGet(Name = "PutData")]
        [Route("PutData")]
        public async Task<JsonResult> PutData()
        {

            var strngARRAY = clsDBOperations.GetScanResponse();

            string CryptoData = clsCrypto.test(strngARRAY);

            return new JsonResult(strngARRAY);
        }


        [HttpGet(Name = "DescribeSnapShots")]
        [Route("DescribeSnapShots")]
        public async Task<JsonResult> DescribeSnapShots()
        {

            var strngARRAY = await clsDBOperations.GetSnapShotDetails();

            //string CryptoData = clsCrypto.test(strngARRAY);

            return new JsonResult(strngARRAY);
        }
    }
}
