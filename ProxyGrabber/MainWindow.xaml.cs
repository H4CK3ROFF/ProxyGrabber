using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProxyGrabber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Variables
        
        private SolidColorBrush _titleButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF202020"));
        private SolidColorBrush _titleButtonClickDown = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5D5D5D"));
        private SolidColorBrush _titleButtonMouseEnter = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF383838"));
        private SolidColorBrush _titleCloseButtonClickDown = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));

        private SolidColorBrush _proxyButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF111111"));
        private SolidColorBrush _proxyButtonClickDown = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        private SolidColorBrush _proxyButtonMouseEnter = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF212121"));

        private Grabber _grabber = new Grabber();

        #endregion


        #region Title
        private void TitleBoardClickDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }
        #endregion


        #region MinimizeButton
        private void MinimizeButtonClickUp(object sender, RoutedEventArgs e)
        {
            MinimizeButton.Background = _titleButton;
            this.WindowState = WindowState.Minimized;
        }

        private void MinimizeButtonClickDown(object sender, RoutedEventArgs e)
        {
            MinimizeButton.Background = _titleButtonClickDown;
        }

        private void MinimizeButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            MinimizeButton.Background = _titleButtonMouseEnter;
        }

        private void MinimizeButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            MinimizeButton.Background = _titleButton;
        }
        #endregion


        #region CloseButton
        private void CloseButtonClickUp(object sender, RoutedEventArgs e)
        {
            CloseButton.Background = _titleButton;
            this.Close();
        }

        private void CloseButtonClickDown(object sender, RoutedEventArgs e)
        {
            CloseButton.Background = _titleCloseButtonClickDown;
        }

        private void CloseButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            CloseButton.Background = _titleButtonMouseEnter;
        }

        private void CloseButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            CloseButton.Background = _titleButton;
        }
        #endregion


        #region GetProxyButton
        private void GetProxyButtonClickUp(object sender, RoutedEventArgs e)
        {
            GetProxyButton.Background = _proxyButton;
            _grabber.setProxy += SetProxy;
            new Thread(() => _grabber.GetProxy()).Start();
        }

        private void GetProxyButtonClickDown(object sender, RoutedEventArgs e)
        {
            GetProxyButton.Background = _proxyButtonClickDown;
        }

        private void GetProxyButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            GetProxyButton.Background = _proxyButtonMouseEnter;
        }

        private void GetProxyButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            GetProxyButton.Background = _proxyButton;
        }
        #endregion


        #region SaveProxyButton
        private void SaveProxyButtonClickUp(object sender, RoutedEventArgs e)
        {
            SaveProxyButton.Background = _proxyButton;
            SaveProxy();
        }

        private void SaveProxyButtonClickDown(object sender, RoutedEventArgs e)
        {
            SaveProxyButton.Background = _proxyButtonClickDown;
        }

        private void SaveProxyButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            SaveProxyButton.Background = _proxyButtonMouseEnter;
        }

        private void SaveProxyButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            SaveProxyButton.Background = _proxyButton;
        }
        #endregion


        #region UpdateProxyList

        private void SetProxy(string data)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => ProxyList.Text = data));
        }

        #endregion


        #region SaveProxy
        private void SaveProxy()
        {
            string fileText = ProxyList.Text;
            SaveFileDialog dialog = new SaveFileDialog() { Filter = "Text Files(*.txt)|*.txt|All(*.*)|*" };
            if (dialog.ShowDialog() == true)
                File.WriteAllText(dialog.FileName, fileText);
        }
        #endregion



        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
