using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public abstract class PListToken
    {

        private PListContainer _parent;

        public PListContainer Parent
        {
            [DebuggerStepThrough]
            get { return _parent; }
            internal set { _parent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab">'-1' - no indent</param>
        /// <returns></returns>
        public abstract string ToPList(int tab = -1);
    }
}
