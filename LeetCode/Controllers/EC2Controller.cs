using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeetCode.DAL;
using Newtonsoft.Json;
using LeetCode.Common;
using LeetCode.Models;

namespace LeetCode.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EC2Controller : ControllerBase
    {
        public ICreateEC2 _iCreateEC2 { get; set; }

        public EC2Controller(ICreateEC2 createEC2)
        {
            _iCreateEC2 = createEC2;
        }
        // GET: api/EC2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EC2/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EC2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpGet]
        [Route("Create")]
        public string Create()
        {


            return _iCreateEC2.RestoreDBFromSnapShotAsync().Result;
        }

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            throw new System.Exception("Error in the Page");

            return _iCreateEC2.RestoreDBFromSnapShotAsync().Result;
        }


        [HttpGet]
        [Route("CreateEC2")]
        public string CreateEC2Async()
        {
            return _iCreateEC2.CreateEC2InstanceAsync().Result;
        }

        // PUT: api/EC2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("LeetCode")]
        public Response CreateClusterParameterGroup([FromBody] string inputValue)
        {
            ClsRdsOperations rdsOperations = new ClsRdsOperations();
            Response httpResponse = new Response();

            if (string.IsNullOrEmpty(inputValue))
            {
                httpResponse.message = inputValue + "is not a valid input.Please try again";
            }
            else
            {
                httpResponse = rdsOperations.GetDecodings(inputValue);
            }

            return httpResponse;
        }

    }
}
