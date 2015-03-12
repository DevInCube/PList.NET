using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PList.Linq
{
    public class PListDocument : PListDict
    {

        public PListDocument() { }
        public PListDocument(PListDocument doc) { throw new NotImplementedException(); }

        public static PListDocument Parse(string plist)
        {
            using (PListReader reader = new PListTextReader(new StringReader(plist)))
            {
                PListDocument o = Load(reader);

               // if (reader.Read() && reader.TokenType != JsonToken.Comment)
               //     throw JsonReaderException.Create(reader, "Additional text found in JSON string after parsing content.");

                return o;
            }
        }

        private static PListDocument Load(PListReader reader)
        {
            /*ValidationUtils.ArgumentNotNull(reader, "reader");

            if (reader.TokenType == JsonToken.None)
            {
                if (!reader.Read())
                    throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader.");
            }

            while (reader.TokenType == JsonToken.Comment)
            {
                reader.Read();
            }

            if (reader.TokenType != JsonToken.StartObject)
            {
                throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader. Current JsonReader item is not an object: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
            }
            */
            PListDocument o = new PListDocument();
            // o.SetLineInfo(reader as IJsonLineInfo);

            o.ReadFrom(reader);

            return o;
        }

        private void ReadFrom(PListReader reader)
        {
            PListObject parent = this;

            do
            {
                switch (reader.TokenType)
                {
                    case (PListToken.None): break;
                    case (PListToken.StartDict):
                        {
                            PListDict dict = new PListDict();
                            dict.Parent = parent;
                            parent = dict;
                            break;
                        }
                    case (PListToken.EndDict):
                        {
                            if (parent == this)
                                return;
                             parent = parent.Parent;
                             break;
                        }
                }

            } while (reader.Read());
        }
    }
}
