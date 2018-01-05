using GoMath.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThongTinNguoiDung : Page
    {
        public ThongTinNguoiDung()
        {
            this.InitializeComponent();
            LoadTrang();
        }

        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        

        private async void LoadTrang()
        {
            var role = await db.GetNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung);
            MessageDialog message;
            if (role.Body.GetNguoiDungResult == null)
            {
                message = new MessageDialog("Tải trang thất bại!");
                await message.ShowAsync();
                Frame.GoBack();
            }
            ServiceReference1.ThongTinNguoiDungClass temp = role.Body.GetNguoiDungResult;
            DiemTrungBinh.Text = temp.DiemTrungBinh.ToString();
            TenNguoiDung.Text = LopThongTin.loginUser.FullName;
            EmailNguoiDung.Text = LopThongTin.loginUser.Email;
            SoBaiKiemTraDaLam.Text = temp.SoBaiKiemTraDaLam.ToString();
            XepLoai.Text = temp.XepLoai.ToString();
            Khaosathamso_textblock.Text = temp.TyLeLamBaiDung_khaosathamso.ToString() + "%";
            Luythua_textblock.Text = temp.TyLeLamBaiDung_luythualogarit.ToString() + "%";
            Nguyenham_textblock.Text = temp.TyLeLamBaiDung_nguyenhamtichphan.ToString() + "%";
            Sophuc_textblock.Text = temp.TyLeLamBaiDung_sophuc.ToString() + "%";
            Thetich_textblock.Text = temp.TyLeLamBaiDung_thetich.ToString() + "%";
        }

        private void TroLaiButton(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
