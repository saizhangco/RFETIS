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
    /// NavigationPage.xaml 的交互逻辑
    /// </summary>
    public partial class NavigationPage : Page
    {
        private MainWindow parent;

        public NavigationPage(MainWindow parentWindow)
        {
            InitializeComponent();
            parent = parentWindow;

            if( parent.currentUser != null )
            {
                tb_currentUser.Text = parent.currentUser.Name + " : " + parent.currentUser.Role.Name;

                string roleName = parent.currentUser.Role.Name;
                if( roleName == "DOCTOR" || roleName == "NURSE" || roleName == "PHARM")
                {
                    btn_systemSettings.IsEnabled = false;
                }
                else if( roleName == "ITSUP")
                {
                    btn_takeMedicineTask.IsEnabled = false;
                    btn_addMedicineTask.IsEnabled = false;
                    btn_previewTask.IsEnabled = false;
                    btn_medicineInfo.IsEnabled = false;
                }
            }
            else
            {
                btn_logout.IsEnabled = false;
            }
        }

        private void btn_takeMedicineTask_Click(object sender, RoutedEventArgs e)
        {
            TakeMedicineTaskPage page = new TakeMedicineTaskPage(parent, this);
            if ( parent != null )
            {
                parent.changePage(page);
            }
            else
            {
                MessageBox.Show(parent.resource.SystemError);
            }
        }

        private void btn_addMedicineTask_Click(object sender, RoutedEventArgs e)
        {
            AddMedicineTaskPage page = new AddMedicineTaskPage(parent, this);
            if (parent != null)
            {
                parent.changePage(page);
            }
            else
            {
                MessageBox.Show(parent.resource.SystemError);
            }
        }

        private void btn_previewTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_medicineInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_systemSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_communicationSettings_Click(object sender, RoutedEventArgs e)
        {
            CommunicationSettingPage page = new CommunicationSettingPage(parent, this);
            if (parent != null)
            {
                parent.changePage(page);
            }
            else
            {
                MessageBox.Show(parent.resource.SystemError);
            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            //1 关闭串口
            parent.eleTagController.closeSerial();
            LoginWindow window = new LoginWindow();
            window.Show();
            parent.Close();
        }
    }
}
