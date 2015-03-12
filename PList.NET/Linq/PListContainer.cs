using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList.Linq
{
    public abstract class PListContainer : PListValue
    {

        public abstract PListNode Nodes();    
    }
}
