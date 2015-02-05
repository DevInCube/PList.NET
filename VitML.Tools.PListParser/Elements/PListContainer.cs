using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public abstract class PListContainer : PListToken
    {

        protected abstract IList<PListToken> ChildrenTokens { get; }

        public PListContainer()
        {
            //
        }
    }
}
