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
    public sealed partial class XemLyThuyetPage : Page
    {
        public XemLyThuyetPage()
        {
            this.InitializeComponent();
            LoadTrang();
        }

        private void flipviewchange(object sender, SelectionChangedEventArgs e)
        {
            txtblock.Text = (pdfViewer.SelectedIndex + 1).ToString() + "/" + pagecount.ToString();
        }

        string FileName = LopThongTin.LyThuyetCode;
        public ObservableCollection<string> PdfImages = new ObservableCollection<string>();
        //Load de 
        uint pagecount = 0;
        private async void LoadTrang()
        {
            DateTime startTime = DateTime.Now;
            if (PdfImages == null)
                PdfImages = new ObservableCollection<string>();
            PdfImages.Clear();
     
            Uri fileTarget = new Uri(@"ms-appx:///KhoLyThuyet/" + FileName + ".pdf");
            var file = await Package.Current.InstalledLocation.GetFileAsync(@"KhoLyThuyet\" + FileName + ".pdf");
            var pdfFile = await PdfDocument.LoadFromFileAsync(file);
            if (pdfFile == null)
                return;
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

        private void QuayLai(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
