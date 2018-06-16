using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// FrmTest.xaml 的交互逻辑
    /// </summary>
    public partial class FrmTest : Window
    {
        Dictionary<double, double> KeyValue;
        public FrmTest()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((LineSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<double, double>[]{
                new KeyValuePair < double, double > ( 27.5 , -9 ),
                new KeyValuePair < double, double > ( 28.0 , -8 ),
                new KeyValuePair < double , double > ( 28.5, -7 ),
                new KeyValuePair < double , double > ( 29.0, -6 )
        };
        }
    }
}
