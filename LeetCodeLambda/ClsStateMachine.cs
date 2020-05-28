using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using LeetCodeLambda.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace LeetCodeLambda
{
    public class ClsStateMachine
    {

        public ClsStateMachine()
        {

        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse GetData(APIGatewayProxyRequest request, ILambdaContext context)
        {
            try
            {
                Console.WriteLine($"Lambda Function to check instance State is Started {DateTime.Now}");
                context.Logger.LogLine("Get Request\n");
                var inputRequest = JsonConvert.SerializeObject(request);
                Console.WriteLine($"Context  :- {JsonConvert.SerializeObject(context)}");
                dynamic body = JsonConvert.DeserializeObject(request.Body);

                ReadAwsS3Data readAwsS3 = new ReadAwsS3Data();
                var response = readAwsS3.GetResponseFromS3(body["bucketName"].ToString(),body["path"].ToString());

                Console.WriteLine($"Lambda Function to check instance State is Started at {DateTime.Now}");

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = "Hello AWS Serverless",
                    Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured :- {ex.ToString()}");
                throw;
            }
        }

    }
}
