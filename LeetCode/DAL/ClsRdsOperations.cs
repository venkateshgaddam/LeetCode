using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;
using LeetCode.Models;
using LeetCode.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeetCode.DAL
{
    public class ClsRdsOperations : IRdsOperations
    {
        static readonly string AccessKey = AWSConstants._vAccessKey;
        static readonly string SecretKey = AWSConstants._vSecretKey;
        static readonly AWSCredentials credentials = new BasicAWSCredentials(AccessKey, SecretKey);

        public AmazonRDSClient _rdsClient { get; set; }

        public ClsRdsOperations()
        {
            _rdsClient = new AmazonRDSClient(credentials, RegionEndpoint.USEast1);
        }

        public Response GetDecodings(string inputString)
        {
            Response response = new Response();

            try
            {
                int integerInput = Convert.ToInt32(inputString);
                LeetCodeDecoder codeDecoder = new LeetCodeDecoder();

                if (integerInput <= 0)
                {
                    codeDecoder.No_of_ways = 0;
                    response.message = "0";
                    response.data = null;
                }
                else
                {
                    int count = 1;
                    int n = inputString.Length;
                    if (inputString.Contains("0"))
                    {
                        count = 0;
                    }
                    else
                    {
                        for (int i = 0; i < n - 1; i++)
                        {
                            int first = Convert.ToInt32(inputString.Substring(i, 2));
                            int second = Convert.ToInt32(inputString.Substring(i, 2));

                            if (second >= 10 && second <= 26)
                            {
                                count++;
                            }
                        }
                    }
                    codeDecoder.No_of_ways = count;
                    codeDecoder.Combinations.Add("( One of the Way is :- " + inputString + ")");
                    response.message = codeDecoder.No_of_ways.ToString();
                    response.data = JsonConvert.SerializeObject(codeDecoder);
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.ToString();
                return response;
            }
        }
    }
}
