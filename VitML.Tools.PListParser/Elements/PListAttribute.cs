using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListAttribute : PListToken
    {

        public PListString Key { get; set; }
        public PListString Value { get; set; }

        public PListAttribute(PListString key, PListString value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}", Key, Value.ToString());
        }


        public override string ToPList(int tab = -1)
        {
            return ToString();
        }
    }
}
