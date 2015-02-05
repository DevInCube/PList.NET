using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListTuple : PListValue
    {

        public List<PListString> Items { get; private set; }

        public PListTuple()
        {
            Items = new List<PListString>();
        }

        public override string ToString()
        {
            return ToPList();
        }

        public override string ToPList(int tab = -1)
        {
            StringBuilder b = new StringBuilder();
            foreach (var attr in Items)
            {
                b.Append(String.Format("{0}", attr.ToPList(tab)));
                if (Items.Last() != attr)
                    b.Append(", ");
            }
            return String.Format("( {0} )", b.ToString());
        }

        protected override IList<PListToken> ChildrenTokens
        {
            get { return (IList<PListToken>)Items.Cast<PListToken>(); }
        }
    }
}
