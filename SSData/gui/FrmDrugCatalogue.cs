﻿using C1.C1Excel;
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
        int colDist =10, colManu=11, colIsed=12, colNdc=13, colUnitS=14, colUnitP=15, colUpF=16, colDatC=17, colDatU=18, colDatE=19, colID=20;
        int conCnt = 21;

        public FrmDrugCatalogue(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc, par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            sC = sc;
            par = par1;
            pB1.Hide();
            setGrdViewH();
            setGrdViewH1();
            setGrdView();
        }
        private void FrmDrugCatalogue_Load(object sender, EventArgs e)
        {

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            sC.mHisDB.insertDrugCat(grdView, pB1);
            setGrdView();
        }
        private void btnBrowe_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xls";
            dlg.FileName = "*.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // clear everything
                excel.Clear();
                excel.Load(dlg.FileName);
                foreach (XLSheet sheet in excel.Sheets)
                {
                    LoadSheet(sheet);
                }
                // load book                
            }
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
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

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

            grdView.Sheets[0].Columns[colCode].Width = 120;
            grdView.Sheets[0].Columns[colProd].Width = 120;
            grdView.Sheets[0].Columns[colTmt].Width = 80;
            grdView.Sheets[0].Columns[colSpec].Width = 80;
            grdView.Sheets[0].Columns[colGene].Width = 250;
            grdView.Sheets[0].Columns[colTrad].Width = 250;
            grdView.Sheets[0].Columns[colDfs].Width = 80;
            grdView.Sheets[0].Columns[colDos].Width = 250;
            grdView.Sheets[0].Columns[colStr].Width = 250;
            grdView.Sheets[0].Columns[colCont].Width = 250;

            grdView.Sheets[0].Columns[colDist].Width = 80;
            grdView.Sheets[0].Columns[colManu].Width = 250;
            grdView.Sheets[0].Columns[colIsed].Width = 80;
            grdView.Sheets[0].Columns[colNdc].Width = 80;
            grdView.Sheets[0].Columns[colUnitS].Width = 80;
            grdView.Sheets[0].Columns[colUnitP].Width = 80;
            grdView.Sheets[0].Columns[colUpF].Width = 80;
            grdView.Sheets[0].Columns[colDatC].Width = 140;
            grdView.Sheets[0].Columns[colDatU].Width = 140;
            grdView.Sheets[0].Columns[colDatE].Width = 140;
            

            grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colProd].CellType = objTextCell;
            grdView.Sheets[0].Columns[colTmt].CellType = objTextCell;
            grdView.Sheets[0].Columns[colSpec].CellType = objTextCell;
            grdView.Sheets[0].Columns[colGene].CellType = objTextCell;
            grdView.Sheets[0].Columns[colTrad].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDfs].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDos].CellType = objTextCell;
            grdView.Sheets[0].Columns[colStr].CellType = objTextCell;
            grdView.Sheets[0].Columns[colCont].CellType = objTextCell;

            grdView.Sheets[0].Columns[colDist].CellType = objTextCell;
            grdView.Sheets[0].Columns[colManu].CellType = objTextCell;
            grdView.Sheets[0].Columns[colIsed].CellType = objTextCell;
            grdView.Sheets[0].Columns[colNdc].CellType = objTextCell;
            grdView.Sheets[0].Columns[colUnitS].CellType = objTextCell;
            grdView.Sheets[0].Columns[colUnitP].CellType = objTextCell;
            grdView.Sheets[0].Columns[colUpF].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDatC].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDatU].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDatE].CellType = objTextCell;

        }
        private void setGrdViewH1()
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
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

            ctest.SetCalculatorText("Accept", "Cancel");

            ////grdView.sheet
            //grdView.Sheets.Count = 2;
            //grdView.Height = 330;
            //grdView.Width = 765;
            //grdView.Sheets[0].SheetName = "Drug Catalogue";
            //grdView.Sheets[1].SheetName = "นำเข้า";
            //grdView.Sheets[0].ColumnCount = 21;
            //grdView.Sheets[0].RowCount = 1;
            //grdView.Sheets[1].RowCount = 1;
            grdView.Sheets[1].ColumnCount = 21;

            grdView.Sheets[1].ColumnHeader.Cells[0, colCode].Text = "hospdrugcode";
            grdView.Sheets[1].ColumnHeader.Cells[0, colProd].Text = "productcat";
            grdView.Sheets[1].ColumnHeader.Cells[0, colTmt].Text = "tmtid";
            grdView.Sheets[1].ColumnHeader.Cells[0, colSpec].Text = "specprep";
            grdView.Sheets[1].ColumnHeader.Cells[0, colGene].Text = "genericname";
            grdView.Sheets[1].ColumnHeader.Cells[0, colTrad].Text = "tradename";
            grdView.Sheets[1].ColumnHeader.Cells[0, colDfs].Text = "dfscode";
            grdView.Sheets[1].ColumnHeader.Cells[0, colDos].Text = "dosageform";
            grdView.Sheets[1].ColumnHeader.Cells[0, colStr].Text = "strength";
            grdView.Sheets[1].ColumnHeader.Cells[0, colCont].Text = "content1";

            grdView.Sheets[1].ColumnHeader.Cells[0, colDist].Text = "distributor";
            grdView.Sheets[1].ColumnHeader.Cells[0, colManu].Text = "manufactrer";
            grdView.Sheets[1].ColumnHeader.Cells[0, colIsed].Text = "ised";
            grdView.Sheets[1].ColumnHeader.Cells[0, colNdc].Text = "ndc24";
            grdView.Sheets[1].ColumnHeader.Cells[0, colUnitS].Text = "unitsize";
            grdView.Sheets[1].ColumnHeader.Cells[0, colUnitP].Text = "unitprice";
            grdView.Sheets[1].ColumnHeader.Cells[0, colUpF].Text = "updateflag";
            grdView.Sheets[1].ColumnHeader.Cells[0, colDatC].Text = "datechange";
            grdView.Sheets[1].ColumnHeader.Cells[0, colDatU].Text = "dateupdate";
            grdView.Sheets[1].ColumnHeader.Cells[0, colDatE].Text = "dateeffect";

            grdView.Sheets[1].ColumnHeader.Cells[0, colID].Text = "drugcat_id";
            //grdView.Sheets[0].ColumnHeader.Cells[0, 0].Text = "hospdrugcode";

            grdView.Sheets[1].Columns[colID].Visible = false;

            grdView.Sheets[1].Columns[colCode].Width = 120;
            grdView.Sheets[1].Columns[colProd].Width = 120;
            grdView.Sheets[1].Columns[colTmt].Width = 80;
            grdView.Sheets[1].Columns[colSpec].Width = 80;
            grdView.Sheets[1].Columns[colGene].Width = 250;
            grdView.Sheets[1].Columns[colTrad].Width = 250;
            grdView.Sheets[1].Columns[colDfs].Width = 80;
            grdView.Sheets[1].Columns[colDos].Width = 250;
            grdView.Sheets[1].Columns[colStr].Width = 250;
            grdView.Sheets[1].Columns[colCont].Width = 250;

            grdView.Sheets[1].Columns[colDist].Width = 80;
            grdView.Sheets[1].Columns[colManu].Width = 250;
            grdView.Sheets[1].Columns[colIsed].Width = 80;
            grdView.Sheets[1].Columns[colNdc].Width = 80;
            grdView.Sheets[1].Columns[colUnitS].Width = 80;
            grdView.Sheets[1].Columns[colUnitP].Width = 80;
            grdView.Sheets[1].Columns[colUpF].Width = 80;
            grdView.Sheets[1].Columns[colDatC].Width = 140;
            grdView.Sheets[1].Columns[colDatU].Width = 140;
            grdView.Sheets[1].Columns[colDatE].Width = 140;


            grdView.Sheets[1].Columns[colCode].CellType = objTextCell;
            grdView.Sheets[1].Columns[colProd].CellType = objTextCell;
            grdView.Sheets[1].Columns[colTmt].CellType = objTextCell;
            grdView.Sheets[1].Columns[colSpec].CellType = objTextCell;
            grdView.Sheets[1].Columns[colGene].CellType = objTextCell;
            grdView.Sheets[1].Columns[colTrad].CellType = objTextCell;
            grdView.Sheets[1].Columns[colDfs].CellType = objTextCell;
            grdView.Sheets[1].Columns[colDos].CellType = objTextCell;
            grdView.Sheets[1].Columns[colStr].CellType = objTextCell;
            grdView.Sheets[1].Columns[colCont].CellType = objTextCell;

            grdView.Sheets[1].Columns[colDist].CellType = objTextCell;
            grdView.Sheets[1].Columns[colManu].CellType = objTextCell;
            grdView.Sheets[1].Columns[colIsed].CellType = objTextCell;
            grdView.Sheets[1].Columns[colNdc].CellType = objTextCell;
            grdView.Sheets[1].Columns[colUnitS].CellType = objTextCell;
            grdView.Sheets[1].Columns[colUnitP].CellType = objTextCell;
            grdView.Sheets[1].Columns[colUpF].CellType = objTextCell;
            grdView.Sheets[1].Columns[colDatC].CellType = objTextCell;
            grdView.Sheets[1].Columns[colDatU].CellType = objTextCell;
            grdView.Sheets[1].Columns[colDatE].CellType = objTextCell;

        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.dCDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach(DataRow row in dt.Rows)
            {
                
                grdView.Sheets[0].Cells[i, colCode].Value = row[sC.mHisDB.dCDB.dCL.hospdrugcode].ToString();
                grdView.Sheets[0].Cells[i, colProd].Value = row[sC.mHisDB.dCDB.dCL.productcat].ToString();
                grdView.Sheets[0].Cells[i, colTmt].Value = row[sC.mHisDB.dCDB.dCL.tmtid].ToString();
                grdView.Sheets[0].Cells[i, colSpec].Value = row[sC.mHisDB.dCDB.dCL.specprep].ToString();
                grdView.Sheets[0].Cells[i, colGene].Value = row[sC.mHisDB.dCDB.dCL.genericname].ToString();
                grdView.Sheets[0].Cells[i, colTrad].Value = row[sC.mHisDB.dCDB.dCL.tradename].ToString();
                grdView.Sheets[0].Cells[i, colDfs].Value = row[sC.mHisDB.dCDB.dCL.dfscode].ToString();
                grdView.Sheets[0].Cells[i, colDos].Value = row[sC.mHisDB.dCDB.dCL.dosageform].ToString();
                grdView.Sheets[0].Cells[i, colStr].Value = row[sC.mHisDB.dCDB.dCL.strength].ToString();
                grdView.Sheets[0].Cells[i, colCont].Value = row[sC.mHisDB.dCDB.dCL.content1].ToString();

                grdView.Sheets[0].Cells[i, colDist].Value = row[sC.mHisDB.dCDB.dCL.distributor].ToString();
                grdView.Sheets[0].Cells[i, colManu].Value = row[sC.mHisDB.dCDB.dCL.manufactrer].ToString();
                grdView.Sheets[0].Cells[i, colIsed].Value = row[sC.mHisDB.dCDB.dCL.ised].ToString();
                grdView.Sheets[0].Cells[i, colNdc].Value = row[sC.mHisDB.dCDB.dCL.ndc24].ToString();
                grdView.Sheets[0].Cells[i, colUnitS].Value = row[sC.mHisDB.dCDB.dCL.unitsize].ToString();
                grdView.Sheets[0].Cells[i, colUnitP].Value = row[sC.mHisDB.dCDB.dCL.unitprice].ToString();
                grdView.Sheets[0].Cells[i, colUpF].Value = row[sC.mHisDB.dCDB.dCL.updateflag].ToString();
                grdView.Sheets[0].Cells[i, colDatC].Value = row[sC.mHisDB.dCDB.dCL.datechange].ToString();
                grdView.Sheets[0].Cells[i, colDatU].Value = row[sC.mHisDB.dCDB.dCL.dateupdate].ToString();
                grdView.Sheets[0].Cells[i, colDatE].Value = row[sC.mHisDB.dCDB.dCL.dateeffect].ToString();

                grdView.Sheets[0].Cells[i, colID].Value = row[sC.mHisDB.dCDB.dCL.drugcat_id].ToString();
                i++;
            }
        }
        private void LoadSheet(XLSheet sheet)
        {
            // load cells
            grdView.Sheets[1].RowCount = sheet.Rows.Count;
            //grdView.Sheets[0].ColumnCount = sheet.Columns.Count;
            for (int r = 0; r < sheet.Rows.Count; r++)
            {
                //String aaa = "";
                //break;
                for (int c = 0; c < sheet.Columns.Count; c++)
                {
                    // get cell
                    XLCell cell = sheet.GetCell(r, c);
                    if (cell == null) continue;
                    // apply content
                    //flex[r + frows, c + fcols] = cell.Value;
                    grdView.Sheets[1].Cells[r, c].Value = cell.Value;
                    if(c%2==0)
                        grdView.Sheets[1].Rows[r].BackColor = Color.Yellow;
                    // apply style
                    ////CellStyle cs = StyleFromExcel(flex, cell.Style);
                    ////if (cs != null)
                    ////    flex.SetCellStyle(r + frows, c + fcols, cs);
                }
            }
            grdView.ActiveSheetIndex = 1;
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
