using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace ChineseCharacter2GB2312Code
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static TransformArray tfr = new TransformArray();
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = tfr.Item;
        }
        private void appendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tfr.Add(contentText.Text, nameText.Text);

                nameText.Text += Guid.NewGuid().ToString("N").Substring(0,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(tfr.ToString());
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            tfr.Clear();
        }

        private void listBox_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            tfr.RemoveAt(listBox.SelectedIndex);
        }
    }
}
