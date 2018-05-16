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
using System.Windows.Shapes;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Controller;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserController userController = new UserController();

        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //窗口最大化
            WindowState = WindowState.Maximized;
            User user = new User();
            g_login.DataContext = user;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(tb_username.Text + "    " + tb_password.Password);
            int loginResult = userController.login(tb_username.Text, tb_password.Password);
            if (loginResult == 0)
            {
                //登录成功跳转到导航页面
                //MessageBox.Show("登录成功");
                User user = userController.findUserByName(tb_username.Text);
                UserForm userForm = new UserForm { Id=user.Id, Name=user.Name, Password=user.Password, Role=user.Role };
                MainWindow window = new MainWindow(userForm);
                Hide();         //隐藏当前窗口
                window.Show();  //显示新窗口
                Close();        //关闭当前窗口
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }
    }
}
