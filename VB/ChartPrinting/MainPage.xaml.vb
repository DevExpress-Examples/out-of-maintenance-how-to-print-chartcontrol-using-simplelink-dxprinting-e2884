Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports DevExpress.Xpf.Printing

Namespace ChartPrinting
    Partial Public Class MainPage
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim sl As New SimpleLink()
            Dim model As New LinkPreviewModel(sl)
            sl.ExportServiceUri = "../ReportService1.svc"
            documentPreview1.Model = model
            sl.DetailCount = 1
            sl.DetailTemplate = CType(Resources("Data"), DataTemplate)
            AddHandler sl.CreateDetail, AddressOf sl_CreateDetail
            sl.CreateDocument(False)
            tabControl1.SelectedItem = tabItem2
            tabItem2.Visibility = Visibility.Visible
        End Sub

        Private Sub sl_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
            Dim wb As _
                New WriteableBitmap(CInt(Fix(chartControl1.ActualWidth)), CInt(Fix(chartControl1.ActualHeight)))

            wb.Render(chartControl1, New TranslateTransform())

            wb.Invalidate()
            e.Data = wb
        End Sub

        Private Sub tabItem1_GotFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
            tabItem2.Visibility = Visibility.Collapsed
            button1.IsEnabled = True
        End Sub

        Private Sub tabItem2_GotFocus_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            button1.IsEnabled = False
        End Sub

    End Class

End Namespace
