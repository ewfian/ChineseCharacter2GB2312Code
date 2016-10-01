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
        public MainWindow()
        {
            InitializeComponent();
        }

        static StringBuilder allItem = new StringBuilder();
        static HashSet<string> nameSet = new HashSet<string>();
        private void appendButton_Click(object sender, RoutedEventArgs e)
        {
            var name = nameText.Text;

            if (!Regex.IsMatch(name, "^[a-zA-Z_][a-zA-Z0-9_]*$"))
            {
                MessageBox.Show("Illegal array name");
                return;
            }

            if (nameSet.Contains(name))
            {
                MessageBox.Show("Array name already exists");
                return;
            }
            else
            {
                nameSet.Add(name);
            }

            var item = Transform(contentText.Text, name);
            allItem.Append(item + Environment.NewLine);
            listBox.Items.Add(item);
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(allItem.ToString());
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            allItem.Clear();
            listBox.Items.Clear();
        }

        private void listBox_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private static StringBuilder Transform(string _stringArray, string _arrayName)
        {
            var tansformBuilder = new StringBuilder();
            var inputArrays = Encoding.Default.GetBytes(_stringArray);

            tansformBuilder.Append("unsigned char " + _arrayName + "[]={" + Environment.NewLine);

            for (int i = 0; i < inputArrays.Length; i++)
            {
                tansformBuilder.Append("  ");
                if (inputArrays[i] >= 128 && inputArrays[i] <= 247)
                {
                    tansformBuilder.Append(string.Format(@"0x{0},0x{1}",
                        Convert.ToString(inputArrays[i], 16).ToUpper(), Convert.ToString(inputArrays[i + 1], 16).ToUpper()));
                    i++;
                }
                else
                {
                    tansformBuilder.Append(string.Format("0x{0},0x00",
                        Convert.ToString(inputArrays[i], 16).ToUpper()));
                }
                if (i < inputArrays.Length - 1)
                {
                    tansformBuilder.Append("," + Environment.NewLine);
                }
                else
                {
                    tansformBuilder.Append(Environment.NewLine);
                }
            }
            tansformBuilder.Append("};\t//" + _stringArray + Environment.NewLine);

            return tansformBuilder;
        }
    }
}
