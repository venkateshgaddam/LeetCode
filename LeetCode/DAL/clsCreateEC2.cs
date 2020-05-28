using System;
using Amazon.EC2;
using Amazon.EC2.Model;
using System.Collections.Generic;
using System.Linq;
using Amazon.RDS;
using System.Threading.Tasks;
using Amazon.RDS.Model;
using Amazon.Runtime;
using Amazon;
using System.IO;
using LeetCode.Models;
using LeetCode.Common;

namespace LeetCode.DAL
{
    public class clsCreateEC2 : IDisposable,ICreateEC2
    {
        static string AccessKey = AWSConstants._vAccessKey;
        static string SecretKey = AWSConstants._vSecretKey;
        static readonly AWSCredentials credentials = new BasicAWSCredentials(AccessKey, SecretKey);
        AmazonRDSClient amazonRDSClient = new AmazonRDSClient(credentials, RegionEndpoint.USEast1);
        AmazonEC2Client amazonEC2Client = new AmazonEC2Client(credentials, RegionEndpoint.USEast1);

        public string CreateInstance()
        {
            return "Success";
        }

        public async Task<string> CreateSnapShotAsync()
        {
            try
            {
                if (IsDBExistis())
                {

                    CreateDBSnapshotRequest createDBSnapshotRequest = new CreateDBSnapshotRequest();
                    createDBSnapshotRequest.DBSnapshotIdentifier = "snapjaguar-rds";//"rds:jaguar-2019-05-11-11-17";
                    createDBSnapshotRequest.DBInstanceIdentifier = "jaguar";
                    //var response = amazonRDSClient.CreateDBSnapshot(createDBSnapshotRequest);

                    ModifyDBSnapshotAttributeRequest modifyDBSnapshotAttributeRequest = new ModifyDBSnapshotAttributeRequest();
                    modifyDBSnapshotAttributeRequest.DBSnapshotIdentifier = "rds-jaguar";
                    modifyDBSnapshotAttributeRequest.AttributeName = "Restore";
                    List<string> awsAccounts = new List<string>();
                    awsAccounts.Add("739981354746");
                    modifyDBSnapshotAttributeRequest.ValuesToAdd = awsAccounts;

                    var shareResponse = await amazonRDSClient.ModifyDBSnapshotAttributeAsync(modifyDBSnapshotAttributeRequest);

                    CopyDBSnapshotRequest dBSnapshotRequest = new CopyDBSnapshotRequest();
                    dBSnapshotRequest.SourceDBSnapshotIdentifier = "rds:jaguar-2019-05-12-03-09";
                    dBSnapshotRequest.TargetDBSnapshotIdentifier = "rds-jaguar";

                    //var response2 =await amazonRDSClient.CopyDBSnapshotAsync(dBSnapshotRequest);

                    if (shareResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "Success";
                    }
                    return "Failed";
                }

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> RestoreDBFromSnapShotAsync()
        {
            try
            {
                DescribeDBSnapshotsRequest dBSnapshotsRequest = new DescribeDBSnapshotsRequest();
                dBSnapshotsRequest.DBSnapshotIdentifier = "rds-jaguar";
                var response = await amazonRDSClient.DescribeDBSnapshotsAsync(dBSnapshotsRequest);
                RestoreDBInstanceFromDBSnapshotRequest restoreDBInstance = new RestoreDBInstanceFromDBSnapshotRequest();
                restoreDBInstance.DBSnapshotIdentifier = "rds-jaguar";
                restoreDBInstance.AutoMinorVersionUpgrade = false;
                restoreDBInstance.CopyTagsToSnapshot = true;
                restoreDBInstance.DBInstanceIdentifier = response.DBSnapshots[0].DBInstanceIdentifier;
                //restoreDBInstance.DBName=""

                //var final = await amazonRDSClient.RestoreDBInstanceFromDBSnapshotAsync(restoreDBInstance);

                return "String";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool IsDBExistis()
        {
            DescribeDBInstancesRequest describeDBInstances = new DescribeDBInstancesRequest();
            describeDBInstances.DBInstanceIdentifier = "jaguar";
            var resp = amazonRDSClient.DescribeDBInstancesAsync(describeDBInstances).Result;

            if (resp.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            return false;
        }

        //[Obsolete]
        public async Task<string> CreateEC2InstanceAsync(int serverType = 0)
        {
            string secGroupName = "myec2";
            string instanceID = "";

            if (serverType == (int)AWSConstants.server_types.EC2)
            {

                    //Step 1:- check for the security Groups
                    var isSGExists = await IsSecurityGroupsExistsAsync(secGroupName);

                    //Step 2:- Create Security Groups
                    if (!isSGExists)
                    {
                        SecurityGroup securityGroup = CreateSecurityGroupAsync(secGroupName).Result;
                        string ipRange = "0.0.0.0/0";
                        List<string> ranges = new List<string>
                    {
                        ipRange
                    };

                    //Step 3:- Attach the IP Permissions
                    IpPermission ipPermission = new IpPermission()
                    {
                        IpProtocol = "All traffic",
                        FromPort = 0,
                        ToPort = 65535,
                        IpRanges = ranges
                    };
                    var ingressRequest = new AuthorizeSecurityGroupIngressRequest();
                    ingressRequest.GroupId = securityGroup.GroupId;
                    ingressRequest.IpPermissions.Add(ipPermission);

                    var ingressResponse = amazonEC2Client.AuthorizeSecurityGroupIngressAsync(ingressRequest);

                    //Step 4:- Create Key Pairs (.pem file)
                    string keyPairName = CreateKeyPair();

                    //Step 5:- Create Launch Request Object
                    string amiID = "ami-0b6158cfa2ae7b493";
                    
                    List<string> groups = new List<string>() { securityGroup.GroupId };
                    var launchRequest = new RunInstancesRequest()
                    {
                        ImageId = amiID,
                        InstanceType = "t2.micro",
                        MinCount = 1,
                        MaxCount = 1,
                        KeyName = keyPairName,
                        SecurityGroupIds = groups
                    };

                    var launchResponse = await amazonEC2Client.RunInstancesAsync(launchRequest);
                    var instances = launchResponse.Reservation.Instances;
                    var instanceIds = new List<string>();
                    foreach (Instance item in instances)
                    {
                        instanceIds.Add(item.InstanceId);
                        Console.WriteLine();
                        Console.WriteLine("New instance: " + item.InstanceId);
                        Console.WriteLine("Instance state: " + item.State.Name);
                    }

                    //Step 6:- Describe Instances to know the status of the instances
                    var instanceRequest = new DescribeInstancesRequest
                    {
                        InstanceIds = new List<string>
                        {
                            instanceIds[0]
                        }
                    };

                    while (true)
                    {
                        var response = await amazonEC2Client.DescribeInstancesAsync(instanceRequest);
                        if (response.Reservations[0].Instances[0].State.Name == InstanceStateName.Running)
                        {
                            instanceID = response.Reservations[0].Instances[0].PublicDnsName + "With the status of " + InstanceStateName.Running;
                            break;
                        }
                    }

                }

            }
            return instanceID;

        }

        public async Task<bool> IsSecurityGroupsExistsAsync(string groupName)
        {
            DescribeSecurityGroupsRequest securityGroupsRequest = new DescribeSecurityGroupsRequest();
            var sgResponse = await amazonEC2Client.DescribeSecurityGroupsAsync(securityGroupsRequest);
            List<SecurityGroup> securityGroups = new List<SecurityGroup>();
            securityGroups = sgResponse.SecurityGroups;
            foreach (var item in securityGroups)
            {
                if (item.GroupName == groupName)
                {
                    SecurityGroup securityGroup = item;
                    return true;
                }
            }
            return false;
        }

        public async Task<SecurityGroup> CreateSecurityGroupAsync(string secGroupName)
        {

            try
            {
                var newSGrequest = new CreateSecurityGroupRequest
                {
                    GroupName = secGroupName,
                    Description = "My sample security group for EC2-Classic"
                };
                var response = await amazonEC2Client.CreateSecurityGroupAsync(newSGrequest);
                List<string> GroupId = new List<string>() { response.GroupId };
                DescribeSecurityGroupsRequest securityGroupsRequest = new DescribeSecurityGroupsRequest()
                {
                    GroupIds = GroupId
                };
                var securityGroupsResponse = amazonEC2Client.DescribeSecurityGroupsAsync(securityGroupsRequest);
                SecurityGroup securityGroup = securityGroupsResponse.Result.SecurityGroups[0];

                return securityGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string CreateKeyPair()
        {
            string keyPairName = "Ec2Test";
            KeyPairInfo myKeyPair = null;

            try
            {
                var dkpRequest = new DescribeKeyPairsRequest();
                var dkpResponse = amazonEC2Client.DescribeKeyPairsAsync(dkpRequest).Result;
                List<KeyPairInfo> myKeyPairs = dkpResponse.KeyPairs;

                foreach (KeyPairInfo item in myKeyPairs)
                {
                    Console.WriteLine("Existing key pair: " + item.KeyName);
                    if (item.KeyName == keyPairName)
                    {
                        myKeyPair = item;
                    }
                }

                if (myKeyPair == null)
                {
                    var newKeyRequest = new CreateKeyPairRequest()
                    {
                        KeyName = keyPairName
                    };
                    var ckpResponse = amazonEC2Client.CreateKeyPairAsync(newKeyRequest).Result;
                    Console.WriteLine();
                    Console.WriteLine("New key: " + keyPairName);

                    // Save the private key in a .pem file
                    using (FileStream s = new FileStream(keyPairName + ".pem", FileMode.Create))
                    using (StreamWriter writer = new StreamWriter(s))
                    {
                        writer.WriteLine(ckpResponse.KeyPair.KeyMaterial);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return keyPairName;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
