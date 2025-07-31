using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAbstractLayer.Database
{
    public class RecordData
    {
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public RecordData()
        {
            Clear();
        }

        public void Clear()
        {
            Id = 0;
            Value1 = "";
            Value2 = "";
        }
    }
}
