using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList.Linq
{
    public class PListAttribute : PListObject
    {

        public string Key { get; set; }
        public string Value { get; set; }

        public PListAttribute(string key)
        {
            this.Key = key;
        }
        public PListAttribute(string key, Object value)
        {
            this.Key = key;
            this.Value = (value == null) ? null : value.ToString();
        }
    }
}
