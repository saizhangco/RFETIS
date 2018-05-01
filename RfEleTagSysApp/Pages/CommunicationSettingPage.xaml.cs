using RfEleTagSysApp.Controller;
using RfEleTagSysApp.Controller.Impl;
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
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

namespace RfEleTagSysApp.Pages
{
    /// <summary>
    /// CommunicationSettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class CommunicationSettingPage : Page
    {
        private MainWindow parentWindow;
        private Page lastPage;

        private EleTagController etController = new EleTagControllerImpl();
        private SerialConfigDAL serialConfig = new SerialConfigDALImpl();

        private SerialConfig config = new SerialConfig();

        public CommunicationSettingPage(MainWindow parent, Page last)
        {
            InitializeComponent();
            parentWindow = parent;
            lastPage = last;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            l_portName.Content = parentWindow.resource.PortName;
            l_baudRate.Content = parentWindow.resource.BaudRate;
            l_dataBits.Content = parentWindow.resource.DataBits;
            l_parity.Content = parentWindow.resource.Parity;
            l_stopBits.Content = parentWindow.resource.StopBits;

            //端口号
            List<string> portList = etController.getSerialList();
            cb_portList.ItemsSource = portList;
            //波特率
            List<string> baudRateList = new List<string>() {
                "9600","19200","38400","115200"
            };
            cb_baudRateList.ItemsSource = baudRateList;
            //数据位
            List<string> dataBitsList = new List<string>() {
                "5","6","7","8"
            };
            cb_dataBitsList.ItemsSource = dataBitsList;
            //校验位
            List<string> parityList = new List<string>() {
                "None","Even","Odd","Mark","Space"
            };
            cb_parityList.ItemsSource = parityList;
            //停止位
            List<string> stopBitsList = new List<string>() {
                "1","1.5","2"
            };
            cb_stopBitsList.ItemsSource = stopBitsList;

            config = serialConfig.get();
            //g_config.DataContext = config;
            
            if (config.PortName != "")
            {
                cb_portList.Text = config.PortName;
            }
            if (config.BaudRate > 0 )
            {
                cb_baudRateList.Text = config.BaudRate.ToString();
            }
            if (config.DataBits > 0 )
            {
                cb_dataBitsList.Text = config.DataBits.ToString();
            }
            if (config.Parity != "")
            {
                cb_parityList.Text = config.Parity;
            }
            if (config.StopBits != "")
            {
                cb_stopBitsList.Text = config.StopBits;
            }
            
        }

        private void btn_saveConfig_Click(object sender, RoutedEventArgs e)
        {
            //SerialConfig config = new FormModel.SerialConfig();
            config.PortName = cb_portList.Text;
            config.StopBits = cb_stopBitsList.Text;

            if( serialConfig.update(config) )
            {
                MessageBox.Show("配置保存成功");
            }
            else
            {
                MessageBox.Show("配置保存失败");
            }
        }
    }
}
