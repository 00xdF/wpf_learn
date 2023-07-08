using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// ValueConvertWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ValueConvertWindow : Window
    {
        public ValueConvertWindow()
        {
            InitializeComponent();
            var stu = new Student { Name = "Jack",Score = 92.3};
            this.DataContext = stu;
        }
    }

    class BoolConverter : IValueConverter
    {
        //把原对象转化为目标对象
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //获取绑定的值
            var val = value.ToString()!;
            return val.ToLower().Equals("yes") || val.ToLower().Equals("true") ? true : false;
        }

        //把目标对象转化为源对象
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return value;
        }
    }

    class Student : INotifyPropertyChanged,IDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        
        private string? _name;
        private double? _score;

        public double? Score
        {
            get { return _score; }
            set { _score = value; DoNotify(); }
        }


        public string? Name
        {
            get { return _name; }
            set { _name = value; DoNotify(); }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] {
            get {
                string res = "";
                switch (columnName)
                {
                    case nameof(Name):
                        if (Name?.Length == 0 || Name?.Length > 4)
                        {
                            res = "姓名不合法";
                        }
                        break;
                    case nameof(Score):
                        if(Score<0 || Score > 100)
                        {
                            res = "成绩不合法";
                        }
                        break;
                }
                return res;
            }
   
        }

        public void DoNotify([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
