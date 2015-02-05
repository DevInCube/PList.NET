using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser.Elements
{
    public class PListBuilder
    {

        private PListReader reader;
        private PListLexem token;

        public PListBuilder(PListReader reader)
        {
            this.reader = reader;
        }

        public PListToken Parse()
        {
            Next();
            return ReadValue();
        }

        private PListValue ReadValue()
        {
            while (token != null)
            {
                if (token.Type == LexemType.Delimiter)
                {
                    switch (token.Value)
                    {
                        case ("{"):
                            return ParseDict();
                        case ("["):
                            return ParseIndexedDict();
                        case ("("):
                            return ParseTuple();
                        default:
                            throw new Exception(String.Format("Unexpected token {0}", token));
                    }
                }
                else if (token.Type == LexemType.String)
                {
                    PListString str = new PListString(token.Value);
                    Next();
                    return str;
                }
                Next();
            }
            throw new Exception("error");
        }

        private PListValue ParseTuple()
        {
            PListTuple tuple = new PListTuple();
            Next();
            while (token != null)
            {
                if (token.Value == ")")
                {
                    Next();
                    break;
                }
                PListString strVal = (PListString)ReadValue();
                tuple.Items.Add(strVal);
                if (token.Value == ",")
                    Next();
            }
            return tuple;
        }

        private PListValue ParseIndexedDict()
        {
            PListIndexedDict dict = new PListIndexedDict();
            Next();
            while (token != null)
            {
                if (token.Value == "]")
                {
                    Next();
                    break;
                }
                PListNode node = ReadNode();
                dict[node.Key.Value] = node;
            }
            return dict;
        }

        private PListValue ParseDict()
        {
            PListDict dict = new PListDict();
            Next();
            while (token != null)
            {
                if (token.Value == "}")
                {
                    Next();
                    break;
                }
                PListNode node = ReadNode();
                dict[node.Key.Value] = node;
            }
            return dict;
        }

        private PListNode ReadNode()
        {
            if (token.Type != LexemType.String)
                throw new Exception("Node key expected");
            PListString key = (PListString)ReadValue();
            List<PListAttribute> Attrs = null;
            if (token.Value == "{")
                Attrs = ReadAttributes();
            if (token.Value != "=")
                throw new Exception("'=' expected");
            Next();
            PListValue val = null;
            if(token.Value != ";")
            {
                val = ReadValue();
                if(token.Value != ";")
                    throw new Exception("';' expected");
                Next();
            }
            return new PListNode(key, val) { Attributes = Attrs };
        }

        private List<PListAttribute> ReadAttributes()
        {
            List<PListAttribute> Attrs = new List<PListAttribute>();
            Next();
            while (token != null)
            {
                if (token.Value == "}")
                {
                    Next();
                    break;
                }
                PListAttribute attr = ReadAttribute();
                Attrs.Add(attr);
            }
            return Attrs;
        }

        private PListAttribute ReadAttribute()
        {
            if (token.Type != LexemType.String)
                throw new Exception("Attribute key expected");
            PListString key = (PListString)ReadValue();
            if (token.Value != "=")
                throw new Exception("'=' expected");
            Next();
            PListValue val = ReadValue();
            if (val is PListString)
                return new PListAttribute(key, val as PListString);
            else
                throw new Exception("invalid attribute value");
        }

        private void Next()
        {
            token = reader.Read();
            while (token!=null && token.Type == LexemType.Comment)
                token = reader.Read();
        }
    }
}
