using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace wpf_learn
{
    /// <summary>
    /// UpdateSourceTrigeerWindows.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateSourceTrigeerWindows : Window, INotifyPropertyChanged
    {
        //如果我们要改user本身的话，那么就要在调用user的类中实现INotifyPropertyChanged接口
        private User _user;
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; DoNotify(); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void DoNotify([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public User user { 
            get {
                return _user;
            } 
            set {
                this._user = value;
                this.DoNotify();
            } 
        }

        public UpdateSourceTrigeerWindows()
        {
            Users = new ObservableCollection<User>();
            user =  new User {   Name = "jack" };
            InitializeComponent();
            this.DataContext = this;
            Users.Add(new User { Name = "tony" });
            Users.Add(new User { Name = "Jim" });
            Users.Add(new User { Name = "Darling" });
            Users.Add(new User { Name = "Jack" });
            List_Users.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //这里通过显式(Explict)的调用方法更新源
            var bind = text_title.GetBindingExpression(TextBox.TextProperty);
            bind.UpdateSource();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.user.Name = "xxx";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.user.Name);
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            this.Users.Add(new User
            {
                Name = "newUser"
            });
            List_Users.ItemsSource= _users;
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var user = List_Users.SelectedItem as User;
            if (user != null)
            {
                user.Name = "update!";
            }
        }
    }

    public class User:INotifyPropertyChanged
    {
        private string? _Name;
        //如果我们要改Name本身的话，那么就要在调用name属性的类中实现INotifyPropertyChanged接口
        public string? Name { get { return _Name; } set { this._Name = value;this.DoNotify(); } }

        //属性更改通知机制
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void DoNotify([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
