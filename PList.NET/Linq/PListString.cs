using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList.Linq
{
    public class PListString : PListValue
    {

        private string value;

        public PListString(string str)
        {
            this.value = str;
        }

        public override string ToString()
        {
            return value;
        }

        public static implicit operator string(PListString plString)
        {
            return plString.ToString();
        }

        public static implicit operator PListString(string val)
        {
            return new PListString(val);
        }

        public static PListString operator +(PListString pstr, string str)
        {
            return new PListString(pstr.value + str);
        }

        public static PListString operator +(string str, PListString pstr)
        {
            return new PListString(str + pstr.value);
        }
    }
}
