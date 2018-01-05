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
    public sealed partial class ChuyendePage : Page
    {
        public ChuyendePage()
        {
            this.InitializeComponent();
            ChuyenDeListView.ItemsSource = ChuyenDeClassManager.Get();
        }


        private void TroLaiButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void ChuyenDeSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            ChuyendeClass temp = (ChuyendeClass)ChuyenDeListView.SelectedItem;
            LopThongTin.ChuyenDeCode = temp.ChuyenDeCode;
            this.Frame.Navigate(typeof(NoiDungChuyenDe));
        }
    }
}
