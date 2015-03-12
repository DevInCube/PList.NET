using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PList.Linq
{
    public class PListElement : PListNode
    {

        public string Key { get; set; }
        public PListValue Value { get; set; }

        public PListElement(string key)
        {
            this.Key = key;
        }

        public PListElement(string key, PListValue value)
            : this(key)
        {
            this.Value = value;
        }

        public PListElement(string key, PListValue value, params PListAttribute[] attrs)
            : this(key, value)
        {
            //@todo attrs
        }

        public PListElement(string key, params PListAttribute[] attrs)
            : this(key, null, attrs) { }
    }
}
