using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Printing;

namespace ChartPrinting {
    public partial class MainPage : UserControl {
        public MainPage () {
            InitializeComponent();
        }

        private void button1_Click (object sender, RoutedEventArgs e) {
            SimpleLink sl = new SimpleLink();
            LinkPreviewModel model = new LinkPreviewModel(sl);
            sl.ExportServiceUri = "../ReportService1.svc";
            documentPreview1.Model = model;
            sl.DetailCount = 1;
            sl.DetailTemplate = (DataTemplate)Resources["Data"];
            sl.CreateDetail += sl_CreateDetail;
            sl.CreateDocument(false);
            tabControl1.SelectedItem = tabItem2;
            tabItem2.Visibility = Visibility.Visible;
        }

        void sl_CreateDetail (object sender, CreateAreaEventArgs e) {
            WriteableBitmap wb = 
                new WriteableBitmap((int)chartControl1.ActualWidth, (int)chartControl1.ActualHeight);

            wb.Render(chartControl1, new TranslateTransform());

            wb.Invalidate();
            e.Data = wb;
        }

        private void tabItem1_GotFocus (object sender, RoutedEventArgs e) {
            tabItem2.Visibility = Visibility.Collapsed;
            button1.IsEnabled = true;
        }

        private void tabItem2_GotFocus_1 (object sender, RoutedEventArgs e) {
            button1.IsEnabled = false;
        }

    }
}
