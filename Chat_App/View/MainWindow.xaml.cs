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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat_App
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
        private void TxtBox_NickName_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if(TxtBox_NickName.Text == "Enter Your Username:")
                TxtBox_NickName.Text = "";
        }

        private void Btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //private void TxtBox_NickName_LostMouseCapture(object sender, MouseEventArgs e)
        //{
        //    if(String.IsNullOrWhiteSpace(TxtBox_NickName.Text))
        //        TxtBox_NickName.Text = "Enter your username";
        //}
    }
}