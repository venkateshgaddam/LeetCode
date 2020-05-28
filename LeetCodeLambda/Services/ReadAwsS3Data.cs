using LeetCodeLambda.Common;
using System;
using Amazon;

using System.Collections.Generic;
using System.Text;
using Amazon.S3;
using Amazon.Runtime;
using Amazon.S3.Model;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace LeetCodeLambda.Services
{
    public class ReadAwsS3Data
    {
        private string _accessKey { get; set; }
        private string _secretKey { get; set; }

        private AmazonS3Client _amazonS3Client { get; set; }

        private BasicAWSCredentials aWSCredentials { get; set; }

        public ReadAwsS3Data()
        {
            _accessKey = "AKIAVDDJYSUOQ6HQNI7I";//Environment.GetEnvironmentVariable("accessKey");
            _secretKey = "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";//Environment.GetEnvironmentVariable("secretKey");
            aWSCredentials = new BasicAWSCredentials(_accessKey, _secretKey);
            _amazonS3Client = new AmazonS3Client(aWSCredentials, RegionEndpoint.USEast1);
        }


        public async Task<Response> GetResponseFromS3(string BucketName, string path)
        {

            try
            {
                Console.WriteLine($"{_accessKey}");
                Console.WriteLine($"{_accessKey}");
                if (string.IsNullOrEmpty(path))
                {
                    return new Response() { statusCode = System.Net.HttpStatusCode.Ambiguous, data = null, message = "No Data Present" };
                }
                else
                {
                    GetObjectRequest getObject = new GetObjectRequest()
                    {
                        BucketName = BucketName,
                        Key = path
                    };
                    var copyData = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      path);
                    GetObjectResponse s3Data = _amazonS3Client.GetObjectAsync(getObject).Result;
                    var tokenSource2 = new CancellationTokenSource();
                    CancellationToken ct = tokenSource2.Token;

                    await s3Data.WriteResponseStreamToFileAsync(copyData, true, ct);
                    string responseBody = "";
                    using (StreamReader reader = new StreamReader(s3Data.ResponseStream))
                    {
                        responseBody = reader.ReadToEnd(); // Now you process the response body.
                    }

                    Console.WriteLine(responseBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured :- {ex.ToString()}");
                throw;
            }

            return null;

        }

        public System.Data.DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            System.Data.DataTable dtexcel = new System.Data.DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007
            OLEDBConnection con = new OLEDBConnection(conn);
            using ()
            {
                try
                {
                    System.Data.OleDb.OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }
    }
}
