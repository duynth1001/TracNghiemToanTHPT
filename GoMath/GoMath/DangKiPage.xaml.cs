using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GoMath.ServiceReference1;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DangKiPage : Page
    {
        public DangKiPage()
        {
            this.InitializeComponent();
        }
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        private async void NguoiDungDangKi(object sender, RoutedEventArgs e)
        {
            if (TenDangNhap.Text == "" || TenDayDu.Text == "" || MatKhau.Password == "" || NhapLaiMatKhau.Password == "" || Email.Text == "")
            {
                var showDialog = new MessageDialog("Vui lòng điền đầy đủ tất cả thông tin!");
                var result = await showDialog.ShowAsync();
                return;
            }
            if (MatKhau.Password != NhapLaiMatKhau.Password)
            {
                var showDialog = new MessageDialog("Mật khẩu nhập lại phải giống với mật khẩu cũ!");
                var result = await showDialog.ShowAsync();
                return;
            }
            var _role = await db.InsertNewUserAsync(TenDangNhap.Text, TenDayDu.Text, Email.Text, MatKhau.Password);
            if (_role.Body.InsertNewUserResult == false)
            {
                var showDialog = new MessageDialog("Tên người dùng đã tồn tại, xin hãy thử tên khác!");
                var result = await showDialog.ShowAsync();
                return;
            }
            else
            {
                var role = await db.UserLoginAsync(TenDangNhap.Text, MatKhau.Password);        
                if (role.Body.UserLoginResult == null)
                {                   
                    LopThongTin.loginUser = null;
                    return;
                }
                LopThongTin.loginUser = role.Body.UserLoginResult;
                this.Frame.Navigate(typeof(MenuPage));
            }
        }
        private  void QuayLai(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
