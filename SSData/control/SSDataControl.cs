﻿
using SSData.objdb;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData.control
{
    public class SSDataControl
    {
        public InitConfig iniC;
        private IniFile iniF;
        public ConnectDB conn;
        public MainHISDB mHisDB;

        String encoding = "Windows-874";
        public String monthId = "", yearId = "", ssVid="", btID="", bdID="", opsID="", btIId="", bdIId="", opdXId="";

        public enum TypeOut { Discharge=1, Admin=2, Refer=3, Dead=4, Escape=5, Other=9}
        public List<TSsdataSplit> lSplit;
        public String[] fm20;

        public SSDataControl()
        {
            initConfig();
        }
        private void initConfig()
        {
            String appName = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
            }
            iniF = new IniFile(appName);
            iniC = new InitConfig();
            GetConfig();
            conn = new ConnectDB(iniC);
            mHisDB = new MainHISDB(conn);
            lSplit = new List<TSsdataSplit>();
            //fm20 = new String[]();
        }
        public void GetConfig()
        {
            iniC.hostDBMainHIS = iniF.Read("hostDBMainHIS");    //bit
            iniC.hostDBSSData = iniF.Read("hostDBSSData");
            
            iniC.nameDBMainHIS = iniF.Read("nameDBMainHIS");
            iniC.nameDBSSData = iniF.Read("nameDBSSData");
            
            iniC.passDBMainHIS = iniF.Read("passDBMainHIS");
            iniC.passDBSSData = iniF.Read("passDBSSData");
            
            iniC.portDBMainHIS = iniF.Read("portDBMainHIS");
            iniC.portDBSSData = iniF.Read("portDBSSData");
            
            iniC.userDBMainHIS = iniF.Read("userDBMainHIS");
            iniC.userDBSSData = iniF.Read("userDBSSData");

            iniC.HCODE = iniF.Read("HCODE");
            iniC.branchId = iniF.Read("branch_id");
            iniC.pathFile = iniF.Read("pathFile");
            iniC.FileNameBillTran = iniF.Read("FileNameBillTran");
            iniC.FileNameBillDisp  = iniF.Read("FileNameBillDisp");
            iniC.FileNameOPServices = iniF.Read("FileNameOPServices");
            iniC.SSOPBIL = iniF.Read("SSOPBIL");
            iniC.EmailSSOPBIL = iniF.Read("EmailSSOPBIL");
            iniC.HNAME = iniF.Read("HNAME");
            iniC.pathFileZip = iniF.Read("pathFileZip");


        }
        public String getValueCboItem(ComboBox c)
        {
            ComboBoxItem iSale;
            iSale = (ComboBoxItem)c.SelectedItem;
            if (iSale == null)
            {
                return "";
            }
            else
            {
                return iSale.Value;
            }
        }
        public ComboBox setCboYear(ComboBox c)
        {
            c.Items.Clear();
            c.Items.Add(System.DateTime.Now.Year);
            c.Items.Add(System.DateTime.Now.Year - 1);
            c.Items.Add(System.DateTime.Now.Year - 2);
            c.SelectedIndex = c.FindStringExact(String.Concat(System.DateTime.Now.Year));
            return c;
        }
        public String datetoDB(object dt)
        {
            DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return "";
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    dt1 = DateTime.Parse(dt.ToString());
                    if (dt1.Year <= 1500)
                    {
                        return String.Concat((dt1.Year), "-") + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }
                    else
                    {
                        return dt1.Year.ToString() + "-" + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ComboBox setCboMonth(ComboBox c)
        {
            //c.ClearItems();
            c.Items.Clear();
            var items = new[]{
                new{Text = "มกราคม", Value="01"},
                new{Text = "กุมภาพันธ์", Value="02"},
                new{Text = "มีนาคม", Value="03"},
                new{Text = "เมษายน", Value="04"},
                new{Text = "พฤษภาคม", Value="05"},
                new{Text = "มิถุนายน", Value="06"},
                new{Text = "กรกฎาคม", Value="07"},
                new{Text = "สิงหาคม", Value="08"},
                new{Text = "กันยายน", Value="09"},
                new{Text = "ตุลาคม", Value="10"},
                new{Text = "พฤศจิกายน", Value="11"},
                new{Text = "ธันวาคม", Value="12"}
            };
            c.DataSource = items;
            c.DisplayMember = "Text";

            c.ValueMember = "Value";
            c.SelectedIndex = c.FindStringExact(getMonth(System.DateTime.Now.Month.ToString("00")));
            return c;
        }
        public String getMonth(String monthId)
        {
            if (monthId == "01")
            {
                return "มกราคม";
            }
            else if (monthId == "02")
            {
                return "กุมภาพันธ์";
            }
            else if (monthId == "03")
            {
                return "มีนาคม";
            }
            else if (monthId == "04")
            {
                return "เมษายน";
            }
            else if (monthId == "05")
            {
                return "พฤษภาคม";
            }
            else if (monthId == "06")
            {
                return "มิถุนายน";
            }
            else if (monthId == "07")
            {
                return "กรกฎาคม";
            }
            else if (monthId == "08")
            {
                return "สิงหาคม";
            }
            else if (monthId == "09")
            {
                return "กันยายน";
            }
            else if (monthId == "10")
            {
                return "ตุลาคม";
            }
            else if (monthId == "11")
            {
                return "พฤศจิกายน";
            }
            else if (monthId == "12")
            {
                return "ธันวาคม";
            }
            else
            {
                return "";
            }
        }        
        public String dateDBtoShow(String dt)
        {
            if (dt != "")
            {
                return dt.Substring(8, 2) + "-" + dt.Substring(5, 2) + "-" + String.Concat(Int16.Parse(dt.Substring(0, 4)) + 543);
            }
            else
            {
                return dt;
            }
        }
        public void createFolder(String path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        private AlternateView getEmbeddedImage(String filePath, String cid)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = cid;
            string htmlBody = "<img src=cid:" + res.ContentId + ">";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public String FixNull(Object o)
        {
            String chk = "";
            if (o == null)
            {
                chk = "";
            }
            else
            {
                chk = o.ToString();
            }
            return chk;
        }
        public String genFileName(String hcode, String ssopbil, String period, String periodsub)
        {
            DateTime dt1 = DateTime.Now;
            String dt = "";
            dt = dt1.ToString("yyyyMMddTHH:mm:ss") + ".txt";
            //txtFileName.Value = txtHCODE.Text + "_" + txtSSOPBIL.Text + "_" + txtPeriod.Text + "_" + txtPeriodSub.Text + "_" + dt1.ToString("yyyyMMdd-HHmmss") + ".txt";
            return dt;
        }
        public String genTextBillTran(String hname, String path, String filename, String hcode, String ssopbil, String period, String periodsub, String yearId, String monthId, ProgressBar pb1)
        {
            String h1 = "", h2 = "", h3 = "", h4 = "", h5 = "", h6 = "", h7 = "", h8 = "", h9 = "", dt1 = "", SESSNO = "", Header = "", txtBT = "", txtRow = "", txtRowBTi = "", ssDId = "";
            try
            {
                pb1.Show();
                byte[] isoBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(encoding), Encoding.UTF8.GetBytes(iniC.HNAME));
                string msg = Encoding.GetEncoding(encoding).GetString(isoBytes);

                DataTable dtBT = new DataTable();
                DataTable dtBTi = new DataTable();
                SESSNO = mHisDB.ssdDB.selectIDByYearMonth(yearId, monthId);
                dtBT = mHisDB.btDB.selectByYearMonth(yearId, monthId);
               
                if (dtBT.Rows.Count > 0)
                {
                    ssDId = dtBT.Rows[0][mHisDB.btDB.bt.ssdata_id].ToString();
                }
                dtBTi = mHisDB.btIDB.selectBySSdId(ssDId);
                pb1.Minimum = 0;
                pb1.Maximum = dtBT.Rows.Count + dtBTi.Rows.Count+2;
                pb1.Value = 0;

                dt1 = genFileName(hcode, ssopbil, period, periodsub);
                h1 = @"<?xml version=""1.0"" encoding=""windows-874""?>" + Environment.NewLine;
                h2 = @"<ClaimRec System=""OP"" PayPlan=""SS"" Version=""0.93"">" + Environment.NewLine;
                h3 = "<Header>" + Environment.NewLine;
                h4 = "<HCODE>" + iniC.HCODE + "</HCODE>" + Environment.NewLine;
                //h5 = "<HNAME>" + txtHName.Text + "</HNAME>" + Environment.NewLine;
                h5 = "<HNAME>" + hname + "</HNAME>" + Environment.NewLine;
                h6 = "<DATETIME>" + dt1 + "</DATETIME>" + Environment.NewLine;
                h7 = "<SESSNO>" + SESSNO + "</SESSNO>" + Environment.NewLine;
                h8 = "<RECCOUNT>" + dtBT.Rows.Count + "</RECCOUNT>" + Environment.NewLine;
                h9 = "</Header>" + Environment.NewLine;

                var file = path + "\\" + filename;
                using (StreamWriter sw = new StreamWriter(File.Open(file, FileMode.Create), Encoding.GetEncoding(encoding)))
                {
                    Header = h1 + h2 + h3 + h4 + h5 + h6 + h7 + h8 + h9;
                    foreach (DataRow row in dtBT.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "", col07 = "", col08 = "", col09 = "", col10 = "";
                        String col11 = "", col12 = "", col13 = "", col14 = "", col15 = "", col16 = "", col17 = "", col18 = "", col19 = "";
                        col01 = row[mHisDB.btDB.bt.station].ToString();
                        col02 = row[mHisDB.btDB.bt.authcode].ToString();
                        col03 = row[mHisDB.btDB.bt.dttran].ToString();
                        col04 = row[mHisDB.btDB.bt.hcode].ToString();
                        col05 = row[mHisDB.btDB.bt.invno].ToString();
                        col06 = row[mHisDB.btDB.bt.billno].ToString();
                        col07 = row[mHisDB.btDB.bt.hn].ToString();
                        col08 = "";
                        col09 = row[mHisDB.btDB.bt.amount].ToString();
                        col10 = row[mHisDB.btDB.bt.paid].ToString();
                        col11 = row[mHisDB.btDB.bt.vercode].ToString();
                        col12 = row[mHisDB.btDB.bt.tflag].ToString();
                        col13 = row[mHisDB.btDB.bt.pid].ToString();
                        col14 = row[mHisDB.btDB.bt.name].ToString();
                        col15 = row[mHisDB.btDB.bt.hmain].ToString();
                        col16 = row[mHisDB.btDB.bt.payplan].ToString();
                        col17 = row[mHisDB.btDB.bt.claimamt].ToString();
                        col18 = row[mHisDB.btDB.bt.otherpayplan].ToString();
                        col19 = row[mHisDB.btDB.bt.otherpay].ToString();
                        txtRow += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + "|" + col07 + "|" + col08 + "|" + col09 + "|" + col10
                                + "|" + col11 + "|" + col12 + "|" + col13 + "|" + col14 + "|" + col15 + "|" + col16 + "|" + col17 + "|" + col18 + "|" + col19 + Environment.NewLine;
                    }
                    foreach (DataRow rowI in dtBTi.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "", col07 = "", col08 = "", col09 = "", col10 = "";
                        String col11 = "", col12 = "", col13 = "";

                        col01 = rowI[mHisDB.btIDB.btI.invno].ToString();
                        col02 = rowI[mHisDB.btIDB.btI.svdate].ToString();
                        col03 = rowI[mHisDB.btIDB.btI.billmuad].ToString();
                        col04 = rowI[mHisDB.btIDB.btI.lccode].ToString();
                        col05 = rowI[mHisDB.btIDB.btI.stdcode].ToString();
                        col06 = rowI[mHisDB.btIDB.btI.desc1].ToString();
                        col07 = rowI[mHisDB.btIDB.btI.qty].ToString();
                        col08 = rowI[mHisDB.btIDB.btI.up].ToString();
                        col09 = rowI[mHisDB.btIDB.btI.chargeamt].ToString();
                        col10 = rowI[mHisDB.btIDB.btI.claimup].ToString();
                        col11 = rowI[mHisDB.btIDB.btI.claimamount].ToString();
                        col12 = rowI[mHisDB.btIDB.btI.svrefid].ToString();
                        col13 = rowI[mHisDB.btIDB.btI.claimcat].ToString();

                        txtRowBTi += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + "|" + col07 + "|" + col08 + "|" + col09 + "|" + col10
                               + "|" + col11 + "|" + col12 + "|" + col13 + Environment.NewLine;
                    }
                    txtBT = "<BILLTRAN>" + Environment.NewLine + txtRow + "</BILLTRAN>" + Environment.NewLine +
                        "<BillItems>" + Environment.NewLine + txtRowBTi + "</BillItems>" + Environment.NewLine + "</ClaimRec>" + Environment.NewLine;
                    String md5 = @"<?EndNote Checksum="""+genMD5(Header + txtBT) + @"""?>";

                    sw.WriteLine(Header + txtBT+md5);
                }
            }
            catch (IOException ioex)
            {

            }
            pb1.Hide();
            return "1";
        }
        public String genTextBillDisp(String hname, String path, String filename, String hcode, String ssopbil, String period, String periodsub, String yearId, String monthId, ProgressBar pb1)
        {
            String h1 = "", h2 = "", h3 = "", h4 = "", h5 = "", h6 = "", h7 = "", h8 = "", h9 = "", dt1 = "", SESSNO = "", Header = "", txtBD = "", txtRow = "", txtBDi = "", txtRowBDi = "", ssDId = "";
            try
            {
                pb1.Show();
                DataTable dtBD = new DataTable();
                DataTable dtBDi = new DataTable();
                SESSNO = mHisDB.ssdDB.selectIDByYearMonth(yearId, monthId);
                dtBD = mHisDB.bdDB.selectByYearMonth(yearId, monthId);

                if (dtBD.Rows.Count > 0)
                {
                    ssDId = dtBD.Rows[0][mHisDB.bdDB.bd.ssdata_id].ToString();
                }
                dtBDi = mHisDB.bdIDB.selectBySSdId(ssDId);
                pb1.Minimum = 0;
                pb1.Maximum = dtBD.Rows.Count + dtBDi.Rows.Count+2;
                pb1.Value = 0;

                dt1 = genFileName(hcode, ssopbil, period, periodsub);
                h1 = @"<?xml version=""1.0"" encoding=""windows-874""?>" + Environment.NewLine;
                h2 = @"<ClaimRec System=""OP"" PayPlan=""SS"" Version=""0.93"">" + Environment.NewLine;
                h3 = "<Header>" + Environment.NewLine;
                h4 = "<HCODE>" + iniC.HCODE + "</HCODE>" + Environment.NewLine;
                //h5 = "<HNAME>" + txtHName.Text + "</HNAME>" + Environment.NewLine;
                h5 = "<HNAME>" + hname + "</HNAME>" + Environment.NewLine;
                h6 = "<DATETIME>" + dt1 + "</DATETIME>" + Environment.NewLine;
                h7 = "<SESSNO>" + SESSNO + "</SESSNO>" + Environment.NewLine;
                h8 = "<RECCOUNT>" + dtBD.Rows.Count + "</RECCOUNT>" + Environment.NewLine;
                h9 = "</Header>" + Environment.NewLine;

                var file = path + "\\" + filename;
                using (StreamWriter sw = new StreamWriter(File.Open(file, FileMode.Create), Encoding.GetEncoding(encoding)))
                {
                    Header = h1 + h2 + h3 + h4 + h5 + h6 + h7 + h8 + h9;
                    foreach (DataRow row in dtBD.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "", col07 = "", col08 = "", col09 = "", col10 = "";
                        String col11 = "", col12 = "", col13 = "", col14 = "", col15 = "", col16 = "", col17 = "", col18 = "";
                        col01 = row[mHisDB.bdDB.bd.providerid].ToString();
                        col02 = row[mHisDB.bdDB.bd.dispid].ToString();
                        col03 = row[mHisDB.bdDB.bd.invno].ToString();
                        col04 = row[mHisDB.bdDB.bd.hn].ToString();
                        col05 = row[mHisDB.bdDB.bd.pid].ToString();
                        col06 = row[mHisDB.bdDB.bd.prescdt].ToString();
                        col07 = row[mHisDB.bdDB.bd.dispdt].ToString();
                        col08 = row[mHisDB.bdDB.bd.prescb].ToString();
                        col09 = row[mHisDB.bdDB.bd.itemcnt].ToString();
                        col10 = row[mHisDB.bdDB.bd.chargeamt].ToString();
                        col11 = row[mHisDB.bdDB.bd.claimamt].ToString();
                        col12 = row[mHisDB.bdDB.bd.paid].ToString();
                        col13 = row[mHisDB.bdDB.bd.otherpay].ToString();
                        col14 = row[mHisDB.bdDB.bd.reimburser].ToString();
                        col15 = row[mHisDB.bdDB.bd.benefitplan].ToString();
                        col16 = row[mHisDB.bdDB.bd.dispestat].ToString();
                        col17 = row[mHisDB.bdDB.bd.svid].ToString();
                        col18 = row[mHisDB.bdDB.bd.daycover].ToString();
                        txtRow += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + "|" + col07 + "|" + col08 + "|" + col09 + "|" + col10
                                + "|" + col11 + "|" + col12 + "|" + col13 + "|" + col14 + "|" + col15 + "|" + col16 + "|" + col17 + "|" + col18 + Environment.NewLine;
                    }
                    foreach (DataRow rowI in dtBDi.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "", col07 = "", col08 = "", col09 = "", col10 = "";
                        String col11 = "", col12 = "", col13 = "", col14 = "", col15 = "", col16 = "", col17 = "", col18 = "", col19 = "";

                        col01 = rowI[mHisDB.bdIDB.bdI.dispid].ToString();
                        col02 = rowI[mHisDB.bdIDB.bdI.prdcat].ToString();
                        col03 = rowI[mHisDB.bdIDB.bdI.hospdrgid].ToString();
                        col04 = rowI[mHisDB.bdIDB.bdI.drgid].ToString();
                        col05 = rowI[mHisDB.bdIDB.bdI.dfscode].ToString();
                        col06 = rowI[mHisDB.bdIDB.bdI.dfstext].ToString();
                        col07 = rowI[mHisDB.bdIDB.bdI.packsize].ToString();
                        col08 = rowI[mHisDB.bdIDB.bdI.sigcode].ToString();
                        col09 = rowI[mHisDB.bdIDB.bdI.sigtext].ToString();
                        col10 = rowI[mHisDB.bdIDB.bdI.quantity].ToString();
                        col11 = rowI[mHisDB.bdIDB.bdI.unitprice].ToString();
                        col12 = rowI[mHisDB.bdIDB.bdI.chargeamt].ToString();
                        col13 = rowI[mHisDB.bdIDB.bdI.reimbprice].ToString();
                        col14 = rowI[mHisDB.bdIDB.bdI.reimbamt].ToString();
                        col15 = rowI[mHisDB.bdIDB.bdI.prdsecode].ToString();
                        col16 = rowI[mHisDB.bdIDB.bdI.claimcont].ToString();
                        col17 = rowI[mHisDB.bdIDB.bdI.claimcat].ToString();
                        col18 = rowI[mHisDB.bdIDB.bdI.multidisp].ToString();
                        col19 = rowI[mHisDB.bdIDB.bdI.supplyfor].ToString();
                        txtRowBDi += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + "|" + col07 + "|" + col08 + "|" + col09 + "|" + col10
                                + "|" + col11 + "|" + col12 + "|" + col13 + "|" + col14 + "|" + col15 + "|" + col16 + "|" + col17 + "|" + col18 + "|" + col19 + Environment.NewLine;
                    }

                    txtBD = "<Dispensing>" + Environment.NewLine + txtRow + "</Dispensing>" + Environment.NewLine +
                        "<DispensedItems>" + Environment.NewLine + txtRowBDi + "</DispensedItems>" + Environment.NewLine + "</ClaimRec>" + Environment.NewLine;
                    String md5 = @"<?EndNote Checksum=""" + genMD5(Header + txtBD) + @"""?>";
                    sw.WriteLine(Header + txtBD+md5);
                }

            }
            catch (IOException ioex)
            {

            }
            pb1.Hide();
            return "1";
        }
        public String genTextOPservice(String hname, String path, String filename, String hcode, String ssopbil, String period, String periodsub, String yearId, String monthId, ProgressBar pb1)
        {
            String h1 = "", h2 = "", h3 = "", h4 = "", h5 = "", h6 = "", h7 = "", h8 = "", h9 = "", dt1 = "", SESSNO = "", Header = "", txtopD = "", txtRow = "", txtBDi = "", txtRowBDi = "", ssDId = "";
            try
            {
                pb1.Show();
                DataTable dtopS = new DataTable();
                DataTable dtopX = new DataTable();
                SESSNO = mHisDB.ssdDB.selectIDByYearMonth(yearId, monthId);
                dtopS = mHisDB.opSDB.selectByYearMonth(yearId, monthId);
                if (dtopS.Rows.Count > 0)
                {
                    ssDId = dtopS.Rows[0][mHisDB.opSDB.opS.ssdata_id].ToString();
                }
                dtopX = mHisDB.opdXDB.selectBySSdId(ssDId);
                pb1.Minimum = 0;
                pb1.Maximum = dtopS.Rows.Count + dtopX.Rows.Count + 2;
                pb1.Value = 0;

                dt1 = genFileName(hcode, ssopbil, period, periodsub);
                h1 = @"<?xml version=""1.0"" encoding=""windows-874""?>" + Environment.NewLine;
                h2 = @"<ClaimRec System=""OP"" PayPlan=""SS"" Version=""0.93"">" + Environment.NewLine;
                h3 = "<Header>" + Environment.NewLine;
                h4 = "<HCODE>" + iniC.HCODE + "</HCODE>" + Environment.NewLine;
                //h5 = "<HNAME>" + txtHName.Text + "</HNAME>" + Environment.NewLine;
                h5 = "<HNAME>" + hname + "</HNAME>" + Environment.NewLine;
                h6 = "<DATETIME>" + dt1 + "</DATETIME>" + Environment.NewLine;
                h7 = "<SESSNO>" + SESSNO + "</SESSNO>" + Environment.NewLine;
                h8 = "<RECCOUNT>" + dtopS.Rows.Count + "</RECCOUNT>" + Environment.NewLine;
                h9 = "</Header>" + Environment.NewLine;

                var file = path + "\\" + filename;
                using (StreamWriter sw = new StreamWriter(File.Open(file, FileMode.Create), Encoding.GetEncoding(encoding)))
                {
                    Header = h1 + h2 + h3 + h4 + h5 + h6 + h7 + h8 + h9;
                    foreach (DataRow row in dtopS.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "", col07 = "", col08 = "", col09 = "", col10 = "";
                        String col11 = "", col12 = "", col13 = "", col14 = "", col15 = "", col16 = "", col17 = "", col18 = "", col19 = "", col20 = "", col21 = "", col22 = "";
                        col01 = row[mHisDB.opSDB.opS.invno].ToString();
                        col02 = row[mHisDB.opSDB.opS.svid].ToString();
                        col03 = row[mHisDB.opSDB.opS.class1].ToString();
                        col04 = row[mHisDB.opSDB.opS.hcode].ToString();
                        col05 = row[mHisDB.opSDB.opS.hn].ToString();
                        col06 = row[mHisDB.opSDB.opS.pid].ToString();
                        col07 = row[mHisDB.opSDB.opS.careaccount].ToString();
                        col08 = row[mHisDB.opSDB.opS.typeserv].ToString();
                        col09 = row[mHisDB.opSDB.opS.typein].ToString();
                        col10 = row[mHisDB.opSDB.opS.typeout].ToString();
                        col11 = row[mHisDB.opSDB.opS.dtappoint].ToString();
                        col12 = row[mHisDB.opSDB.opS.svpid].ToString();
                        col13 = row[mHisDB.opSDB.opS.clinic].ToString();
                        col14 = row[mHisDB.opSDB.opS.begdt].ToString();
                        col15 = row[mHisDB.opSDB.opS.enddt].ToString();
                        col16 = row[mHisDB.opSDB.opS.lccode].ToString();
                        col17 = row[mHisDB.opSDB.opS.codeset].ToString();
                        col18 = row[mHisDB.opSDB.opS.stdcode].ToString();
                        col19 = row[mHisDB.opSDB.opS.svcharge].ToString();
                        col20 = row[mHisDB.opSDB.opS.completion].ToString();
                        col21 = row[mHisDB.opSDB.opS.svtxcode].ToString();
                        col22 = row[mHisDB.opSDB.opS.claimcat].ToString();
                        txtRow += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + "|" + col07 + "|" + col08 + "|" + col09 + "|" + col10
                                + "|" + col11 + "|" + col12 + "|" + col13 + "|" + col14 + "|" + col15 + "|" + col16 + "|" + col17 + "|" + col18 + "|" + col19 + "|" + col20 
                                + "|" + col21 + "|" + col22 + Environment.NewLine;
                    }
                    foreach (DataRow rowI in dtopX.Rows)
                    {
                        pb1.Value++;
                        String col01 = "", col02 = "", col03 = "", col04 = "", col05 = "", col06 = "";
                        col01 = rowI[mHisDB.opdXDB.opDX.class1].ToString();
                        col02 = rowI[mHisDB.opdXDB.opDX.svid].ToString();
                        col03 = rowI[mHisDB.opdXDB.opDX.sl].ToString();
                        col04 = rowI[mHisDB.opdXDB.opDX.codeset].ToString();
                        col05 = rowI[mHisDB.opdXDB.opDX.code].ToString();
                        col06 = rowI[mHisDB.opdXDB.opDX.desc1].ToString();
                        txtRowBDi += col01 + "|" + col02 + "|" + col03 + "|" + col04 + "|" + col05 + "|" + col06 + Environment.NewLine;
                    }
                    txtopD = "<OPServices>" + Environment.NewLine + txtRow + "</OPServices>" + Environment.NewLine +
                        "<OPDx>" + Environment.NewLine + txtRowBDi + "</OPDx>" + Environment.NewLine + "</ClaimRec>" + Environment.NewLine;
                    String md5 = @"<?EndNote Checksum=""" + genMD5(Header + txtopD) + @"""?>";
                    sw.WriteLine(Header + txtopD+ md5);
                }
            }
            catch (IOException ioex)
            {

            }
            pb1.Hide();
            return "1";
        }


        public String[] getFileinFolder(String path)
        {
            string[] filePaths = null;
            if (Directory.Exists(path))
            {
                filePaths = Directory.GetFiles(@path);
            }

            return filePaths;
        }
        public void genZipFile(String sourcePathFile,String filenameZip)
        {
            string[] filePaths = null;
            filePaths = getFileinFolder(@sourcePathFile);
            using (ZipArchive zip = ZipFile.Open(filenameZip, ZipArchiveMode.Create))
            {
                foreach(String filename in filePaths)
                {
                    String file = filename.Replace(sourcePathFile+"\\", "");
                    zip.CreateEntryFromFile(filename, file);
                }
            }
        }
        public void sendEmail(String filename)
        {
            //var fromAddress = new MailAddress(iniC.EmailUsername, "");
            //var toAddress = new MailAddress(iniC.APPROVER_EMAIL, "To Name");
            ////var toAddress2 = new MailAddress("amo@iceconsulting.co.th", "To Name");
            //var toAddress3 = new MailAddress("ekk@ii.co.th", "To Name");
            //var toAddress4 = new MailAddress("vrw@ii.co.th", "To Name");// for test
            //String fromPassword = iniC.EmailPassword;
            //const string subject = "test";
            //DataTable dt006;
            ////dt006 = xCPrTDB.selectPRPO006GroupByVendor();
            ////if (dt006.Rows.Count <= 0) return;
            //string Body = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\" + "email_regis.html");
            //Body = Body.Replace("#vendorName#", vendorName);

            //int port = 0;
            //int.TryParse(Cm.initC.EmailPort, out port);

            //var smtp1 = new SmtpClient
            //{
            //    //Host = "smtp.office365.com",
            //    Host = Cm.initC.EmailHost,
            //    //Port = 587,
            //    Port = port,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            //    Timeout = 20000
            //};

            //var message = new MailMessage();
            //message.From = fromAddress;
            //message.Subject = "PO006 " + vendorName;
            //message.To.Add(toAddress);
            ////message.To.Add(toAddress2);
            //message.To.Add(toAddress3);
            //message.To.Add(toAddress4);// for test
            //message.IsBodyHtml = true;
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            ////MessageBox.Show(""+ @Environment.CurrentDirectory, "");
            //LinkedResource LinkedImage = new LinkedResource(@Environment.CurrentDirectory + "\\" + "logo_ice_consulting.png");
            //LinkedImage.ContentId = "logo_ice";
            ////Added the patch for Thunderbird as suggested by Jorge
            //LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
            //htmlView.LinkedResources.Add(LinkedImage);
            //message.AlternateViews.Add(htmlView);
            
            //Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(iniC.PO006PathInitial + filename);
            //message.Attachments.Add(attachment);
            ////}
            ////}
            ////}
            ////}
            //message.Body = Body;
            //smtp1.Send(message);
        }
        public String setTimeCurrent()
        {
            return String.Format("{0:HHmm}", System.DateTime.Now);
        }
        public String genMD5(String contents)
        {
            //String source = "Hello World!";
            //String contents = File.ReadAllText(@filename);
            String hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, contents);
                //Console.WriteLine("The MD5 hash of " + contents + " is: " + hash + ".");
                //Console.WriteLine("Verifying the hash...");
                if (VerifyMd5Hash(md5Hash, contents, hash))
                {
                    //Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    //Console.WriteLine("The hashes are not same.");
                }
            }
            return hash;
        }
        private String GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public String getMapPayPlan(String payplan)
        {
            String re = "";
            if (payplan.Equals("2211041"))
            {
                re = "24036";       //บางนา5
            }
            else if (payplan.Equals("2211006"))
            {
                re = "11772";       //บางนา2
            }
            else if (payplan.Equals("2210028"))
            {
                re = "11592";       //บางนา1
            }
            return re;
        }
    }
}
