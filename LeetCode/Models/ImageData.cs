using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class ImageData
    {
        public ImageData()
        {
            base64Data = "";
            fileName = "";
            fileSize = 0;
        }
        public string base64Data { get; set; }

        public string fileName { get; set; }
        public int fileSize { get; set; }

        public string RekognitionType { get; set; }
    }
}
