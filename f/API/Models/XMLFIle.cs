using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class XMLFile
    {
        public string Path { get; set; }
        public XMLFile(string _path)
        {
            this.Path = _path;
        }
    }
}
