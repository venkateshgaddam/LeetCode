using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using LeetCode.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.DAL
{
    public class clsDynamoDB : IDisposable
    {
        static string AccessKey = AWSConstants._vAccessKey;
        static string SecretKey = AWSConstants._vSecretKey;//Account-vgaddam User-IAMVenkat
        static string successMessage = string.Empty;
        static int marks = 0;
        static string testString = "WNCYnTYPCEHb0gmjXA/1VQ==";
        static string hex = ConvertStringToHex(testString, System.Text.Encoding.Unicode);
        string normal = ConvertHexToString(hex, System.Text.Encoding.Unicode);
        static readonly AWSCredentials credentials = new BasicAWSCredentials(AccessKey, SecretKey);
        AmazonDynamoDBClient client;

        public clsDynamoDB()
        {
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
        }

        List<Document> doc = new List<Document>();
        List<Dictionary<string, string>> resultSet = new List<Dictionary<string, string>>();
        public delegate void dTable();
        public delegate int MultiCast(int x, int y);

        public async Task<LoginModel> GetTable()
        {
            Table table;
            try
            {
                table = Table.LoadTable(client, "UserTable");

                //Get Items from DynamoDB
                ScanFilter scanFilter = new ScanFilter();
                scanFilter.AddCondition("Name", ScanOperator.Contains, "Dhoni");
                Search search = table.Scan(scanFilter);

                while (!search.IsDone)
                {
                    doc = await search.GetNextSetAsync();
                }
                string result = "";
                LoginModel loginModel = new LoginModel();

                if (doc.Count > 0)
                {
                    // return true;
                    for (int i = 0; i < doc.Count; i++)
                    {
                        loginModel.Userid = 10;
                        loginModel.UserName = "Dhoni";
                        result = doc[i].ToJson();
                        var arr = doc[i].ToList();
                        //var dc = arr.ToDictionary(arr[0].Key,arr[0].Value);
                        var dicValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                        resultSet.Add(dicValues);
                    }
                }
                return loginModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<DataRow>> GetMoviesAsync(string moviename = "")
        {

            try
            {
               // Table tblMovie = Table.LoadTable(client, "Movies");

                var request = new ScanRequest
                {
                    TableName = "Movies",

                };
                if (moviename != "")
                {
                    //Search searchMovie = tblMovie.Scan(new ScanFilter());

                    //ScanFilter scanFilter = new ScanFilter();
                    //scanFilter.AddCondition("MovieName", ScanOperator.Equal, moviename);
                    request.ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":val", new AttributeValue {
                         S = moviename
                     }} };
                    request.FilterExpression = "MovieName = :val";

                }

                ScanResponse Result = await client.ScanAsync(request);


                DataTable actors = new DataTable();
                List<Movie> lstMovies = new List<Movie>();
                //actors = await GetActors();


                DataTable datMovies = new DataTable("Movies");
                datMovies.Columns.Add("Movie_Id", typeof(string));
                datMovies.Columns.Add("MovieName", typeof(string));
                datMovies.Columns.Add("Producer", typeof(string));
                datMovies.Columns.Add("DateOfRelease", typeof(string));
                datMovies.Columns.Add("Actors", typeof(List<Actors>));

                for (int i = 0; i < Result.Items.Count; i++)
                {
                    DataRow dr = datMovies.NewRow();
                    dr["Movie_Id"] = 10;
                    dr["MovieName"] = Convert.ToString(Result.Items[i]["MovieName"].S);
                    dr["Producer"] = Convert.ToString(Result.Items[i]["Producer"].S);
                    dr["DateOfRelease"] = Convert.ToString(Result.Items[i]["DateOfRelease"].S);

                    dr["Actors"] = GetMovieActors(Result.Items[i]["MovieName"].S.ToString()).Result;

                    datMovies.Rows.Add(dr);
                }

                List<DataRow> list = datMovies.Select().ToList();
                var Results = JsonConvert.SerializeObject(list);


                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<Actors>> GetMovieActors(string movieName)
        {
            DataTable actors = new DataTable();
            actors = await GetActors();

            List<Actors> lstActors = new List<Actors>();
            try
            {
                for (int i = 0; i < actors.Rows.Count; i++)
                {
                    DataRow dataRow = actors.Rows[i];
                    if (dataRow["MovieName"].ToString() == movieName)
                    {
                        Actors actor = new Actors
                        {
                            ActorName = dataRow["ActorName"].ToString(),
                            Age = Convert.ToInt32(dataRow["Age"].ToString()),
                            MovieName = movieName
                        };
                        lstActors.Add(actor);
                    }
                }

                return lstActors;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<DataTable> GetActors()
        {

            try
            {
                //Table tblActor = Table.LoadTable(client, "Actors");

                ScanRequest request = new ScanRequest
                {
                    TableName = "Actors"
                    //ExclusiveStartKey = startKey,
                    //ScanFilter = conditions
                };

                // Issue request
                //CancellationToken cancellationToken = new CancellationToken();
                ScanResponse response = await client.ScanAsync(request);

                var Result = client.ScanAsync(request).Result;
                DataTable dtActors = new DataTable("Actors");
                dtActors.Columns.Add("Movie_Id", typeof(int));
                dtActors.Columns.Add("ActorName", typeof(String));
                dtActors.Columns.Add("MovieName", typeof(String));
                dtActors.Columns.Add("Age", typeof(String));


                for (int i = 0; i < Result.Items.Count; i++)
                {
                    DataRow dr = dtActors.NewRow();
                    dr["Movie_Id"] = 10;
                    dr["MovieName"] = Result.Items[i]["MovieName"].S != null ? Convert.ToString(Result.Items[i]["MovieName"].S) : "";
                    dr["ActorName"] = Convert.ToString(Result.Items[i]["Actor_Name"].S);
                    dr["Age"] = Convert.ToString(Result.Items[i]["Age"].S);

                    dtActors.Rows.Add(dr);
                }

                List<DataRow> list = dtActors.Select().ToList();
                var Results = JsonConvert.SerializeObject(list);

                return dtActors;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddUser()
        {
            PutItemResponse obj = PutItemAsync().Result;
            return successMessage = obj.HttpStatusCode == System.Net.HttpStatusCode.OK ? "Success" : "Error";
        }

        public async Task<PutItemResponse> PutItemAsync()
        {
            try
            {
                StringBuilder sb = new StringBuilder("", 50);
                sb.Append("MS Dhni");
                var request = new PutItemRequest
                {
                    TableName = "UserTable",
                    Item = new Dictionary<string, AttributeValue>()
                          {
                              { "UID", new AttributeValue { S = "MS" }},
                              { "Branch", new AttributeValue { S = "CE" }},
                              { "Marks", new AttributeValue { N=marks.ToString() }},
                              //{ "Name", new AttributeValue { S = sb.ToString() }},

                          }
                    //  ,
                    //ExpressionAttributeNames = new Dictionary<string, string>() { 

                    //    {"#Student","Name"}                    
                    //},
                    //ExpressionAttributeValues = new Dictionary<string,AttributeValue>(){

                    //    {":studentname",new AttributeValue{S="Dhoni"}}
                    //},
                    //ConditionExpression = "Name = Dhoni"
                };
                return await client.PutItemAsync(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateItem(int id)
        {
            //Update Items
            UpdateItemResponse updateClient = null;

            if (resultSet.Count > 0)
            {
                for (int i = 0; i < resultSet.Count; i++)
                {
                    string attributeValue = "";

                    attributeValue = doc[i]["Id"].AsString();
                    UpdateItemRequest updateRequest = new UpdateItemRequest()
                    {
                        TableName = "Student",
                        Key = new Dictionary<string, AttributeValue> {
                            { "Id",  new AttributeValue { N = attributeValue}}
                        },
                        ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                        {
                           { ":r", new AttributeValue {
                                 N = "10"
                            } },
                            { ":n", new AttributeValue {
                                 N = "1"
                            } }
                        },
                        ConditionExpression = "Marks >= :n",
                        UpdateExpression = "SET Marks = :r",
                        ReturnValues = "UPDATED_NEW"

                    };

                    updateClient = client.UpdateItemAsync(updateRequest).Result;
                }
            }
            successMessage = updateClient.HttpStatusCode == System.Net.HttpStatusCode.OK ? "Item Updated " : "Error Occured While Updating";

        }

        public async Task<string> DeleteItem(string movieName, string successMessage)
        {

            //Delete Item
            DeleteItemRequest deleteReq = new DeleteItemRequest()
            {
                TableName = "Movies",
                Key = new Dictionary<string, AttributeValue>() { { "MovieName", new AttributeValue { S = movieName } } }
            };
            DeleteItemResponse deleteResponse = new DeleteItemResponse();
            deleteResponse = await client.DeleteItemAsync(deleteReq);
            successMessage = deleteResponse.HttpStatusCode == System.Net.HttpStatusCode.OK ? "Item Deleted " : "Error Occured While Delete";
            return successMessage;

        }

        public async Task<DataTable> GetActorsDataAsync()
        {
            try
            {
                Table tblActor = Table.LoadTable(client, "Actors");

                ScanRequest request = new ScanRequest
                {
                    TableName = "Actors"
                    //ExclusiveStartKey = startKey,
                    //ScanFilter = conditions
                };

                // Issue request
                //CancellationToken cancellationToken = new CancellationToken();
                ScanResponse response =await client.ScanAsync(request);

                var Result = client.ScanAsync(request).Result;
                DataTable dtActors = new DataTable("Actors");
                dtActors.Columns.Add("Movie_Id", typeof(int));
                dtActors.Columns.Add("ActorName", typeof(String));
                dtActors.Columns.Add("MovieName", typeof(String));
                dtActors.Columns.Add("Age", typeof(String));

                for (int i = 0; i < Result.Items.Count; i++)
                {
                    DataRow dr = dtActors.NewRow();
                    dr["Movie_Id"] = 10;
                    dr["MovieName"] = Result.Items[i]["MovieName"].S != null ? Convert.ToString(Result.Items[i]["MovieName"].S) : "";
                    dr["ActorName"] = Convert.ToString(Result.Items[i]["Actor_Name"].S);
                    dr["Age"] = Convert.ToString(Result.Items[i]["Age"].N);

                    dtActors.Rows.Add(dr);
                }

                List<DataRow> list = dtActors.Select().ToList();
                var Results = JsonConvert.SerializeObject(list);

                return dtActors;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string ConvertStringToHex(string input, Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public ScanResponse GetScanResponse()
        {
            try
            {

                ScanRequest request = new ScanRequest
                {
                    TableName = "ae_dbaas_dv2_service_request",
                    //ExclusiveStartKey = startKey,
                    //ScanFilter =  scanFilter
                };

                //var rrr = JsonConvert.DeserializeObject(null);
                //Condition condition = new Condition();
                //condition.
                request.ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":val", new AttributeValue {
                         N = "1294"
                     }} };
                request.FilterExpression = "service_request_id = :val";
                // Issue request
                //CancellationToken cancellationToken = new CancellationToken();
                //ScanResponse response = client.Scan(request);

                ScanResponse Result = client.ScanAsync(request).Result;

                return Result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Task<DescribeDBSnapshotsResponse> GetSnapShotDetails()
        {

            try
            {

                AccessKey = "\\/wYzht3DL7Bgo/eiD51i3cb3uIjKNCdb8y7BIYLxZH26csz3YvG8kKnrODBxwli";
                SecretKey = "ngh6C2nLe/9Es0HM4Qck0XGTvusdsXKGZuEx8JV+yy7DNm9978UbTY1OZS1oZg6N9R+wTM3VtVWMEqGzN4JYqDoyhrpJqEr3JlQCImODZl8GCLEhpRDY1Q==";


                AmazonS3Client amazonS3Client = new AmazonS3Client(SecretKey, AccessKey, RegionEndpoint.USEast1);

                ListBucketsRequest listbucketrequest = new ListBucketsRequest();               

                var response = amazonS3Client.ListBucketsAsync(listbucketrequest);

                AmazonRDSClient client = new AmazonRDSClient(SecretKey, AccessKey, RegionEndpoint.USEast1);


                DescribeDBSnapshotsRequest dBSnapshotsRequest = new DescribeDBSnapshotsRequest();
                dBSnapshotsRequest.SnapshotType = "manual";

                var snapshots = client.DescribeDBSnapshotsAsync(dBSnapshotsRequest);

                DescribeDBSnapshotsResponse describeDBSnapshotsResponse = snapshots.Result;

                return snapshots;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable ServiceRequest()
        {
            try
            {
                //master_service_request
                //Table tblActor = Table.LoadTable(client, "ae_dbaas_dv2_service_request");
                //ScanFilter scanFilter = new ScanFilter();
                //scanFilter.AddCondition("service_request_id", ScanOperator.Equal, 1219);


                //ScanRequest request = new ScanRequest
                //{
                //    TableName = "master_service_request",
                //    //ExclusiveStartKey = startKey,
                //    //ScanFilter =  scanFilter
                //};
                ////Condition condition = new Condition();
                ////condition.
                //request.ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                //    {":val", new AttributeValue {
                //         N = "1274"
                //     }} };
                //request.FilterExpression = "service_request_id = :val";
                //// Issue request
                ////CancellationToken cancellationToken = new CancellationToken();
                //ScanResponse response = client.Scan(request);

                //var Result = client.ScanAsync(request).Result;





                #region Test

                ScanRequest request = new ScanRequest
                {
                    TableName = "ae_dbaas_dv2_service_request",
                    //ExclusiveStartKey = startKey,
                    //ScanFilter =  scanFilter
                };
                //Condition condition = new Condition();
                //condition.
                request.ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":val", new AttributeValue {
                         N = "1274"
                     }} };
                request.FilterExpression = "service_request_id = :val";
                // Issue request
                //CancellationToken cancellationToken = new CancellationToken();
                //ScanResponse response = client.Scan(request);

                ScanResponse Result = client.ScanAsync(request).Result;
                #endregion

                DataTable dtActors = new DataTable("Actors");
                dtActors.Columns.Add("Movie_Id", typeof(int));
                dtActors.Columns.Add("ActorName", typeof(String));
                dtActors.Columns.Add("MovieName", typeof(String));
                dtActors.Columns.Add("Age", typeof(String));

                //for (int i = 0; i < Result.Items.Count; i++)
                //{
                //    DataRow dr = dtActors.NewRow();
                //    dr["Movie_Id"] = 10;
                //    dr["MovieName"] = Result.Items[i]["MovieName"].S != null ? Convert.ToString(Result.Items[i]["MovieName"].S) : "";
                //    dr["ActorName"] = Convert.ToString(Result.Items[i]["ActorName"].S);
                //    dr["Age"] = Convert.ToString(Result.Items[i]["Age"].N);

                //    dtActors.Rows.Add(dr);
                //}

                // List<DataRow> list = dtActors.Select().ToList();
                //var Results = JsonConvert.SerializeObject(list);

                return dtActors;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
