using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace oop
{
    class BanCo
    {
        private int _SoDong;
        private int _SoCot;
        Button btn = new Button();

        public int SoDong
        {
            set { _SoDong = value; }
            get { return _SoDong; }
        }

        public int SoCot
        {
            set { _SoCot = value; }
            get { return _SoCot; }
        }

        public BanCo()
        {
            _SoDong = 0;
            _SoCot = 0;
        }

        public BanCo(int soDong, int soCot)
        {
            _SoDong = soDong;
            _SoCot = soCot;
        }

        public void VeBanCo(Graphics g)
        {
            for(int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo._ChieuRong, 0, i * OCo._ChieuRong, _SoDong * OCo._ChieuCao);
            }
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo._ChieuCao, _SoCot * OCo._ChieuRong, j * OCo._ChieuCao);
            }
        }
        public void VeQuanCo(Graphics g,Point point,SolidBrush sb)
        {
            btn.BackgroundImage = Image.FromFile("//Resources/caro.jpg");
            g.FillEllipse(sb, point.X + 2, point.Y + 2, OCo._ChieuRong - 4, OCo._ChieuCao - 4);
        }
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, OCo._ChieuRong - 2, OCo._ChieuCao - 2);
        }
    }
}
