using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop
{
    public partial class frmCoCaro : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        public frmCoCaro()
        {
            InitializeComponent();
            btnPlayervsPlayer.Click += new EventHandler(PvsP);
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOCo(); 
            grs = pnlBanCo.CreateGraphics();
            btnPlayervsCom.Click += new EventHandler(PvsC);
        }
        private void frmCoCaro_Load(object sender, EventArgs e)
        {
            
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
            {
                MessageBox.Show("Hãy chọn chế độ chơi trước.");
                return;
            }
            if(caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemTraChienThangPvsP())
                    caroChess.KetThucTroChoi();
                if (caroChess.CheDoChoi == 2)
                {
                    caroChess.KhoiDongMay(grs);
                    if (caroChess.KiemTraChienThangPvsC())
                        caroChess.KetThucTroChoi();
                }
            }     
        }

        private void PvsP(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn chế độ chơi 2 người.");
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayervsPlayer(grs);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(caroChess.CheDoChoi == 1)
            {
                caroChess.Undo(grs);
            }
            else
            {
                caroChess.UndoPvsC(grs);
            }    
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(caroChess.CheDoChoi == 1)
            {
                caroChess.Redo(grs);
            }
            else
            {
                caroChess.RedoPvsC(grs);
            }     
        }
        private void PvsC(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn chế độ chơi 1 người.");
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayerVsCom(grs);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
            Intro f = new Intro();         
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
