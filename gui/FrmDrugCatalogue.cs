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
    public partial class FrmDrugCatalogue : Form
    {
        Form par;
        SSDataControl sC;
        int colCode = 0, colProd = 1, colTmt = 2, colSpec = 3, colGene = 4, colTrad = 5, colDfs = 6, colDos = 7, colStr = 8, colCont = 9;
        int colDist=10, colManu=11, colIsed=12, colNdc=13, colUnitS=14, colUnitP=15, colUpF=16, colDatC=17, colDatU=18, colDatE=19, colID=20;

        public FrmDrugCatalogue(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc, par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            sC = sc;
            par = par1;
            setGrdViewH();
        }
        private void FrmDrugCatalogue_Load(object sender, EventArgs e)
        {

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
            grdView.Sheets.Count = 2;
            grdView.Height = 330;
            grdView.Width = 765;
            grdView.Sheets[0].SheetName = "Drug Catalogue";
            grdView.Sheets[1].SheetName = "นำเข้า";
            grdView.Sheets[0].ColumnCount = 21;
            grdView.Sheets[0].RowCount = 1;
            grdView.Sheets[1].RowCount = 1;

            grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "hospdrugcode";
            grdView.Sheets[0].ColumnHeader.Cells[0, colProd].Text = "productcat";
            grdView.Sheets[0].ColumnHeader.Cells[0, colTmt].Text = "tmtid";
            grdView.Sheets[0].ColumnHeader.Cells[0, colSpec].Text = "specprep";
            grdView.Sheets[0].ColumnHeader.Cells[0, colGene].Text = "genericname";
            grdView.Sheets[0].ColumnHeader.Cells[0, colTrad].Text = "tradename";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDfs].Text = "dfscode";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDos].Text = "dosageform";
            grdView.Sheets[0].ColumnHeader.Cells[0, colStr].Text = "strength";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCont].Text = "content1";

            grdView.Sheets[0].ColumnHeader.Cells[0, colDist].Text = "distributor";
            grdView.Sheets[0].ColumnHeader.Cells[0, colManu].Text = "manufactrer";
            grdView.Sheets[0].ColumnHeader.Cells[0, colIsed].Text = "ised";
            grdView.Sheets[0].ColumnHeader.Cells[0, colNdc].Text = "ndc24";
            grdView.Sheets[0].ColumnHeader.Cells[0, colUnitS].Text = "unitsize";
            grdView.Sheets[0].ColumnHeader.Cells[0, colUnitP].Text = "unitprice";
            grdView.Sheets[0].ColumnHeader.Cells[0, colUpF].Text = "updateflag";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDatC].Text = "datechange";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDatU].Text = "dateupdate";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDatE].Text = "dateeffect";

            grdView.Sheets[0].ColumnHeader.Cells[0, colID].Text = "drugcat_id";
            //grdView.Sheets[0].ColumnHeader.Cells[0, 0].Text = "hospdrugcode";

            grdView.Sheets[0].Columns[colID].Visible = false;

            grdView.Sheets[0].Columns[colCode].Width = 250;
            grdView.Sheets[0].Columns[colProd].Width = 250;
            grdView.Sheets[0].Columns[colTmt].Width = 250;
            grdView.Sheets[0].Columns[colSpec].Width = 250;
            grdView.Sheets[0].Columns[colGene].Width = 250;
            grdView.Sheets[0].Columns[colTrad].Width = 250;
            grdView.Sheets[0].Columns[colDfs].Width = 250;
            grdView.Sheets[0].Columns[colDos].Width = 250;
            grdView.Sheets[0].Columns[colStr].Width = 250;
            grdView.Sheets[0].Columns[colCont].Width = 250;

            grdView.Sheets[0].Columns[colDist].Width = 250;
            grdView.Sheets[0].Columns[colManu].Width = 250;
            grdView.Sheets[0].Columns[colIsed].Width = 250;
            grdView.Sheets[0].Columns[colNdc].Width = 250;
            grdView.Sheets[0].Columns[colUnitS].Width = 250;
            grdView.Sheets[0].Columns[colUnitP].Width = 250;
            grdView.Sheets[0].Columns[colUpF].Width = 250;
            grdView.Sheets[0].Columns[colDatC].Width = 250;
            grdView.Sheets[0].Columns[colDatU].Width = 250;
            grdView.Sheets[0].Columns[colDatE].Width = 250;
            

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

        private void FrmDrugCatalogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }

        private void FrmDrugCatalogue_Resize(object sender, EventArgs e)
        {
            setResize();
        }
    }
}
