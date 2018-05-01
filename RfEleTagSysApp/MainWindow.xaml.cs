using System;
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
using RfEleTagSysApp.HAL;
using RfEleTagSysApp.Controller;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Controller.Impl;
using RfEleTagSysApp.Pages;

namespace RfEleTagSysApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserForm currentUser = null;
        public Page indexPage = null;
        public StaticTextResource_zh_CN resource = new StaticTextResource_zh_CN();

        public MainWindow()
        {
            InitializeComponent();
            currentUser = new UserForm();
        }

        public MainWindow(UserForm user)
        {
            InitializeComponent();
            currentUser = user;
            if( user.Name != "" )
            {
                Title = "当前用户 : " + user.Name;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TakeMedicinePage page = new TakeMedicinePage();
            indexPage = new NavigationPage(this);
            ContentControl.Content = new Frame {
                Content = indexPage
            };
        }

        public void changePage(Page page)
        {
            ContentControl.Content = new Frame
            {
                Content = page
            };
        }
    }
}
