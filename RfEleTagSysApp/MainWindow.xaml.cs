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
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;

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
        public EleTagController eleTagController = new EleTagControllerImpl();
        private AddressMappingDAL addressMappingDAL = new AddressMappingDALImpl();

        private void EleTagResponseHandler(int guid, EleTagResponseState state, string msg)
        {
        }

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
            //1 清空AddressMapping中的数据
            if (!addressMappingDAL.empty())
            {
                MessageBox.Show(resource.AddressMappingEmptyFailed);
            }
            //2 添加空Handler
            eleTagController.setEleTagResponseHandler(EleTagResponseHandler);
            //3 根据数据中保存的配置，打开串口
            if ( !eleTagController.openSerial())
            {
                MessageBox.Show(resource.ConfigSerialPortWithOpenSerialFailed);
            }
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
