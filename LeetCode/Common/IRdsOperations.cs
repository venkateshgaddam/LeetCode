using Amazon.RDS.Model;
using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Common
{
    interface IRdsOperations
    {
        Response GetDecodings(string inputString);
    }
}
