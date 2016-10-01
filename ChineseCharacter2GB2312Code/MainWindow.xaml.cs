using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            var itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(listbox_Drop)));
            listBox.ItemContainerStyle = itemContainerStyle;
        }

        void s_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                var draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        void listbox_Drop(object sender, DragEventArgs e)
        {
            var droppedData = e.Data.GetData(typeof(TransformItem)) as TransformItem;
            var target = ((ListBoxItem)(sender)).DataContext as TransformItem;

            var removedIdx = listBox.Items.IndexOf(droppedData);
            var targetIdx = listBox.Items.IndexOf(target);

            if (removedIdx < targetIdx)
            {
                tfr.Item.Insert(targetIdx + 1, droppedData);
                tfr.Item.RemoveAt(removedIdx);
            }
            else
            {
                var remIdx = removedIdx + 1;
                if (tfr.Item.Count + 1 > remIdx)
                {
                    tfr.Item.Insert(targetIdx, droppedData);
                    tfr.Item.RemoveAt(remIdx);
                }
            }
        }

        private void appendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tfr.Add(contentText.Text, nameText.Text);
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
            if (listBox.Items.Count > 0 && listBox.SelectedIndex > -1)
            {
                tfr.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void clearButton_Drop(object sender, DragEventArgs e)
        {
            var droppedData = e.Data.GetData(typeof(TransformItem)) as TransformItem;
            var removedIdx = listBox.Items.IndexOf(droppedData);
            tfr.RemoveAt(removedIdx);
        }
    }
}
