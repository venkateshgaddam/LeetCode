using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Models;
using LeetCode.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RekognitionController : ControllerBase
    {
        // GET: api/Rekognition
        [HttpGet]
        [Route("RGet")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rekognition/5
        [HttpGet("RGet/{id}", Name = "RGet")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rekognition
        [HttpPost]
        public async Task<IActionResult> Rekognition(IFormFile UploadFile)
        {
            try
            {
                var request = UploadFile;
                var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      UploadFile.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await UploadFile.CopyToAsync(fileStream);
                }
                byte[] array = System.IO.File.ReadAllBytes(path);

                ClsFactory clsFactory = new ClsConcreteFactory();

                IRekognition product = clsFactory.GetProduct("facerecognition");

                //var res = product.GetData("", array);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            return RedirectToAction("FactoryPattern");
        }




        [HttpPost]
        [Route("GetCelebrity")]
        public string GetCelebrityData([FromBody]ImageData imageData)
        {
            Console.WriteLine("Entered into the Method");
            ClsFactory clsFactory = new ClsConcreteFactory();

            IRekognition rekognition = clsFactory.GetProduct(imageData.RekognitionType);

            return rekognition.GetImageInfo(imageData);

        }


    }
}
