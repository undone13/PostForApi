using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PostForApi.Classes
{
    public class Model
    {
        public string DataBaseName { get; set; }

        public Model()
        {
            Headers = new List<Header>();
            Values = new List<List<ValueClass>>();
        }

        public List<Header> Headers { get; set; }

        public List<List<ValueClass>> Values { get; set; }
    }

    public class Header
    {
        public string ColumnName { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
    }

    public class ValueClass
    {
        public string ColumnName { get; set; }
        public Object Value { get; set; }
    }

}
