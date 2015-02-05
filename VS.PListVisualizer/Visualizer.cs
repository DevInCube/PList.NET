using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Drawing;
using VitML.Tools.PListParser;

[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(VS.PListVisualizerNS.PListVisualizer),
typeof(VisualizerObjectSource),
Target = typeof(string),
Description = "VIT PList Visualizer")]
namespace VS.PListVisualizerNS
{
    public class PListVisualizer : DialogDebuggerVisualizer
    {
        override protected void Show(IDialogVisualizerService windowService,
                           IVisualizerObjectProvider objectProvider)
        {
            string str = (string)objectProvider.GetObject();

            PListForm form = new PListForm();
            form.Text = "VIT PList Visualizer";
            
            PListProperty prop = PListProperty.Parse(str);
            form.ShowPList(prop.ToStringIndent());

            windowService.ShowDialog(form);
        }
    }
}