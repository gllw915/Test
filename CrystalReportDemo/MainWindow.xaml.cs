using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrystalReportDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public CrystalReport1 _reportDocment;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBDataSetTableAdapters.tbReportTableAdapter ta= new DBDataSetTableAdapters.tbReportTableAdapter();
            DataTable dt = ta.GetExistEmptyTimestamp();

            if (dt != null)
            {
                int i = 0;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    Label label = new Label();
                    label.Content = dr["EmptyTimestamp"].ToString();
                    ComboBoxItem cbItem = new ComboBoxItem();
                    cbItem.Content = label;
                    cbItem.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
                    cb_SelectDateTime.Items.Add(cbItem);
                }
                //ComboBoxItem cbi = (ComboBoxItem)(this.cb_SelectDateTime.ItemContainerGenerator.ContainerFromIndex(i));
                //cbi.IsSelected = true;
                this.cb_SelectDateTime.SelectedIndex = 2;
                this._reportDocment = new CrystalReport1();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbItem = (ComboBoxItem)this.cb_SelectDateTime.Items[this.cb_SelectDateTime.SelectedIndex];//(ComboBoxItem)(this.cb_SelectDateTime.ItemContainerGenerator.ContainerFromIndex(this.cb_SelectDateTime.SelectedIndex)) ;
            string selectResult = ((Label)(cbItem.Content)).Content.ToString();
            DBDataSetTableAdapters.tbReport1TableAdapter ta = new DBDataSetTableAdapters.tbReport1TableAdapter();
            DataTable dt = ta.GetReportWithEmptyTimestamp(DateTime.Parse(selectResult));

            this._reportDocment.SetDataSource(dt);
            crystalReportsViewer1.ViewerCore.ReportSource = this._reportDocment;
            //ReportWindow.mainWindow = this;
            //ReportWindow reportWindow = new ReportWindow();
            //reportWindow.Show();
        }
    }
}
