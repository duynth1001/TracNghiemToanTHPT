using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
             Welcometxtblock.Text = "Xin chào " + LopThongTin.loginUser.FullName;
        }
      

        private void DangXuatButton(object sender, TappedRoutedEventArgs e)
        {
            LopThongTin.loginUser = null;
            LopThongTin.ChuyenDeCode = null;
            LopThongTin.ChuyenDePass = null;
            LopThongTin.LyThuyetCode = null;
            LopThongTin.BoDeObject = null;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BoDeTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BodePage));
        }

        private void ChuyenDeTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChuyendePage));
        }

        private void KiemTraTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LyThuyetPage));
        }

        private void LichSuLamBaiTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LichSuLamBaiPage));
        }

        private void ThongTinNguoiDungTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThongTinNguoiDung));
        }
    }
}
