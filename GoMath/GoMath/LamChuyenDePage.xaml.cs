using GoMath.ServiceReference1;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoMath
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LamChuyenDePage : Page
    {
        public LamChuyenDePage()
        {
            this.InitializeComponent();
            quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
            for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
            {
                datalist[i] = new ListOfDapAnNguoiDung();
                datalist[i].DapAnNguoiDung = "0";
            }
            LoadTrang();
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

        ListOfDapAnNguoiDung[] datalist = new ListOfDapAnNguoiDung[LopThongTin.ChuyenDePass.SoCau];
        DataControlServiceSoapClient db = new DataControlServiceSoapClient();
        List<ServiceReference1.DapAnChuyenDe> DapAnList = new List<DapAnChuyenDe>();
        private async void SubmitBaiLam(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
            {
                if (datalist[i].DapAnNguoiDung == "0")
                {
                    var dialog = new MessageDialog("Xin hãy điền hết tất cả đáp án");
                    await dialog.ShowAsync();
                    return;
                }
            }
            switch (LopThongTin.ChuyenDeCode)
            {         
                case "kshs":
                    {
                        MessageDialog message;
                        var role = await db.GetDapAnHamSoAsync(FileName,LopThongTin.ChuyenDePass.SoCau+1);
                        if (role.Body.GetDapAnHamSoResult == null)
                        {
                            message = new MessageDialog("Nộp bài thất bại!");
                            await message.ShowAsync();
                            Frame.GoBack();
                        }
                        DapAnList = role.Body.GetDapAnHamSoResult.ToList<ServiceReference1.DapAnChuyenDe>();
                        int count = 0;
                        for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
                        {
                            
                            if (datalist[i].DapAnNguoiDung == DapAnList[i+1].DapAn)
                            {
                                count++;
                            }
                        }                       
                        double temp =(double)10 /LopThongTin.ChuyenDePass.SoCau;
                        double DiemNguoiDung = count *temp;
                      DiemNguoiDung=  Math.Round(DiemNguoiDung, 1);
                        await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.ChuyenDePass.TenChuyenDe, "kshs");
                        await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "kshs");
                        message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                        await message.ShowAsync();
                        quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
                        Frame.GoBack();
                        break;
                    }
                case "luythua":
                    {
                        MessageDialog message;
                        var role = await db.GetDapAnLuyThuaAsync(FileName, LopThongTin.ChuyenDePass.SoCau+1);
                        if (role.Body.GetDapAnLuyThuaResult == null)
                        {
                            message = new MessageDialog("Nộp bài thất bại!");
                            await message.ShowAsync();
                            Frame.GoBack();
                        }
                        DapAnList = role.Body.GetDapAnLuyThuaResult.ToList<ServiceReference1.DapAnChuyenDe>();


                        int count = 0;
                        for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
                        {
                            if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                                count++;
                        }
                        double temp = (double)10 / LopThongTin.ChuyenDePass.SoCau;
                        double DiemNguoiDung = count * temp;
                        DiemNguoiDung = Math.Round(DiemNguoiDung, 1);
                        await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.ChuyenDePass.TenChuyenDe, "luythua");
                        await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "luythua");
                        message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                        await message.ShowAsync();
                        quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
                        Frame.GoBack();
                        break;
                    }
                case "tichphan":
                    {
                        MessageDialog message;
                        var role = await db.GetDapAnNguyenHamAsync(FileName, LopThongTin.ChuyenDePass.SoCau+1);
                        if (role.Body.GetDapAnNguyenHamResult == null)
                        {
                            message = new MessageDialog("Nộp bài thất bại!");
                            await message.ShowAsync();
                            Frame.GoBack();
                        }
                        DapAnList = role.Body.GetDapAnNguyenHamResult.ToList<ServiceReference1.DapAnChuyenDe>();
                        int count = 0;
                        for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
                        {
                            if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                                count++;
                        }
                        double temp = (double)10 / LopThongTin.ChuyenDePass.SoCau;
                        double DiemNguoiDung = count * temp;
                        DiemNguoiDung = Math.Round(DiemNguoiDung, 1);
                        await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.ChuyenDePass.TenChuyenDe, "tichphan");
                        await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "tichphan");
                        message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                        await message.ShowAsync();
                        quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
                        Frame.GoBack();
                        break;
                    }
                case "sophuc":
                    {
                        MessageDialog message;
                        var role = await db.GetDapAnSoPhucAsync(FileName, LopThongTin.ChuyenDePass.SoCau+1);
                        if (role.Body.GetDapAnSoPhucResult == null)
                        {
                            message = new MessageDialog("Nộp bài thất bại!");
                            await message.ShowAsync();
                            Frame.GoBack();
                        }
                        DapAnList = role.Body.GetDapAnSoPhucResult.ToList<ServiceReference1.DapAnChuyenDe>();
                        int count = 0;
                        for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
                        {
                            if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                                count++;
                         }
                        double temp = (double)10 / LopThongTin.ChuyenDePass.SoCau;
                        double DiemNguoiDung = count * temp;
                        DiemNguoiDung = Math.Round(DiemNguoiDung, 1);
                        await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.ChuyenDePass.TenChuyenDe, "sophuc");
                        await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "sophuc");
                        message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                        await message.ShowAsync();
                        quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
                        Frame.GoBack();
                        break;
                    }
                case "thetich":
                    {
                        MessageDialog message;
                        var role = await db.GetDapAnTheTichAsync(FileName, LopThongTin.ChuyenDePass.SoCau+1);
                        if (role.Body.GetDapAnTheTichResult == null)
                        {
                            message = new MessageDialog("Nộp bài thất bại!");
                            await message.ShowAsync();
                            Frame.GoBack();
                        }
                        DapAnList = role.Body.GetDapAnTheTichResult.ToList<ServiceReference1.DapAnChuyenDe>();
                        int count = 0;
                        for (int i = 0; i < LopThongTin.ChuyenDePass.SoCau; i++)
                        {
                            if (datalist[i].DapAnNguoiDung == DapAnList[i + 1].DapAn)
                                count++;
                        }
                        double temp = (double)10 / LopThongTin.ChuyenDePass.SoCau;
                        double DiemNguoiDung = count * temp;
                        DiemNguoiDung = Math.Round(DiemNguoiDung, 1);
                        await db.InsertLichSuLamBaiAsync(LopThongTin.loginUser.IDNguoiDung, DiemNguoiDung, DateTime.Now.ToString(" dd/MM/yyyy lúc HH:mm:ss"), LopThongTin.ChuyenDePass.TenChuyenDe, "thetich");
                        await db.CapNhatThongTinNguoiDungAsync(LopThongTin.loginUser.IDNguoiDung, "thetich");
                        message = new MessageDialog("Chúc mừng bạn đã hoàn thành bài thi! Điểm của bạn là:" + DiemNguoiDung + "");
                        await message.ShowAsync();
                        quizlistview.ItemsSource = LamChuyenDePageClassManager.Get();
                        Frame.GoBack();

                        break;
                    }
                default:
                    break;
            }
        }
        uint pagecount = 0;
        private void flipviewchange(object sender, SelectionChangedEventArgs e)
        {
            txtblock.Text = (pdfViewer.SelectedIndex + 1).ToString() + "/" + pagecount.ToString();
        }
        string FileName = LopThongTin.ChuyenDePass.Title;
        public ObservableCollection<string> PdfImages = new ObservableCollection<string>();
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
                quizlistview.ItemsSource = LamBoDeClassManager.GetData();
                Frame.GoBack();
            }
        }
    }
}
