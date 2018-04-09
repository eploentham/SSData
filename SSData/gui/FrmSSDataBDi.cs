using SSData.control;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData.gui
{
    public partial class FrmSSDataBDi : Form
    {
        BillDisp bd;
        BillDispItems bdI;
        SSDataControl sC;
        int colId = 0, colbdid = 1, coldispid = 2, colprdcat = 3, colhospdrgid = 4, codrgid = 5, coldfscode = 6, coldfstext = 7;
        int colpacksize = 8, colsigcode = 9, colsigtext = 10, colquantity = 11, unitprice = 12, chargeamt = 13, reimbprice = 14, colreimbamt = 15;
        int colprdsecode = 16, colclaimcont = 17, colclaimcat = 18, colmultidisp = 19, colsupplyfor = 20;
        int coledit=21,colCnt = 22;

        public FrmSSDataBDi(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            bd = new BillDisp();
            bdI = new BillDispItems();
            //setGrdViewH();
            setGrdView();
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;

        }
        private void setGrdView()
        {

        }

        private void FrmSSDataBDi_Load(object sender, EventArgs e)
        {

        }
    }
}
