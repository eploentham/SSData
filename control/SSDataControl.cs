using C1.Win.C1List;
using SSData.objdb;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public C1Combo setCboYear(C1Combo c)
        {
            c.ClearItems();
            c.AddItem(DateTime.Now.Year.ToString());
            c.AddItem(String.Concat(DateTime.Now.Year-1));
            c.AddItem(String.Concat(DateTime.Now.Year-2));
            //c.Items.Clear();
            //c.Items.Add(System.DateTime.Now.Year + 543);
            //c.Items.Add(System.DateTime.Now.Year + 543 - 1);
            //c.Items.Add(System.DateTime.Now.Year + 543 - 2);
            //c.SelectedIndex = c.FindStringExact(String.Concat(System.DateTime.Now.Year + 543));
            return c;
        }
        public C1Combo setCboMonth(C1Combo c)
        {
            c.ClearItems();
            //c.Items.Clear();
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
                        return String.Concat((dt1.Year + 543), "-") + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
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
    }
}
