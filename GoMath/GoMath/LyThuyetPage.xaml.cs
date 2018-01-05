using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class LyThuyetPage : Page
    {
        public LyThuyetPage()
        {
            this.InitializeComponent();
            LyThuyetListView.ItemsSource = LyThuyetClassManager.Get();
        }

        private void LyThuyetSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            LyThuyetClass temp = (LyThuyetClass)LyThuyetListView.SelectedItem;
            LopThongTin.LyThuyetCode = temp.LyThuyetCode;
            this.Frame.Navigate(typeof(XemLyThuyetPage));
        }
        private  void TroLaiButton(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
