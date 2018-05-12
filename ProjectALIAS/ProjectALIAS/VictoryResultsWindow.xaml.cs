using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectALIAS
{
    /// <summary>
    /// Interaction logic for VictoryResultsWindow.xaml
    /// </summary>
    public partial class VictoryResultsWindow : Window
    {
        public VictoryResultsWindow()
        {
            InitializeComponent();
        }
        public void mainMenu(object sender, EventArgs e)
        {
            MainWindow w1 = new MainWindow();
            w1.Show();
            Close();
        }
    }
}
