using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Services
{
    public class ClsConcreteFactory : ClsFactory
    {
        public override IRekognition GetProduct(string pName)
        {
            switch (pName.ToLower())
            {
                case "celebrity":
                    return new ClsCelebrityRekognition(AWSConstants._vAccessKey, AWSConstants._vSecretKey);
                case "image":
                    return new ClsFaceRecognition(AWSConstants._vAccessKey,AWSConstants._vSecretKey);
                default:
                    break;
            }
            return null;
        }
    }
}
