using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser
{
    public class PListString
    {

        public char OpenChar { get; set; }

        public string Value { get; set; }

        public PListString(string value, char openChar = '"')
        {
            this.Value = value;
            this.OpenChar = openChar;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
