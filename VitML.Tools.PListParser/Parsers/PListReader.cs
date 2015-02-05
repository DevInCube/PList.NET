using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitML.Tools.PListParser
{
    
    public enum LexemType
    {
        Delimiter,
        String,
        Comment
    }

    public class PListLexem
    {

        public LexemType Type{get;set;}
        public string Value{get;set;}
        public CharPosition Position { get; private set; }

        public PListLexem(string val, LexemType type, CharPosition Position)
        {
            this.Value = val;
            this.Type = type;
            this.Position = Position;
        }

        public override string ToString()
        {
            return String.Format("`{0}` | {1} | {2}", Value, Type, Position);
        }

    }

    public struct CharPosition
    {

        public int Line;
        public int LinePosition;

        public CharPosition(int line, int linePosition)
        {
            this.Line = line;
            this.LinePosition = linePosition;
        }

        public CharPosition(CharPosition pos)
        {
            this.Line = pos.Line;
            this.LinePosition = pos.LinePosition;
        }

        public override string ToString()
        {
            return String.Format("[{0}:{1}]", Line, LinePosition);
        }
    }

    public class PListReader
    {

        private string str;
        private int pos;
        private CharPosition charPosition;
        private PListLexem prev;

        private char[] delimiters = new char[] { '{', '}', '[', ']', '(', ')', ',', ';', '=' };

        public PListReader(string str)
        {
            this.str = str;
            pos = 0;
            charPosition = new CharPosition(1, 1);
        }

        public PListLexem Read()
        {   
            MoveToNonWhitespace();
            if (IsEOF()) return null;
            if (Char == '/')
            {
                if (HasNext())
                {
                    if (Next == '*')
                        return ReadBlockComment();
                    else if (Next == '/')
                        return ReadLineComment();
                    else
                        throw new Exception("Unexpected characted '/'");
                }
                else
                {
                    throw new Exception("Unexpected end of string '/'");
                }
            }
            else if (delimiters.Contains(Char))
                return ReadDelimiter();
            else if (Char == '\'' || Char == '\"')
                return ReadQuotedString(Char);
            else
                return ReadString();
        }

        private PListLexem ReadString()
        {
            CharPosition startPos = new CharPosition(charPosition);
            StringBuilder b = new StringBuilder();
            bool closed = false;
            while (!IsEOF())
            {
                if (delimiters.Contains(Char))
                {
                    closed = true;
                    break;
                }
                b.Append(Char);
                MoveNext();
            }
            if (!closed)
                throw new Exception(String.Format("Unclosed string starting at {0}", startPos));
            string stringVal = b.ToString().TrimEnd();
            return new PListLexem(stringVal, LexemType.String, startPos);
        }

        private PListLexem ReadDelimiter()
        {
            string val = Char.ToString();
            PListLexem tok = new PListLexem(val, LexemType.Delimiter, charPosition);
            MoveNext();
            return tok;
        }

        private PListLexem ReadQuotedString(char openChar)
        {
            CharPosition startPos = new CharPosition(charPosition);
            StringBuilder b = new StringBuilder();
            MoveNext();
            bool closed = false;
            while (!IsEOF())
            {
                if (Char == '\\')
                {
                    if(HasNext())
                    {
                        if (Next == openChar)
                        {
                            b.Append(Next);
                            MoveNext();
                            MoveNext();
                        }
                    }
                    else
                        break;
                }
                else if(Char == openChar)
                {
                    MoveNext();
                    closed = true;
                    break;
                }
                b.Append(Char);
                MoveNext();
            }
            if (!closed)
                throw new Exception(String.Format("Unclosed string starting at {0}", startPos));
            return new PListLexem(b.ToString(), LexemType.String, startPos);
        }

        private PListLexem ReadLineComment()
        {
            CharPosition startPos = new CharPosition(charPosition);
            StringBuilder b = new StringBuilder();
            b.Append(Char).Append(Next);
            MoveNext();
            MoveNext();
            while (!IsEOF())
            {
                if (Char == '\n')
                {
                    MoveNext();
                    break;
                }
                b.Append(Char);
                MoveNext();
            }
            return new PListLexem(b.ToString(), LexemType.Comment, startPos);
        }

        private PListLexem ReadBlockComment()
        {
            CharPosition startPos = new CharPosition(charPosition);
            StringBuilder b = new StringBuilder();
            b.Append(Char).Append(Next);
            MoveNext();
            MoveNext();
            bool closed = false;
            while (!IsEOF())
            {
                if (Char == '*')
                {
                    if (HasNext())
                    {
                        if (Next == '/')
                        {
                            b.Append(Char).Append(Next);
                            MoveNext();
                            MoveNext();
                            closed = true;
                            break;
                        }
                    }
                }
                b.Append(Char);
                MoveNext();
            }
            if(!closed)
                throw new Exception(String.Format("Unclosed comment starting at {0}", startPos));
            return new PListLexem(b.ToString(), LexemType.Comment, startPos);
        }

        private char Char
        {
            get { return str[pos]; }
        }

        private bool HasNext()
        {
            return pos + 1 < str.Length;
        }

        private char Next
        {
            get { return str[pos + 1]; }
        }

        private void MoveToNonWhitespace()
        {
            while (!IsEOF())
            {
                if (!Char.IsWhiteSpace(Char))
                    break;
                MoveNext();
            }
        }

        private void MoveNext()
        {
            bool isNewLine = Char == '\n';
            pos++;
            charPosition.LinePosition++;
            if (isNewLine)
            {
                charPosition.Line++;
                charPosition.LinePosition = 1;
            }
        }

        private bool IsEOF()
        {
            return pos >= str.Length;
        }
    }
}
