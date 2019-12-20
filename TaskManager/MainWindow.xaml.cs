using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Processes = Process.GetProcesses();
            dataGrid.ItemsSource = Processes;
        }

        private void CloseProcessButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var thisProcess = (Process)dataGrid.SelectedItem;
                thisProcess.Kill();
                dataGrid.ItemsSource = null;
                var Processes = Process.GetProcesses();
                dataGrid.ItemsSource = Processes;
            }
            catch
            {
                MessageBox.Show("Отказано в доступе");
            }         
        }
    }
}
