﻿using System;
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

namespace JustDrag
{
    /// <summary>
    /// Controller.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Controller : Window
    {
        public Controller()
        {
            InitializeComponent();
        }

        private void btnCaptureClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
            MessageBox.Show("야호");
        }
    }
}