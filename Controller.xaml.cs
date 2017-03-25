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

namespace JustDrag
{
    /// <summary>
    /// Controller.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Controller : Window
    {
        public Controller()
        {
            InitializeComponent();
        }

        private void btnCaptureClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   // ToDo 버튼을 누를 때마다 MainWindow를 만드므로, 생성자에서 한 번 만들도록 수정
                                                        // See http://jooji88.tistory.com/101
            this.Hide();                                // Hide -> ShowDialog -> Show 패턴은 자주 사용될 듯 하니 함수로 만드는 것도 좋을 듯
            mainWindow.ShowDialog();                    // ShowDialog -> Window를 Modal(동기식)로 불러옴
            this.Show();

            /*
             * mainWindow.ShowDialog()로 MainWindow에서 변경되는 값들은 멤버 변수에 저장해
             * 여기(Controller)에서 mainWindow.GetXXX() 식으로 사용하면 될 듯 함
             */

            MessageBox.Show("야호");                    
        }
    }
}
