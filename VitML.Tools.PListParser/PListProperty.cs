using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser
{
    public class PListProperty
    {

        public string Key { get; set; }
        public List<PListAttribute> Attributes { get; private set; }
        public object Value { get; set; }

        public PListProperty(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }

        public PListProperty(string key, params PListProperty[] props)
        {
            this.Key = key;
            PListObject obj = null;
            foreach (var prop in props)
            {
                if (prop is PListAttribute)
                {
                    if(Attributes == null)
                        this.Attributes = new List<PListAttribute>();
                    this.Attributes.Add(prop as PListAttribute);
                }
                else
                {
                    if (obj == null)
                        obj = new PListObject();
                    obj.Properties.Add(prop);
                }
            }
            this.Value = obj;
        }

        public PListProperty(string key, List<PListAttribute> attrs, object value)
        {
            this.Key = key;
            Attributes = attrs;
            this.Value = value;
        }

        public static PListProperty Parse(string plist)
        {
            int pos = 0;
            return ParseProperty(plist, ref pos);
        }

        private static void MoveToNonWhitespace(string str, ref int pos)
        {
            while (pos < str.Length)
            {
                char ch = str[pos];
                if (!Char.IsWhiteSpace(ch))
                    break;
                pos++;
            }
        }

        private static void MoveTo(string str, char match, ref int pos)
        {
            while (pos < str.Length)
            {
                char ch = str[pos];
                if (ch == match)
                    break;
                pos++;
            }
        }

        private static PListProperty ParseProperty(string str, ref int pos)
        {
            string key = ParseKey(str, ref pos).Trim();
            List<PListAttribute> attrs = null;
            if (str[pos] == '{')
                attrs = ParseAttributes(str, ref pos);
            pos++;
            object value = ParseValue(str, ref pos);
            MoveTo(str, ';', ref pos);
            pos++;
            return new PListProperty(key, attrs, value);
        }

        private static PListAttribute ParseAttribute(string str, ref int pos)
        {
            string key = ParseKey(str, ref pos);
            MoveTo(str, '=', ref pos);
            pos++;
            MoveToNonWhitespace(str, ref pos);
            char ch = str[pos];
            object value = ParseString(ch, str, ref pos);
            return new PListAttribute(key, value);
        }

        private static object ParseValue(string str, ref int pos)
        {
            while(pos < str.Length)
            {
                char ch = str[pos];
                if (ch == '"' || ch=='\'')
                    return ParseString(ch, str, ref pos);
                else if (ch == '[')
                    return ParseObject(str, ref pos);
                else if (ch == ';')
                    return null;
                pos++;
            }
            return null;
        }

        private static object ParseObject(string str, ref int pos)
        {
            if (str[pos] != '[') throw new Exception("invalid object start");
            pos++;
            List<PListProperty> props = new List<PListProperty>();
            while (pos < str.Length)
            {
                MoveToNonWhitespace(str, ref pos);
                if (str[pos] == ']')
                    break;
                else
                {
                    PListProperty p = ParseProperty(str, ref pos);
                    props.Add(p);
                }
            }
            if (str[pos] != ']') throw new Exception("invalid object end");
            pos++;
            return new PListObject(props);
        }

        private static PListString ParseString(char openChar, string str, ref int pos)
        {
            if (str[pos] != openChar) throw new Exception("invalid string");
            pos++;
            StringBuilder b = new StringBuilder();
            while (pos < str.Length)
            {
                char ch = str[pos];
                if (ch == '\\')
                {
                    if (pos + 1 < str.Length)
                    {
                        b.Append(ch).Append(str[pos + 1]);
                        pos++;
                    }
                    else
                        throw new Exception("invalid end of escape");
                }
                else if (ch == openChar)
                    break;
                else
                    b.Append(ch);
                pos++;
            }
            if (str[pos] != openChar) throw new Exception("invalid end of string");
            if (pos == str.Length) throw new Exception("invalid end of string");
            pos++;
            return new PListString(b.ToString(), openChar);
        }

        private static List<PListAttribute> ParseAttributes(string str, ref int pos)
        {
            if (str[pos] != '{') throw new Exception("invalid string");
            pos++;
            List<PListAttribute> attributes = new List<PListAttribute>();
            while (pos < str.Length)
            {
                char ch = str[pos];
                if (ch == '}')
                {
                    pos++;
                    break;
                }
                else if (ch != ' ')
                {
                    PListAttribute attr = ParseAttribute(str, ref pos);
                    attributes.Add(attr);
                }
                pos++;
            }
            return attributes;
        }

        private static string ParseKey(string str, ref int pos)
        {
            StringBuilder b = new StringBuilder();
            MoveToNonWhitespace(str, ref pos);
            while( pos < str.Length)
            {
                char ch = str[pos];
                if (ch == '{' || ch == '=')
                    break;
                else
                    b.Append(ch);
                pos++;
            }
            return b.ToString();
        }

        public override string ToString()
        {
            string AttrStr = "";
            if (Attributes != null)
            {
                StringBuilder b = new StringBuilder();
                foreach (var attr in Attributes)
                    b.Append(String.Format("{0} ", attr.ToString()));
                AttrStr = "{" + String.Format(" {0}", b.ToString()) + "}";
            }
            string val = "";
            if (Value != null)
            {
                if (Value is PListObject)
                    val = (Value as PListObject).ToString();
                else if (Value is PListString)
                {
                    PListString pStr = Value as PListString;
                    val = String.Format("{0}{1}{0}", pStr.OpenChar, pStr.Value);
                }
                else
                    val = String.Format("{0}{1}{0}", '"', Value.ToString());
            }
            return String.Format("{0} {1} = {2};", Key, AttrStr, val);
        }

        public string ToStringIndent(int tab = 0)
        {
            string indent = "".PadLeft(tab, '\t');
            string AttrStr = "";
            if (Attributes != null)
            {
                StringBuilder b = new StringBuilder();
                foreach (var attr in Attributes)
                    b.Append(String.Format("{0} ", attr.ToString()));
                AttrStr = "{" + String.Format(" {0}", b.ToString()) + "}";
            }
            string val = "";
            if (Value != null)
            {
                if (Value is PListObject)
                    val = (Value as PListObject).ToStringIndent(tab + 1);
                else if (Value is PListString)
                {
                    PListString pStr = Value as PListString;
                    val = String.Format("{0}{1}{0}", pStr.OpenChar, pStr.Value);
                }
                else
                    val = String.Format("{0}{1}{0}", '"', Value.ToString());
            }
            return indent + String.Format("{0} {1} = {2};", Key, AttrStr, val);
        }

    }
}
