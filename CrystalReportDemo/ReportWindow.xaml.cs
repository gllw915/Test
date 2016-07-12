using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReportDemo
{
    /// <summary>
    /// ReportWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReportWindow : Window
    {
        public static MainWindow mainWindow = null;
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbItem = (ComboBoxItem)(mainWindow.cb_SelectDateTime.ItemContainerGenerator.ContainerFromIndex(mainWindow.cb_SelectDateTime.SelectedIndex)) ;
            string selectResult = ((Label)(cbItem.Content)).Content.ToString();
            DBDataSetTableAdapters.tbReport1TableAdapter ta = new DBDataSetTableAdapters.tbReport1TableAdapter();
            DataTable dt = ta.GetReportWithEmptyTimestamp(DateTime.Parse(selectResult));


            //ReportDocument reportDocment = new ReportDocument();
            //string reportPath = System.Threading.Thread.GetDomain().BaseDirectory + "CrystalReport1.rpt";
            //string reportPath = @"E:\Code\VS2010\CrystalReportDemo\CrystalReportDemo\CrystalReport1.rpt" ; 
            //reportDocment.Load(reportPath);
            //reportDocment.SetDataSource(dt);

            CrystalReport1 reportDocment = new CrystalReport1();
            reportDocment.SetDataSource(dt);
            crystalReportsViewer1.ViewerCore.ReportSource = reportDocment;
        }
    }
}
