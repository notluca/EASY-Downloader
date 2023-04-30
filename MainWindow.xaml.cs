using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace EASY__Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();
        }
        #endregion

        #region FixScaling
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double fontSize = width / 76;
            double fontSize2 = width / 96;

            IEnumerable<Label> allLabels = GetAllLabels(this);
            IEnumerable<Button> allButtons = GetAllButtons(this);

            foreach (Label label in allLabels)
            {
                label.FontSize = fontSize;
            }

            foreach (Button button in allButtons)
            {
                button.FontSize = fontSize2;
            }
        }

        #endregion

        #region InitalizeApp Function
        void InitializeApp()
        {

        }
        #endregion

        #region getElements
        private List<Label> GetAllLabels(DependencyObject parent)
        {
            var labels = new List<Label>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Label label)
                {
                    labels.Add(label);
                }
                else
                {
                    labels.AddRange(GetAllLabels(child));
                }
            }
            return labels;
        }

        private List<Button> GetAllButtons(DependencyObject parent)
        {
            var buttons = new List<Button>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Button btn)
                {
                    buttons.Add(btn);
                }
                else
                {
                    buttons.AddRange(GetAllButtons(child));
                }
            }
            return buttons;
        }
        #endregion


    }
}
