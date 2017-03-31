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
using System.Drawing;
using System.Windows.Interop;

namespace JustDrag
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isClicked = false;
        private Rect myRect;
        private System.Windows.Point ptClicked;

        private int test = 0; // 테스트용 작성자가 곧 지울 예정

        public int getTest() // 테스트용 작성자가 곧 지울 예정
        {
            return this.test;
        }

        public MainWindow()
        {
            InitializeComponent();

            rectScreen.Rect = new Rect(SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop, SystemParameters.MaximumWindowTrackWidth, SystemParameters.MaximumWindowTrackHeight);
            rectDraged.Rect = myRect = new Rect(0, 0, 0, 0);

            base.MouseDown += MainWindow_MouseDown;
            base.MouseMove += MainWindow_MouseMove;
            base.MouseUp += MainWindow_MouseUp;
        }

        protected void MainWindow_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            /*
             * @todo 오른쪽 마우스가 클릭 됐을 때는 필터링
             */

            isClicked = true;

            ptClicked.X = myRect.X = e.GetPosition(this).X;
            ptClicked.Y = myRect.Y = e.GetPosition(this).Y;
            myRect.Width = myRect.Height = 1;

            rectDraged.Rect = myRect;
        }

        protected void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            double x, y, h, w;

            if (isClicked)
            {
                x = ptClicked.X;
                y = ptClicked.Y;
                w = e.GetPosition(this).X - ptClicked.X;
                h = e.GetPosition(this).Y - ptClicked.Y;

                if (w < 0) 
                {
                    myRect.X = x + w < 0 ? 0 : x + w;
                    myRect.Width = -w;
                }
                else
                {
                    myRect.X = x;
                    myRect.Width = w;
                }


                if (h < 0)
                {
                    myRect.Y = y + h < 0 ? 0 : y + h;
                    myRect.Height = -h;
                }
                else
                {
                    myRect.Y = y;
                    myRect.Height = h;
                }
                
                rectDraged.Rect = myRect;
            }
            e.Handled = true;
        }

        protected void MainWindow_MouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isClicked = false;
            test++; // 테스트용 작성자가 곧 지울 예정


            if( rectDraged.Rect.Width > 0 && rectDraged.Rect.Height > 0 )
            {
                using (var screenBmp = new Bitmap((int)rectDraged.Rect.Width, (int)rectDraged.Rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    using (var bmpGraphics = Graphics.FromImage(screenBmp))
                    {
                        bmpGraphics.CopyFromScreen((int)rectDraged.Rect.Left, (int)rectDraged.Rect.Top, 0, 0,
                            new System.Drawing.Size((int)rectDraged.Rect.Width, (int)rectDraged.Rect.Height));

                        Imaging.CreateBitmapSourceFromHBitmap(
                            screenBmp.GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                    }
                }
            }
            /*
             * @todo 오른쪽 마우스가 클릭 됐을 때는 필터링
             */
        }

        /*
        *  @todo 드래그 하던 도중 ESC 누르면 드래그 한 거 취소하고 Controller로 돌아가기
        */
        protected void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
