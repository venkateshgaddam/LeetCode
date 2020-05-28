using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Services
{
    public interface IRekognition
    {
        string GetImageInfo(ImageData imageData, byte[] imgData = null);
    }
}
