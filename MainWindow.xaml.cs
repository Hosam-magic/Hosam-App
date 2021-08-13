﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using Hosam_App.FrontEnd;
using Hosam_App.FrontEnd.Game;
using Hosam_App.FrontEnd.HomePage;

namespace Hosam_App
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MinimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;
            MaxmizeButton.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            CloseButton.Click += (s, e) => Close();

        }


        public void Window_Loaded(Object sender ,RoutedEventArgs e) 
        {
            

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            // 用xname 取得frame :
            Frame frame = (Frame)mainWindow.FindName("test");
            // frame 用  Navigate
            frame.Navigate(new HomePage());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            // 用xname 取得frame :
            Frame frame = (Frame)mainWindow.FindName("test");
            // frame 用  Navigate
            frame.Navigate(new HomePage());
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            // 用xname 取得frame :
            Frame frame = (Frame)mainWindow.FindName("test");
            // frame 用  Navigate
            frame.Navigate(new SideBar());
        }
    }

}
