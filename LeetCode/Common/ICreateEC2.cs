using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Common
{
    public interface ICreateEC2
    {
        string CreateInstance();

        Task<string> CreateSnapShotAsync();

        Task<string> RestoreDBFromSnapShotAsync();

        bool IsDBExistis();

        Task<string> CreateEC2InstanceAsync(int serverType = 0);

        Task<bool> IsSecurityGroupsExistsAsync(string groupName);

        Task<SecurityGroup> CreateSecurityGroupAsync(string secGroupName);

        string CreateKeyPair();
    }
}
