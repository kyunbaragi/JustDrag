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
            /* 문서화 X (문서화는 /** 혹은 /// 로 시작)
             * @author  이영식
             * @date    2017-03-25
             * @ref     http://jooji88.tistory.com/101 
             * 
             * @section canceled    버튼을 누를 때마다 MainWindow를 만드므로, 생성자에서 한 번 만들도록 수정 \n
             *                      아래와 같은 이유로 위 기능 구현을 취소 \n
             *                      ShowDialog는 뮤텍스 같이 레이스 컨디션을 막을 용도로 사용해야 하고 \n
             *                      매번 윈도우를 재생성해야 함... 따라서 윈도우는 복잡하게 작성하지 말고 \n
             *                      매번 재생성하기 힘든 내용은 부모 윈도우에서 보관하다 넘겨주는 식으로 사용
             */
            MainWindow mainWindow = new MainWindow();

            Hide();
            mainWindow.ShowDialog();    // ShowDialog -> Window를 Modal(동기식)로 불러옴
            Show();

            /*
             * mainWindow.ShowDialog()로 MainWindow에서 변경되는 값들은 멤버 변수에 저장해
             * 여기(Controller)에서 mainWindow.GetXXX() 식으로 사용하면 될 듯 함
             */
            MessageBox.Show("테스트 : " + mainWindow.getTest()); // 테스트용 작성자가 곧 삭제할 예정
        }
    }
}
