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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;


namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void OpenFile(object sender, RoutedEventArgs e)
        {
            
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.OpenFile() != null)
                    {
                        TextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        public void SaveTextAsFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.InitialDirectory = "c:\\";
            SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            SaveFileDialog1.FilterIndex = 2;
            SaveFileDialog1.RestoreDirectory = true;
            if (SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string TextFromBox = TextBox1.Text;
                    File.WriteAllText(SaveFileDialog1.FileName, TextFromBox);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not save file on the disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
