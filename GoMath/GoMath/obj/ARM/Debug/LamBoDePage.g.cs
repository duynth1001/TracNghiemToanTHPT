﻿#pragma checksum "C:\Users\VTC-Academy\Desktop\Trắc nghiệm toán thpt\GoMath\GoMath\LamBoDePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "12B2953630AC2786B2B6B7981B062BB1"
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
    partial class LamBoDePage : 
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
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\LamBoDePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element1).Click += this.SubmitBaiLam;
                    #line default
                }
                break;
            case 2:
                {
                    this.quizlistview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element3 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 32 "..\..\..\LamBoDePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element3).Click += this.QuayLai;
                    #line default
                }
                break;
            case 4:
                {
                    this.pdfViewer = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                    #line 44 "..\..\..\LamBoDePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.FlipView)this.pdfViewer).SelectionChanged += this.flipviewchange;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.ScrollViewer element5 = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                    #line 47 "..\..\..\LamBoDePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ScrollViewer)element5).DoubleTapped += this.scrollViewer_DoubleTapped;
                    #line default
                }
                break;
            case 6:
                {
                    this.tongsotrang = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.txtblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    global::GoMath.Controls.CustomControl1 element8 = (global::GoMath.Controls.CustomControl1)(target);
                    #line 27 "..\..\..\LamBoDePage.xaml"
                    ((global::GoMath.Controls.CustomControl1)element8).Checked1 += this.ChonCauA;
                    #line 27 "..\..\..\LamBoDePage.xaml"
                    ((global::GoMath.Controls.CustomControl1)element8).Checked2 += this.ChonCauB;
                    #line 27 "..\..\..\LamBoDePage.xaml"
                    ((global::GoMath.Controls.CustomControl1)element8).Checked3 += this.ChonCauC;
                    #line 27 "..\..\..\LamBoDePage.xaml"
                    ((global::GoMath.Controls.CustomControl1)element8).Checked4 += this.ChonCauD;
                    #line default
                }
                break;
            case 9:
                {
                    this.txt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

