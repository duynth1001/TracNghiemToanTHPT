﻿#pragma checksum "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\DangKiPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4CBB2E0710B373F0B62DC3A58D022A40"
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
    partial class DangKiPage : 
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
                    this.TenDangNhap = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.TenDayDu = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.Email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.MatKhau = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5:
                {
                    this.NhapLaiMatKhau = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6:
                {
                    this.DangKiButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 22 "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\DangKiPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.DangKiButton).Click += this.NguoiDungDangKi;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element7 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 23 "\\Mac\Home\Documents\Visual Studio 2015\Projects\GoMath\GoMath\DangKiPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element7).Click += this.QuayLai;
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

