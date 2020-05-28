using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Services
{
    public abstract class ClsFactory
    {
        public abstract IRekognition GetProduct(string pName);
    }
}
