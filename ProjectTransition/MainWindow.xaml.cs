using ProjectTransition.src;
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

namespace ProjectTransition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Transition transition;

        public MainWindow()
        {
            InitializeComponent();
            transition = new Transition();
        }

        private void FileASelect_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    FileNameA.Text = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    FileNameA.Text = "";
                    break;
            }
        }
        
        private void FileBSelect_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    FileNameB.Text = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    FileNameB.Text = "";
                    break;
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            List<String> l = transition.readTables(FileNameA.Text, FileNameB.Text, FileNameOutput.Text);
            String ostring = "";
            foreach (String s in l)
            {
                ostring += s + " ";
            }
            OutputLabel.Content = ostring;
            */
            transition.readTables(FileNameA.Text, FileNameB.Text, FileNameOutput.Text);
        }

        private void FileOutSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    FileNameOutput.Text = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    FileNameOutput.Text = "";
                    break;
            }
        }
    }
}
