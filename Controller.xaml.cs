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
            // 문서화 주석은 /** */ 혹은 /// 로 시작
            // 일반 주석은 /* */ 혹은 //
            /* 
             * @author  이영식
             * @date    2017-03-25
             * @ref     http://jooji88.tistory.com/101 
             * @brief   showDialog는 한 번 닫히면 다시 사용불가, 새로 윈도우를 할당해야함
             * @details showDialog로 사용될 윈도우는 가볍게 작성하고 \n
             *          매번 만들기 번거로운 객체를 사용해야 하면 부모에 보관하다 전달
             */
            MainWindow mainWindow = new MainWindow();

            Hide();
            if ((bool)mainWindow.ShowDialog())    // ShowDialog -> Window를 Modal(동기식)로 불러옴
                this.Close();
            Show();

            /*
             * mainWindow.ShowDialog()로 MainWindow에서 변경되는 값들은 멤버 변수에 저장해
             * 여기(Controller)에서 mainWindow.GetXXX() 식으로 사용하면 될 듯 함
             */
            MessageBox.Show("테스트 : " + mainWindow.getTest()); // 테스트용 작성자가 곧 삭제할 예정
        }
    }
}
