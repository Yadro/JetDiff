﻿using System;
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

namespace JetDiff
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var leftPath = LeftPath.Text;
            var rightPath = RightPath.Text;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "C:\\Program Files (x86)\\JetBrains\\PhpStorm 2016.3.3\\bin\\phpstorm64.exe",
                Arguments = $"diff {leftPath} {rightPath}"
            };
            Process.Start(startInfo);
        }
    }
}