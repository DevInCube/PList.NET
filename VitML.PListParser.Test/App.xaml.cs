using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using VitML.Tools.PListParser;
using VitML.Tools.PListParser.Elements;

namespace VitML.PListParser.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string json = "{x:0}";

            var r = new JsonTextReader(new StringReader(json));

            var xa = new XAttribute("test", 0);
            XElement x = new XElement("X", xa);
            var p = xa.Parent;
            /*string str = VitML.PListParser.Test.Properties.Resources.plist;
            PListProperty prop = PListProperty.Parse(str);
            string plist = prop.ToString();
            prop = PListProperty.Parse(str);
            prop.ToStringIndent();

            PListProperty p = new PListProperty("plist",
                new PListAttribute("ok", "is"),
                new PListProperty("ok", 0),
                new PListProperty("str", new PListString("val", '\''))
                );
            var plist2 = p.ToString();
            */
            var str = "{}"; //VitML.PListParser.Test.Properties.Resources.TestStringPList
            var reader = new PListReader(str);
            var bld = new PListBuilder(reader);
            var obj = bld.Parse();
            string plist = obj.ToPList(0);
           /* List<PListToken> tokens = new List<PListToken>();
            PListToken tok = null;
            while((tok = reader.GetToken())!=null)
            {
                tokens.Add(tok);
            }*/

            Environment.Exit(0);
        }
    }
}
