using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser
{
    public class PListObject
    {

        public List<PListProperty> Properties { get; private set; }

        public PListObject()
        {
            Properties = new List<PListProperty>();
        }

        public PListObject(List<PListProperty> props)
        {
            Properties = props;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (var p in Properties)
                b.Append(p.ToString()).Append("\r\n");
            return String.Format("[\r\n{0}]", b.ToString());
        }

        public string ToStringIndent(int tab)
        {
            StringBuilder b = new StringBuilder();
            b.Append("[\r\n");
            foreach (var p in Properties)
                b.Append(p.ToStringIndent(tab)).Append("\r\n");
            b.Append("".PadLeft(tab - 1, '\t') + "]");
            return  b.ToString();
        }
    }
}
