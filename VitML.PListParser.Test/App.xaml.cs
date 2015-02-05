using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            var reader = new PListReader(VitML.PListParser.Test.Properties.Resources.TestStringPList);
            var bld = new PListBuilder(reader);
            var obj = bld.Parse();
            string plist = obj.ToPList(0);
           /* List<PListToken> tokens = new List<PListToken>();
            PListToken tok = null;
            while((tok = reader.GetToken())!=null)
            {
                tokens.Add(tok);
            }*/
            return;
        }
    }
}
