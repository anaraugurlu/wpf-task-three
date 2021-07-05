using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace wpf_task_three
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Cutbtn_Click(object sender, RoutedEventArgs e)
        {
            if (all.Text != null)
            {
                all.Cut();
            }
        }

        private void Pastebtn_Click(object sender, RoutedEventArgs e)
        {
            if (all.Text != null)
            {
                all.Paste();
            }
        }

        private void Copybtn_Click(object sender, RoutedEventArgs e)
        {
            if (all.Text != null)
            {
                all.Copy();
            }
        }

        private void SelectAllbtn_Click(object sender, RoutedEventArgs e)
        {


            all.SelectAll();
            all.Focus();

        }
        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            using (StreamWriter streamWriter = new StreamWriter(Name))
            {
                streamWriter.Write(all.Text);
            }
        }
        public string Name { get; set; }

        private void Openbtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();



            if (open.ShowDialog() == true)
            {
                using (StringReader reader = new StringReader(open.FileName))
                {
                    Name = open.FileName;
                    text.Text = reader.ReadToEnd();
                    all.Text = File.ReadAllText(text.Text);


                }
            }
            foreach (var item in mystack.Children)
            {
                if (item is Button bt)
                {
                    bt.IsEnabled = true;
                }
            }
        }

        private void all_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (togglesw.Toggled1 == true)
            {
                SaveFileDialog save = new SaveFileDialog();

                using (StreamWriter streamWriter = new StreamWriter(Name))
                {
                    streamWriter.Write(all.Text);
                }
            }
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

    
