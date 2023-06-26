using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Data
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Topic { get;set; }
        public string Reference { get; set; }
        public string IsDone { get; set; }
    }
}
