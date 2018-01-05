using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using GoMath.ServiceReference1;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LamBoDePage : Page
    {
        public LamBoDePage()
        {
            this.InitializeComponent();
            quizlistview.ItemsSource = LamBoDeClassManager.GetData();
            for(int i=0;i<50;i++)
            {
                datalist[i] = new ListOfDapAnNguoiDung();
                datalist[i].DapAnNguoiDung = "0";
            }
            LoadTrang();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;           
            basetime = 5400;
            txt.Text = basetime.ToString();
            timer.Start();
        }

        private DispatcherTimer timer;
        private int basetime;

        async void timer_Tick(object sender, object e)
        {
            basetime = basetime - 1;
            txt.Text = ((basetime/3600)% 24).ToString()+":"+ ((basetime % 3600) / 60).ToString()+":"+((basetime % 3600) % 60).ToString();
            if (basetime == 0)
            {
                timer.Stop();
                var dialog = new MessageDialog("Hết giờ!");
                await dialog.ShowAsync();
                var role = await db.GetDapAnAsync(FileName);
                MessageDialog message;
                if (role.Body.GetDapAnResult == null)
                {
                    message = new MessageDialog("Lỗi!");
                    await message.ShowAsync();
                    Frame.GoBack();
                }
                DapAnList = role.Body.GetDapAnResult.ToList<ServiceReference1.DapAnBoDe>();
                double DiemNguoiDung = 0;
                for (int i = 0; i < 50; i++)
                {
                    if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                        DiemNguoiDung += 0.2;
                }
                await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.BoDeObject.TenBoDe, "BoDe");
                await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "BoDe");
                message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                await message.ShowAsync();
                LopThongTin.BoDeObject = null;
                quizlistview.ItemsSource = LamBoDeClassManager.GetData();
                Frame.GoBack();
            }
        }
        string FileName = LopThongTin.BoDeObject.Title;
        public ObservableCollection<string> PdfImages = new ObservableCollection<string>();
        //Load de 
        uint pagecount = 0;
        private async void LoadTrang()
        {
            Debug.WriteLine(FileName);
            DateTime startTime = DateTime.Now;
            if (PdfImages == null)
                PdfImages = new ObservableCollection<string>();
            PdfImages.Clear();

            Uri fileTarget = new Uri(@"ms-appx:///KhoChuaDe/" + FileName + ".pdf");
            var file = await Package.Current.InstalledLocation.GetFileAsync(@"KhoChuaDe\" + FileName + ".pdf");
            var pdfFile = await PdfDocument.LoadFromFileAsync(file);

            if (pdfFile == null)
                return;
            tongsotrang.Text = pdfFile.PageCount.ToString();
            pagecount = pdfFile.PageCount;
            for (uint i = 0; i < pdfFile.PageCount; i++)
            {

                StorageFolder tempFolder = ApplicationData.Current.LocalFolder;
                StorageFile jpgFile = await tempFolder.CreateFileAsync(
                                    pdfFile + "-Page-" + i.ToString() + ".png",
                                    CreationCollisionOption.ReplaceExisting
                                    );

                var pdfPage = pdfFile.GetPage(i);

                if (jpgFile != null && pdfPage != null)
                {
                    IRandomAccessStream randomStream = await jpgFile.OpenAsync(FileAccessMode.ReadWrite);
                    await pdfPage.RenderToStreamAsync(randomStream);
                    await randomStream.FlushAsync();
                    randomStream.Dispose();
                    pdfPage.Dispose();
                }

                PdfImages.Add(jpgFile.Path);
            }

            this.pdfViewer.ItemsSource = PdfImages;

            TimeSpan processTime = DateTime.Now - startTime;
            Debug.WriteLine(processTime.TotalMilliseconds + " ms to process PDF");
        }

        public async Task DisplayImageFileAsync(StorageFile file)
        {
            // Display the image in the UI. 
            BitmapImage src = new BitmapImage();
            src.SetSource(await file.OpenAsync(FileAccessMode.Read));
            //Image1.Source = src;
        }
        [System.Obsolete("Method1 is deprecated, please use Method2 instead.")]
        private async void scrollViewer_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var doubleTapPoint = e.GetPosition(scrollViewer);

            if (scrollViewer.ZoomFactor != 1)
            {
                scrollViewer.ZoomToFactor(1);
            }
            else if (scrollViewer.ZoomFactor == 1)
            {
                scrollViewer.ZoomToFactor(2);

                var dispatcher = Window.Current.CoreWindow.Dispatcher;
                await dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    scrollViewer.ScrollToHorizontalOffset(doubleTapPoint.X);
                    scrollViewer.ScrollToVerticalOffset(doubleTapPoint.Y);
                });
            }
        }

        private void ChonCauA(object sender, RoutedEventArgs e)
        {
            var item = ((RadioButton)sender).DataContext;
            var container = (ListViewItem)quizlistview.ContainerFromItem(item);
            container.IsSelected = true;
            if (datalist[quizlistview.SelectedIndex].DapAnNguoiDung != "A")
                datalist[quizlistview.SelectedIndex].DapAnNguoiDung = "A";
            container.IsSelected = false;
        }

      

        private void ChonCauB(object sender, RoutedEventArgs e)
        {
            var item = ((RadioButton)sender).DataContext;
            var container = (ListViewItem)quizlistview.ContainerFromItem(item);
            container.IsSelected = true;
            if (datalist[quizlistview.SelectedIndex].DapAnNguoiDung != "B")
                datalist[quizlistview.SelectedIndex].DapAnNguoiDung = "B";
            container.IsSelected = false;
        }

        private void ChonCauC(object sender, RoutedEventArgs e)
        {
            var item = ((RadioButton)sender).DataContext;
            var container = (ListViewItem)quizlistview.ContainerFromItem(item);
            container.IsSelected = true;
            if (datalist[quizlistview.SelectedIndex].DapAnNguoiDung != "C")
                datalist[quizlistview.SelectedIndex].DapAnNguoiDung = "C";
            container.IsSelected = false;
        }

        private void ChonCauD(object sender, RoutedEventArgs e)
                {
                    var item = ((RadioButton)sender).DataContext;
                    var container = (ListViewItem)quizlistview.ContainerFromItem(item);
                    container.IsSelected = true;
                    if (datalist[quizlistview.SelectedIndex].DapAnNguoiDung != "D")
                        datalist[quizlistview.SelectedIndex].DapAnNguoiDung = "D";
                    container.IsSelected = false;
                }

        class ListOfDapAnNguoiDung
        {
            public string DapAnNguoiDung { get; set; }
        }

        ListOfDapAnNguoiDung[] datalist = new ListOfDapAnNguoiDung[50];
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        List<ServiceReference1.DapAnBoDe> DapAnList = new List<DapAnBoDe>();
        private async void SubmitBaiLam(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                if (datalist[i].DapAnNguoiDung == "0")
                {
                    var dialog = new MessageDialog("Xin hãy điền hết tất cả đáp án");
                    await dialog.ShowAsync();
                    return;
                }
            }
            var role = await db.GetDapAnAsync(FileName);
            MessageDialog message;
            if (role.Body.GetDapAnResult==null)
            {
                message = new MessageDialog("Nộp bài thất bại!");
                await message.ShowAsync();
                Frame.GoBack();
            }
            DapAnList = role.Body.GetDapAnResult.ToList<ServiceReference1.DapAnBoDe>();
            double DiemNguoiDung=0;
            for (int i = 0; i < 50; i++)
            {
                if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                    DiemNguoiDung += 0.2;
            }
            await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.BoDeObject.TenBoDe, "BoDe");
            await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "BoDe");
            message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung+"");
            await message.ShowAsync();
            LopThongTin.BoDeObject = null;
            quizlistview.ItemsSource = LamBoDeClassManager.GetData();
            Frame.GoBack();
        }

        private void flipviewchange(object sender, SelectionChangedEventArgs e)
        {
            txtblock.Text = (pdfViewer.SelectedIndex+1).ToString()+"/"+pagecount.ToString();   
        }
        
        private async void QuayLai(object sender, RoutedEventArgs e)
        {
            var showDialog = new MessageDialog("Bạn vẫn đang thi, bạn có chắc chắn muốn quay lại không?");
            showDialog.Commands.Add(new UICommand("Có") { Id = 0 });
            showDialog.Commands.Add(new UICommand("Không") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {

                LopThongTin.BoDeObject = null;
                quizlistview.ItemsSource = LamBoDeClassManager.GetData();
                Frame.GoBack();
            }

        }
    }
}

