using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser
{
    public class PListAttribute : PListProperty
    {

        public PListAttribute(string key, object value)
            : base(key, value)
        {
            //
        }

        public override string ToString()
        {
            string val = "";
            if (Value is PListString)
            {
                PListString pStr = Value as PListString;
                val = String.Format("{0}{1}{0}", pStr.OpenChar, pStr.Value);
            }
            else
                val = String.Format("\"{0}\"", Value.ToString());
            return String.Format("{0} = {1}", Key, val);
        }
    }
}
