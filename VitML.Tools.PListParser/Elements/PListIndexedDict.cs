using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListIndexedDict : PListDict
    {

        public PListIndexedDict()
        {
            openChar = '[';
            closeChar = ']';
        }
    }
}
