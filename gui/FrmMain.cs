using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData
{
    public partial class FrmMain : Form
    {
        Boolean drag = false;
        Point startPoint = new Point(0, 0);
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmSSDataView_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void FrmSSDataView_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void FrmSSDataView_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void tilExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
