using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListString : PListValue
    {

        public string Value { get; set; }

        public PListString(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return ToPList();
        }

        public override string ToPList(int tab = -1)
        {
            char SINGLE_QUOTE = '\'';
            char DOUBLE_QUOTE = '\"';
            char quoteChar = DOUBLE_QUOTE;
            if (Value.Contains(DOUBLE_QUOTE))
            {
                if (!Value.Contains(SINGLE_QUOTE))
                    quoteChar = SINGLE_QUOTE;
                else
                    Value = Value.Replace(DOUBLE_QUOTE.ToString(), "\\" + DOUBLE_QUOTE);
            }
            return String.Format("{0}{1}{0}", quoteChar, Value);
        }

        protected override IList<PListToken> ChildrenTokens
        {
            get { throw new NotImplementedException(); }
        }
    }
}
