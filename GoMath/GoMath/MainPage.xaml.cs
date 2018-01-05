using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GoMath.ServiceReference1;
using Windows.UI.Popups;
using Windows.System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NutDangKi(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DangKiPage));
        }
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        private async void NutDangNhap(object sender, RoutedEventArgs e)
        {
            if (TenDangNhap.Text == "" || MatKhau.Password == "")
            {
                MessageDialog _message = new MessageDialog("Vui lòng nhập đầy đủ thông tin!");
                await _message.ShowAsync();
                return;
            }
            var role = await db.UserLoginAsync(TenDangNhap.Text, MatKhau.Password);
            MessageDialog message;
            if(role.Body.UserLoginResult==null)
            {
                message = new MessageDialog("Sai thông tin đăng nhập");
                await message.ShowAsync();
                LopThongTin.loginUser = null;
                return;
            }
            LopThongTin.loginUser = role.Body.UserLoginResult;
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void Thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
     
    }
}
