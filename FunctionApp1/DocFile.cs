using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public class DocFile
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string PersonName { get; set; }
        public string PersonCpf{ get; set; }
        public DateTime DataProcess { get; set; }
    }
}
