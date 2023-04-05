using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Product
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public IFormFile FormFile { get; set; }
    }
}
