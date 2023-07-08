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

namespace wpf_learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //绑定窗口数据的上下文
            this.DataContext = this;
            //通过代码的方式绑定属性
            bindPropertyByCode();
        }

        //通过代码的方式绑定属性
        private void bindPropertyByCode()
        {
            //设置需要绑定的属性名
            var bind = new Binding("Text");
            //需要绑定元素
            bind.Source = text_origin_content;
            //开始绑定
            text_new_content.SetBinding(TextBox.TextProperty, bind);
        }
    }
}
