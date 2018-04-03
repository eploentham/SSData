using SSData.control;
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
    public partial class FrmSSDataView : Form
    {
        Form par;
        SSDataControl sC;
        public FrmSSDataView(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc,par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            sC = sc;
            par = par1;
            setGrdViewH();
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[0, 2].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[0, 2].AllowAutoSort = true;
            grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            FarPoint.Win.Spread.CellType.NumberCellType objNumCell = new FarPoint.Win.Spread.CellType.NumberCellType();
            objNumCell.DecimalPlaces = 0;
            objNumCell.MinimumValue = 1;
            objNumCell.MaximumValue = 9999;
            objNumCell.ShowSeparator = false;

            FarPoint.Win.Spread.CellType.DateTimeCellType datecell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            datecell.DateSeparator = " | ";
            datecell.TimeSeparator = ".";
            datecell.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;

            FarPoint.Win.Spread.CellType.CurrencyCellType ctest = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            ctest.SetCalculatorText("Accept", "Cancel");

            //grdView.sheet
            grdView.Height = 330;
            grdView.Width = 765;
            grdView.Sheets[0].ColumnCount = 8;
            grdView.Sheets[0].RowCount = 100;

            grdView.Sheets[0].ColumnHeader.Cells[0, 0].Text = "Check #";
            grdView.Sheets[0].Columns[0].Width = 250;
            grdView.Sheets[0].Columns[0].CellType = objNumCell;
            grdView.Sheets[0].Columns[1].CellType = datecell;
            grdView.Sheets[0].Columns[2].CellType = ctest;
        }
        private void setResize()
        {
            grdView.Width = this.Width - 50;
            grdView.Height = this.Height - 180;
            //groupBox1.Width = this.Width - 50;
            //pB1.Width = this.Width - 900;
        }

        private void FrmSSDataView_Load(object sender, EventArgs e)
        {

        }

        private void FrmSSDataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }

        private void FrmSSDataView_Resize(object sender, EventArgs e)
        {
            setResize();
        }
    }
}
