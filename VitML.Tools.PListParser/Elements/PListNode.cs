using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListNode : PListToken
    {

        public PListString Key { get; set; }
        public PListValue Value { get; set; }
        public List<PListAttribute> Attributes { get; set; }

        public PListNode(PListString key, PListValue val)
        {
            Key = key;
            Value = val;
        }

        public override string ToString()
        {
            string AttrStr = "";
            if (Attributes != null)
            {
                StringBuilder b = new StringBuilder();
                foreach (var attr in Attributes)
                    b.Append(String.Format("{0} ", attr.ToString()));
                AttrStr = "{" + String.Format(" {0}", b.ToString()) + "}";
            }
            return String.Format("{0} {1} = {2};", Key, AttrStr, Value == null ? "" : Value.ToString());
        }

        public override string ToPList(int tab = -1)
        {
            string AttrStr = "";
            if (Attributes != null)
            {
                StringBuilder b = new StringBuilder();
                foreach (var attr in Attributes)
                    b.Append(String.Format("{0} ", attr.ToPList(tab)));
                AttrStr = "{" + String.Format(" {0}", b.ToString()) + "}";
            }
            string val = "";
            if (Value != null)
                val = Value.ToPList(tab);
            return String.Format("{0} {1} = {2};", Key, AttrStr, val);
        }
    }
}
