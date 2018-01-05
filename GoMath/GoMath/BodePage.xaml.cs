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
using System.Diagnostics;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class BodePage : Page
    {
        public BodePage()
        {
            this.InitializeComponent();
            LoadListView();
        }
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        List<ServiceReference1.BoDe> BoDeList = new List<BoDe>();
        private async void LoadListView()
        {
            var role = await db.GetBoDeAsync();
            MessageDialog message;
            if (role.Body.GetBoDeResult==null)
            {
                message = new MessageDialog("Tải trang thất bại!");
                await message.ShowAsync();
                Frame.GoBack();
            }
            BoDeList = role.Body.GetBoDeResult.ToList<ServiceReference1.BoDe>();
            Bodelv.ItemsSource = BoDeList;
        }

        private void TroLaiButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

    
        private void BoDeSelection(object sender, SelectionChangedEventArgs e)
        {
             BoDe userSelection = (BoDe)Bodelv.SelectedItem;
            LopThongTin.BoDeObject = userSelection;
            Frame.Navigate(typeof(LamBoDePage));
        }
    }
}
