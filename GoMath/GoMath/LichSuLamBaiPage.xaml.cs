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
using GoMath.ServiceReference1;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LichSuLamBaiPage : Page
    {
        public LichSuLamBaiPage()
        {
            this.InitializeComponent();
            LoadListView();
        }
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        List<ServiceReference1.LichSuLamBaiClass> LichSuLamBaiList = new List<LichSuLamBaiClass>();

        private async void LoadListView()
        {
            var role = await db.GetLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung);
            if (role.Body.GetLichSuLamBaiResult == null)
            {
                LichSuLamBailv.ItemsSource = null;
                return;
            }
            LichSuLamBaiList = role.Body.GetLichSuLamBaiResult.ToList<ServiceReference1.LichSuLamBaiClass>();
            LichSuLamBailv.ItemsSource = LichSuLamBaiList;

        }
        private void TroLaiButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }
    }
}
