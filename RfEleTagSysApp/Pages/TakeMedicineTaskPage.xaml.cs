using RfEleTagSysApp.Controller;
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
    /// TakeMedicineTaskPage.xaml 的交互逻辑
    /// </summary>
    public partial class TakeMedicineTaskPage : Page
    {

        private MainWindow parentWindow;
        private Page lastPage;
        private TakeMedicineTaskController taskController;

        public TakeMedicineTaskPage(MainWindow parent, Page last)
        {
            InitializeComponent();
            parentWindow = parent;
            lastPage = last;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btn_indexPage.Content = parentWindow.resource.IndexPage;
            btn_lastPage.Content = parentWindow.resource.LastPage;
            btn_executeTask.Content = parentWindow.resource.ExecuteTask;


            taskController = new TakeMedicineTaskController();
            List<TakeMedicineTask> list = taskController.findListByOperatorId(parentWindow.currentUser.Id);
            dg_taskList.ItemsSource = list;
        }

        private void btn_indexPage_Click(object sender, RoutedEventArgs e)
        {
            //回到首页
            if (parentWindow != null)
            {
                if (parentWindow.indexPage != null)
                    parentWindow.changePage(parentWindow.indexPage);
                else
                {
                    NavigationPage page = new NavigationPage(parentWindow);
                    parentWindow.changePage(page);
                }
            }
            else
            {
                MessageBox.Show(parentWindow.resource.SystemError);
            }
        }

        private void btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            //回到上一页
            if (parentWindow != null)
            {
                parentWindow.changePage(lastPage);
            }
            else
            {
                MessageBox.Show(parentWindow.resource.SystemError);
            }
        }

        private void btn_executeTask_Click(object sender, RoutedEventArgs e)
        {
            if (dg_taskList.SelectedItem != null)
            {
                //进入取药界面
                if (parentWindow != null)
                {
                    TakeMedicinePage page = new TakeMedicinePage(parentWindow, this, (TakeMedicineTask)dg_taskList.SelectedItem);
                    parentWindow.changePage(page);
                }
                else
                {
                    MessageBox.Show(parentWindow.resource.SystemError);
                }
            }
            else
            {
                MessageBox.Show(parentWindow.resource.PleaseSelectAtLeaseOneTask);
            }
        }
    }
}
