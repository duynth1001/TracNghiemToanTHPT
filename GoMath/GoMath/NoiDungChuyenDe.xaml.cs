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
    public sealed partial class NoiDungChuyenDe : Page
    {
        public NoiDungChuyenDe()
        {
            this.InitializeComponent();
            LoadListView();
        }
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        List<ServiceReference1.ChuyenDe> ChuyenDeList = new List<ChuyenDe>();
        private async void LoadListView()
        {
            MessageDialog message;
            if (LopThongTin.ChuyenDeCode == "kshs")
            {
                var role = await db.GetChuyenDeHamSoAsync();
                if(role.Body.GetChuyenDeHamSoResult==null)
                {
                    message = new MessageDialog("Tải trang thất bại!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                ChuyenDeList = role.Body.GetChuyenDeHamSoResult.ToList<ServiceReference1.ChuyenDe>();
                Chuyendelv.ItemsSource = ChuyenDeList;
            }
            if (LopThongTin.ChuyenDeCode == "luythua")
            {
                var role = await db.GetChuyenDeLuyThuaAsync();
                if (role.Body.GetChuyenDeLuyThuaResult == null)
                {
                    message = new MessageDialog("Tải trang thất bại!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                ChuyenDeList = role.Body.GetChuyenDeLuyThuaResult.ToList<ServiceReference1.ChuyenDe>();
                Chuyendelv.ItemsSource = ChuyenDeList;
            }

            if (LopThongTin.ChuyenDeCode == "tichphan")
            {
                var role = await db.GetChuyenDeNguyenHamAsync();
                if (role.Body.GetChuyenDeNguyenHamResult == null)
                {
                    message = new MessageDialog("Tải trang thất bại!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                ChuyenDeList = role.Body.GetChuyenDeNguyenHamResult.ToList<ServiceReference1.ChuyenDe>();
                Chuyendelv.ItemsSource = ChuyenDeList;
            }

            if (LopThongTin.ChuyenDeCode == "sophuc")
            {
                var role = await db.GetChuyenDeSoPhucAsync();
                if (role.Body.GetChuyenDeSoPhucResult == null)
                {
                    message = new MessageDialog("Tải trang thất bại!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                ChuyenDeList = role.Body.GetChuyenDeSoPhucResult.ToList<ServiceReference1.ChuyenDe>();
                Chuyendelv.ItemsSource = ChuyenDeList;
            }
            if (LopThongTin.ChuyenDeCode == "thetich")
            {
                var role = await db.GetChuyenDeTheTichAsync();
                if (role.Body.GetChuyenDeTheTichResult == null)
                {
                    message = new MessageDialog("Tải trang thất bại!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                ChuyenDeList = role.Body.GetChuyenDeTheTichResult.ToList<ServiceReference1.ChuyenDe>();
                Chuyendelv.ItemsSource = ChuyenDeList;
            }

        }
        private void TroLaiButton(object sender, RoutedEventArgs e)
        {           
            Frame.GoBack();
        }

        private void ChuyenDeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChuyenDe temp = (ChuyenDe)Chuyendelv.SelectedItem;
            LopThongTin.ChuyenDePass = temp;
            this.Frame.Navigate(typeof(LamChuyenDePage));
        }
    }
}
