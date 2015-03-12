using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList.Linq
{
    public class PListComment : PListNode
    {

        protected string value;

        public PListComment(string comment)
        {
            this.value = comment;
        }

        public PListComment(PListComment comment)
        {
            this.value = comment.value;
        }

        public override string ToString()
        {
            string BLOCK_COMMENT_OPEN = "/*";
            string BLOCK_COMMENT_CLOSE = "*/";
            return String.Format("{0}{1}{2}", BLOCK_COMMENT_OPEN, value, BLOCK_COMMENT_CLOSE);
        }
    }
}
