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
            // 협업용 주석 예제여서 일반 주석 사용, 문서화 주석은 /** 혹은 /// 로 시작
            /* 
             * @author  이영식
             * @date    2017-03-25
             * @todo    버튼을 누를 때마다 MainWindow를 만드므로, 생성자에서 한 번 만들도록 수정 [기한 없음] \n
             * @ref     http://jooji88.tistory.com/101 
             * @brief   CANCELED     [ WAITING - 미배당 | ASSIGNED - 배당됨 | CANCELED - 취소됨 ]
             * @details ShowDialog는 뮤텍스 같이 레이스 컨디션을 막을 용도로 사용해야 하고 \n
             *          매번 윈도우를 재생성해야 함... 따라서 윈도우는 복잡하게 작성하지 말고 \n
             *          매번 재생성하기 힘든 내용은 부모 윈도우에서 보관하다 넘겨주는 식으로 사용 \n
             *          
             *          [WAITING - 맡아줬으면 하는 그룹, 특정 개발자 혹은 ANONYMOUS(아무나)]
             *          [ASSIGNED - 개발자명, 기능 구현이 완료되면 주석 삭제 혹은 문서화 주석으로 변경]
             *          [CANCELED - 취소된 이유를 기억할 필요가 있는 경우에 작성, 문서화 하지는 않음]
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
