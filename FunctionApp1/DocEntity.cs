using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public class DocEntity
    {
        public string PersonName { get; set; }
        public string PersonCpf { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
