﻿#pragma checksum "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\ChuyendePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4FD688D9625B20E2A75C56D3863DF1EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoMath
{
    partial class ChuyendePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ChuyenDeListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 11 "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\ChuyendePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ChuyenDeListView).SelectionChanged += this.ChuyenDeSelectionChange;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 21 "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\ChuyendePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element2).Click += this.TroLaiButton;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
