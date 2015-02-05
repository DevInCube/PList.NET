using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListDict : PListValue
    {

        protected char openChar = '{';
        protected char closeChar = '}';

        private Dictionary<string, PListNode> dict = new Dictionary<string, PListNode>();

        public PListNode this[string key]
        {
            get { return dict[key]; }
            set { dict[key] = value; }
        }

        public PListDict()
        {
            //
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (var node in dict.Values)
                b.Append(node.ToString()).Append("\r\n");
            return String.Format("{0}\r\n{1}{2}", openChar, b.ToString(), closeChar);
        }

        public override string ToPList(int tab = -1)
        {
            if (tab == -1) return this.ToString();
            else
            {
                StringBuilder b = new StringBuilder();
                b.Append(openChar).Append("\r\n");
                foreach (var p in dict.Values)
                {
                    b.Append("".PadLeft(tab + 1, '\t')).Append(p.ToPList(tab + 1)).Append("\r\n");
                }
                b.Append("".PadLeft(tab, '\t') + closeChar);
                return b.ToString();
            }
        }

        public void AddNode(PListNode node)
        {
            if (dict.ContainsKey(node.Key.Value))
                throw new Exception(String.Format("Dictionary already contains node with key `{0}`", node.Key));
        }

        protected override IList<PListToken> ChildrenTokens
        {
            get { return (IList<PListToken>)dict.Values.Cast<PListToken>(); }
        }
    }
}
