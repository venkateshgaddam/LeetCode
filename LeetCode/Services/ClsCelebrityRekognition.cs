using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using LeetCode.Models;

namespace LeetCode.Services
{
    public class ClsCelebrityRekognition : IRekognition
    {
        public MemoryStream _imageData { get; set; }
        public AmazonRekognitionClient _rekognitionClient { get; set; }
        public ClsCelebrityRekognition(string accessKey, string secretKey)
        {
            BasicAWSCredentials aWSCredentials = new BasicAWSCredentials(accessKey, secretKey);
            _rekognitionClient = new AmazonRekognitionClient(aWSCredentials, RegionEndpoint.USEast1);
        }
       
        public string GetImageInfo(ImageData imageData, byte[] imgData = null)
        {
            try
            {
                var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      imageData.fileName);
                imgData = Convert.FromBase64String(imageData.base64Data);
                _imageData = new MemoryStream(imgData);
                RecognizeCelebritiesRequest recognizeCelebrities = new RecognizeCelebritiesRequest()
                {
                    Image = new Image() { Bytes = _imageData }
                };
                RecognizeCelebritiesResponse celebrity = _rekognitionClient.RecognizeCelebritiesAsync(recognizeCelebrities).Result;

                List<Celebrity> lstCelebrities = celebrity.CelebrityFaces;

                StringBuilder sbCelebrities = new StringBuilder();
                foreach (var item in lstCelebrities)
                {
                    sbCelebrities.Append(item.Name);
                    sbCelebrities.Append(',');
                }
                string Celebrities = sbCelebrities.ToString().TrimEnd(',');

                return Celebrities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
    }
}
