
using SSData.objdb;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
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
        public String monthId = "", yearId = "", ssVid="";

        public enum TypeOut { Discharge=1, Admin=2, Refer=3, Dead=4, Escape=5, Other=9}
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

                    sw.WriteLine(Header + txtBT);
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
                    sw.WriteLine(Header + txtBD);
                }

            }
            catch (IOException ioex)
            {

            }
            pb1.Hide();
            return "1";
        }
    }
}
