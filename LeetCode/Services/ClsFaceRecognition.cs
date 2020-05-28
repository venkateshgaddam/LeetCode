using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Services
{
    public class ClsFaceRecognition : IRekognition
    {
        public MemoryStream _imageData { get; set; }
        public AmazonRekognitionClient _rekognitionClient { get; set; }
        public ClsFaceRecognition(string accessKey, string secretKey)
        {
            BasicAWSCredentials aWSCredentials = new BasicAWSCredentials(accessKey, secretKey);
            _rekognitionClient = new AmazonRekognitionClient(aWSCredentials, RegionEndpoint.USEast1);
        }
       
        public string GetCelebrityInfo(ImageData imageData, byte[] imgData = null)
        {
            throw new NotImplementedException();
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
                DetectFacesRequest detectFaces = new DetectFacesRequest() { Image = new Image() { Bytes = _imageData } };

                DetectFacesResponse facesResponse = _rekognitionClient.DetectFacesAsync(detectFaces).Result;

                List<FaceDetail> lstCelebrities = facesResponse.FaceDetails;

                FaceDetail faceDetail = new FaceDetail();

                StringBuilder sbCelebrities = new StringBuilder();
                //foreach (var item in lstCelebrities)
                //{
                //    switch (switch_on)
                //    {
                //        default:
                //    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                //}                                                                                
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
