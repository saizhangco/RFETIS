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
    /// TakeMedicinePage.xaml 的交互逻辑
    /// </summary>
    public partial class AddMedicinePage : Page
    {
        private MainWindow parentWindow;
        private Page lastPage;
        private AddMedicineTask task;

        public AddMedicinePage(MainWindow parent, Page last, AddMedicineTask task)
        {
            InitializeComponent();
            parentWindow = parent;
            lastPage = last;
            this.task = task;
        }

        private StaticTextResource_zh_CN resource = new StaticTextResource_zh_CN();
        private List<MedicineForm> list = new List<MedicineForm>();
        private EleTagController eleTagController = new EleTagControllerImpl();
        private AddMedicineTaskItemDAL taskItemDAL = new AddMedicineTaskItemDALImpl();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //l_refreshSerial.Content = resource.Port;
            //btn_serialOperate.Content = resource.Open;
            //btn_refreshSerial.Content = resource.Refresh;
            btn_lastPage.Content = resource.LastPage;
            btn_indexPage.Content = resource.IndexPage;
            btn_addMedicines.Content = resource.StartAddMedicine;
            parentWindow.eleTagController.setEleTagResponseHandler(EleTagResponseHandler);

            //list.Add(new MedicineForm() { Name = "安定", Amount = 10, Guid = 1, Address = "", State = 0 });
            //list.Add(new MedicineForm() { Name = "阿司匹林", Amount = 20, Guid = 2, Address = "", State = 0 });
            //list.Add(new MedicineForm() { Name = "咳必清", Amount = 17, Guid = 3, Address = "", State = 0 });
            //list.Add(new MedicineForm() { Name = "必咳平", Amount = 5, Guid = 4, Address = "", State = 0 });
            List<AddMedicineTaskItem> itemList = taskItemDAL.findListByTakeId(task.Id);
            foreach( AddMedicineTaskItem item in itemList )
            {
                list.Add(new MedicineForm()
                {
                    Name = item.Medicine.Name,
                    Amount = item.Amount,
                    Guid = item.Medicine.Address.Guid,
                    Address = item.Medicine.Address.Addr,
                    State = item.State
                });
            }
            dg_medicineList.ItemsSource = list;


            List<string> serialList = eleTagController.getSerialList();
            if (serialList == null)
            {
                MessageBox.Show(resource.GetSerialListError);
            }
            else
            {
                /*
                cb_serialList.ItemsSource = serialList;
                if (serialList.Count > 0)
                {
                    cb_serialList.Text = serialList[0];
                }*/
            }
        }

        private void EleTagResponseHandler(int guid, EleTagResponseState state, string msg)
        {
            switch (state)
            {
                case EleTagResponseState.ADDRESS:
                    //更新到list中
                    foreach (MedicineForm form in list)
                    {
                        if (form.Guid == guid)
                        {
                            form.Address = msg;
                            break;
                        }
                    }
                    break;
                case EleTagResponseState.ADDING:
                    //更新到list中
                    foreach (MedicineForm form in list)
                    {
                        if (form.Guid == guid)
                        {
                            form.Request = resource.AddMedicine + resource.RequestCompleted;
                            break;
                        }
                    }
                    break;
                case EleTagResponseState.ADDING_ERROR:
                    //更新到list中
                    foreach (MedicineForm form in list)
                    {
                        if (form.Guid == guid)
                        {
                            form.Request = resource.AddMedicine + resource.RequestError;
                            break;
                        }
                    }
                    break;
                case EleTagResponseState.ADD_QUERY:
                    //更新到list中
                    foreach (MedicineForm form in list)
                    {
                        if (form.Guid == guid)
                        {
                            form.Query = resource.AddMedicine + resource.QueryStart;
                            break;
                        }
                    }
                    break;
                case EleTagResponseState.ADDED:
                    //更新到list中
                    foreach (MedicineForm form in list)
                    {
                        if (form.Guid == guid)
                        {
                            form.Query = resource.AddMedicine + resource.QueryCompleted;
                            break;
                        }
                    }
                    break;
            }
        }

        private void btn_refreshSerial_Click(object sender, RoutedEventArgs e)
        {
            /*
            if ((string)btn_serialOperate.Content == resource.Open)
            {
                List<string> serialList = eleTagController.getSerialList();
                if (serialList == null)
                {
                    MessageBox.Show(resource.GetSerialListError);
                }
                else
                {
                    cb_serialList.ItemsSource = serialList;
                    cb_serialList.Text = "";
                }
            }
            else
            {
                MessageBox.Show(resource.RefreshAfterCloseSerialPort);
            }*/
        }

        private void btn_serialOperate_Click(object sender, RoutedEventArgs e)
        {
            /*
            if ((string)btn_serialOperate.Content == resource.Open)
            {
                if (cb_serialList.Text == "")
                {
                    MessageBox.Show(resource.SelectSerialPortTip);
                    return;
                }
                if (!eleTagController.openSerial(cb_serialList.Text))
                {
                    MessageBox.Show(resource.OpenSerialPortFailed);
                    return;
                }
                btn_serialOperate.Content = resource.Close;
            }
            else if ((string)btn_serialOperate.Content == resource.Close)
            {
                eleTagController.closeSerial();
                btn_serialOperate.Content = resource.Open;
            }*/
        }

        private void btn_takeMedicines_Click(object sender, RoutedEventArgs e)
        {
            foreach (MedicineForm form in list)
            {
                if (form.Address != "")
                {
                    form.Request = resource.TakeMedicine + resource.RequestSending;
                    parentWindow.eleTagController.addMedicine(form.Guid, form.Address, form.Amount);
                }
                else
                {
                    form.Request = resource.TakeMedicine + resource.RequestNoAddress;
                }
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
    }
}
