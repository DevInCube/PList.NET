﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VitML.PListParser.Test.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VitML.PListParser.Test.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to settings{ name=&quot;Parking&quot; version=&quot;1.16.0.781&quot; } = [
        ///mainForm = &quot;resources2\ui\OSAParking4.plist&quot;;
        ///viewConfig = [
        ///Col = &quot;0&quot;;
        ///Row = &quot;1&quot;;
        ///inspectPath = &quot;Views\Inspection2en.plist&quot;;
        ///];
        ///dataStorage = [
        ///dataDataLifeTime = &quot;0:30:0:0:0&quot;;
        ///mediaDataLifeTime = &quot;0:365:0:0:0&quot;;
        ///];
        ///raconfig = [
        ///Enabled = &quot;0&quot;;
        ///Port = &quot;0&quot;;
        ///ComputerName = &quot;vit-pc&quot;;
        ///Group = ;
        ///Auth_Enabled = &quot;0&quot;;
        ///Host = &quot;192.168.1.40&quot;;
        ///routerconfig = [
        ///Host = ;
        ///Port = &quot;0&quot;;
        ///];
        ///];
        ///settings{ System=&quot;AutoCode&quot; } = [
        ///viewPortMax = &quot;16&quot;;
        ///set [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string plist {
            get {
                return ResourceManager.GetString("plist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	foo1 = bar ;
        ///	foo2 = &apos;bar&apos;;
        ///	foo3 = &quot;bar&quot;;
        ///	foo4 = bar &quot;bar&quot; &apos;bar&apos;      
        ///	;
        ///	
        ///}.
        /// </summary>
        internal static string TestStringPList {
            get {
                return ResourceManager.GetString("TestStringPList", resourceCulture);
            }
        }
    }
}
