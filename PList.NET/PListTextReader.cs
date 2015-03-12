using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList
{
    public class PListTextReader : PListReader
    {

        public PListTextReader(StringReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            base.Close();
            //@todo reader close
        }

    }
}
