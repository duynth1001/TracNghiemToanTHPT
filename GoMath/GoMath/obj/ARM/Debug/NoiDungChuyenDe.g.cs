﻿#pragma checksum "C:\Users\VTC-Academy\Desktop\Trắc nghiệm toán thpt\GoMath\GoMath\NoiDungChuyenDe.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B042F7854EFBA070503B5F1EA8F8DAAE"
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
    partial class NoiDungChuyenDe : 
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
                    this.Chuyendelv = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 11 "..\..\..\NoiDungChuyenDe.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Chuyendelv).SelectionChanged += this.ChuyenDeSelectionChanged;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 19 "..\..\..\NoiDungChuyenDe.xaml"
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

