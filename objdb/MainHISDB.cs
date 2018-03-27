using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData.objdb
{
    public class MainHISDB
    {
        String sqlOPD = "";
        String sqlIPD = "";
        String sqlCronic = "";

        ConnectDB conn;
        TSsdataDB ssdDB;
        TSsdataVisitDB ssdVDB;

        TSsdata ssd;
        public MainHISDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ssd = new TSsdata();
            ssdDB = new TSsdataDB(conn);
            ssdVDB = new TSsdataVisitDB(conn);

            sqlIPD = "SELECT DISTINCT " +
                        "patt08.MNC_HN_YR, patt08.MNC_HN_NO, patt08.MNC_DATE, patt08.MNC_PRE_NO, fint01.MNC_FN_TYP_CD,  " +
                        "patm02.MNC_PFIX_DSC + ' ' + patm01.MNC_FNAME_T + ' ' + patm01.MNC_LNAME_T AS FName, patm01.MNC_ID_NO, patt08.MNC_AN_NO,  " +
                        "patt08.MNC_AN_YR, patt08.MNC_AD_DATE, patt08.MNC_AD_TIME, patt08.MNC_DS_TIME, patt08.MNC_DS_DATE, patt08.MNC_WD_NO,  " +
                        "patt08.MNC_DOT_CD_S, patt08.MNC_DS_CD, patt08.MNC_DS_TYP_CD, fint01.MNC_DOC_YR, fint01.MNC_DOC_NO, fint01.MNC_DOC_DAT,  " +
                        "patm01.MNC_BDAY, patm01.MNC_SEX, fint01.MNC_SUM_PRI, patt08.MNC_REF_CD, DATEDIFF([day], patt08.MNC_AD_DATE, patt08.MNC_DS_DATE) " +
                        "AS no_of_day, patm01.MNC_ID_NAM, dbo.PRAKUN_M01.PrakanCode, fint01.MNC_PRAKUN_CODE " +
                        "FROM         dbo.PATIENT_M02 patm02 RIGHT OUTER JOIN " +
                        "dbo.PRAKUN_M01 INNER JOIN " +
                        "dbo.PATIENT_M01 patm01 ON dbo.PRAKUN_M01.SocialID = patm01.MNC_ID_NO RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T08 patt08 ON patm01.MNC_HN_YR = patt08.MNC_HN_YR AND patm01.MNC_HN_NO = patt08.MNC_HN_NO ON " +
                        "patm02.MNC_PFIX_CD = patm01.MNC_PFIX_CDT LEFT OUTER JOIN " +
                        "dbo.FINANCE_M02 INNER JOIN " +
                        "dbo.FINANCE_T01 fint01 ON dbo.FINANCE_M02.MNC_FN_TYP_CD = fint01.MNC_FN_TYP_CD ON patt08.MNC_HN_YR = fint01.MNC_HN_YR AND " +
                        "patt08.MNC_HN_NO = fint01.MNC_HN_NO AND patt08.MNC_PRE_NO = fint01.MNC_PRE_NO AND patt08.MNC_DATE = fint01.MNC_DATE AND " +
                        "fint01.MNC_DOC_CD = 'IN3' " +
                        "WHERE     (MONTH(patt08.MNC_DS_DATE) = :pmonth) AND(YEAR(patt08.MNC_DS_DATE) = :pyear) AND(patt08.MNC_AD_STS = 'D') AND(patt08.MNC_DIAG_STS = 'Y') AND " +
                        "(patm01.MNC_ID_NO IS NOT NULL) AND(fint01.MNC_DOC_STS<> 'V') AND(dbo.FINANCE_M02.MNC_FN_STS = 'S') AND(patm01.MNC_ID_NO<> '') " +
                        "AND(dbo.FINANCE_M02.MNC_FN_STS = 'S') AND(fint01.MNC_PRAKUN_CODE = :HOSID OR " +
                        "fint01.MNC_PRAKUN_CODE IS NULL) AND(dbo.PRAKUN_M01.PrakanCode = :HOSID1 OR " +
                        "dbo.PRAKUN_M01.PrakanCode IS NULL) and(dbo.PRAKUN_M01.PrakanCode IS NULL or fint01.MNC_PRAKUN_CODE IS NULL) " +
                        "AND(fint01.MNC_HN_NO like :HNNo) " +
                        "ORDER BY fint01.MNC_doc_dat";
            sqlCronic = "SELECT DISTINCT " +
                        "TOP 100 PERCENT patt09.MNC_HN_YR, patt09.MNC_HN_NO, patt09.MNC_DATE, patm18.MNC_CRO_CD, patm184.MNC_CRO_DESC, " +
                        "patm02.MNC_PFIX_DSC + ' ' + patm01.MNC_FNAME_T + ' ' + patm01.MNC_LNAME_T AS FName, patm01.MNC_ID_NO, patm01.MNC_BDAY, " +
                        "patm01.MNC_SEX, patt01.MNC_DOT_CD, dbo.FINANCE_T01.MNC_FN_TYP_CD, dbo.PRAKUN_M01_TEMP.PrakanCode, " +
                        "dbo.FINANCE_T01.MNC_PRAKUN_CODE " +
                        "FROM         dbo.PRAKUN_M01_TEMP RIGHT OUTER JOIN " +
                        "dbo.PATIENT_M01 patm01 ON dbo.PRAKUN_M01_TEMP.SocialID = patm01.MNC_ID_NO RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T09 patt09 LEFT OUTER JOIN " +
                        "dbo.PATIENT_M18 patm18 ON patt09.MNC_DIA_CD = patm18.MNC_DIA_CD LEFT OUTER JOIN " +
                        "dbo.PATIENT_M184 patm184 ON patm18.MNC_CRO_CD = patm184.MNC_CRO_CD ON patm01.MNC_HN_YR = patt09.MNC_HN_YR AND " +
                        "patm01.MNC_HN_NO = patt09.MNC_HN_NO LEFT OUTER JOIN " +
                        "dbo.PATIENT_M02 patm02 ON patm01.MNC_PFIX_CDT = patm02.MNC_PFIX_CD LEFT OUTER JOIN " +
                        "dbo.FINANCE_M02 INNER JOIN " +
                        "dbo.FINANCE_T01 ON dbo.FINANCE_M02.MNC_FN_TYP_CD = dbo.FINANCE_T01.MNC_FN_TYP_CD RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T01 patt01 ON dbo.FINANCE_T01.MNC_HN_NO = patt01.MNC_HN_NO AND dbo.FINANCE_T01.MNC_HN_YR = patt01.MNC_HN_YR AND " +
                        "dbo.FINANCE_T01.MNC_PRE_NO = patt01.MNC_PRE_NO AND dbo.FINANCE_T01.MNC_DATE = patt01.MNC_DATE ON " +
                        "patt09.MNC_HN_YR = patt01.MNC_HN_YR AND patt09.MNC_HN_NO = patt01.MNC_HN_NO AND patt09.MNC_PRE_NO = patt01.MNC_PRE_NO " +
                        "WHERE     (patm18.MNC_CRO_Flag = '1')  AND(patt09.MNC_DATE between :Fromdate and :Todate)  AND " +
                        "(dbo.FINANCE_M02.MNC_FN_STS = 'S') AND(FINANCE_T01.MNC_PRAKUN_CODE = :HOSID OR " +
                        "FINANCE_T01.MNC_PRAKUN_CODE IS NULL) AND(dbo.PRAKUN_M01_TEMP.PrakanCode = :HOSID1 OR " +
                        "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL) " +
                        "ORDER BY patm18.MNC_CRO_CD, patt09.MNC_HN_NO";
        }
        public DataTable selectSSData(String hcode,String yearId, String monthId)
        {
            String whereHCODE = "", startDate="", endDate="", whereDate="";
            DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId)+1, 1);
            dateEnd = dateEnd.AddDays(-1);
            whereHCODE = whereHCODE.Equals("") ? "" : " AND (fint01.MNC_PRAKUN_CODE = '"+ hcode + "' OR " + "fint01.MNC_PRAKUN_CODE IS NULL) " +
                "AND(dbo.PRAKUN_M01_TEMP.PrakanCode = '" + hcode + "' OR " + "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL) ";
            startDate = yearId + "-"+ monthId + "-01";
            endDate = yearId + "-" + dateEnd.Month.ToString("00") + "-" + dateEnd.Day.ToString("00");
            whereDate = "AND (patt01.MNC_DATE BETWEEN '"+ startDate + "' AND '"+ endDate + "')";

            DataTable dt = new DataTable();
            sqlOPD = "SELECT patt01.MNC_HN_YR, patt01.MNC_HN_NO, patt01.MNC_DATE, patm01.MNC_FNAME_T, patm01.MNC_LNAME_T, " +
                        "patm01.MNC_ID_NO, patm01.MNC_BDAY, patm01.MNC_SEX, dbo.PRAKUN_M01_TEMP.PrakanCode, SUM(fint01.MNC_SUM_PRI) AS MNC_SUM_PRI, " +
                        "patt01.MNC_REF_CD, fint01.MNC_PRAKUN_CODE, patm02.MNC_PFIX_DSC, " +
                        "patt01.mnc_vn_no, patt01.mnc_vn_seq, patt01.mnc_vn_sum, patt01.mnc_pre_no " +
                        "FROM  dbo.FINANCE_M02 INNER JOIN dbo.FINANCE_T01 fint01 ON dbo.FINANCE_M02.MNC_FN_TYP_CD = fint01.MNC_FN_TYP_CD " +
                        "RIGHT OUTER JOIN dbo.PATIENT_M02 patm02 RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T01 patt01 LEFT OUTER JOIN " +
                        "dbo.PRAKUN_M01_TEMP RIGHT OUTER JOIN " +
                        "dbo.PATIENT_M01 patm01 ON dbo.PRAKUN_M01_TEMP.SocialID = patm01.MNC_ID_NO ON patt01.MNC_HN_YR = patm01.MNC_HN_YR AND " +
                        "patt01.MNC_HN_NO = patm01.MNC_HN_NO ON patm02.MNC_PFIX_CD = patm01.MNC_PFIX_CDT ON fint01.MNC_HN_YR = patt01.MNC_HN_YR AND " +
                        "fint01.MNC_HN_NO = patt01.MNC_HN_NO AND fint01.MNC_PRE_NO = patt01.MNC_PRE_NO AND fint01.MNC_DATE = patt01.MNC_DATE AND " +
                        "fint01.MNC_DOC_CD = 'ON3' " +
                        "WHERE     (patt01.MNC_ADM_FLG<> 'A') AND(patt01.MNC_DIAG_STS = 'Y') AND " +
                        "(fint01.MNC_DOC_STS = 'F') AND(dbo.FINANCE_M02.MNC_FN_STS = 'S') " +
                        whereHCODE +
                        "AND((patm01.MNC_ID_NO <> '' or patm01.MNC_ID_NO is not null)) AND " +
                        "(patt01.MNC_AMP_FLG <> 'Y')  " +
                        whereDate +
                        //"and(patm01.mnc_hn_no like :HNNo) " +
                        "GROUP BY patt01.MNC_HN_YR, patt01.MNC_HN_NO, patt01.MNC_DATE, patm01.MNC_FNAME_T, patm01.MNC_LNAME_T, patm01.MNC_ID_NO,  " +
                        "patm01.MNC_BDAY, patm01.MNC_SEX, dbo.PRAKUN_M01_TEMP.PrakanCode, patt01.MNC_REF_CD, fint01.MNC_PRAKUN_CODE,  " +
                        "patm02.MNC_PFIX_DSC, patt01.mnc_vn_no, patt01.mnc_vn_seq, patt01.mnc_vn_sum, patt01.mnc_pre_no " +
                        "ORDER BY patt01.MNC_DATE, patt01.MNC_HN_NO";

            dt = conn.selectData(conn.connMainHIS, sqlOPD);

            return dt;
        }
        public void insertTSSData(String hcode, String branchId, String yearId, String monthId, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();

            conn.OpenConnectionSSData();
            dt =selectSSData(hcode, yearId, monthId);
            pb1.Minimum = 1;
            pb1.Maximum = dt.Rows.Count + 1;
            pb1.Value = 1;
            //txtCnt.Value = dt.Rows.Count;
            TSsdata ssd = new TSsdata();
            ssd.branch_id = "";
            ssd.branch_visit_id = "";
            ssd.cnt_hn = "";
            ssd.cnt_visit = "";
            ssd.month_id = monthId;
            ssd.year_id = yearId;
            ssd.status_precess = "0";
            ssd.ssdata_id =  ssdDB.insert(ssd);

            foreach (DataRow row in dt.Rows)
            {
                pb1.Value++;
                TSsdataVisit ssV = new TSsdataVisit();
                String visitDate = "";
                String birDate = "";

                visitDate = datetoDB(row["MNC_DATE"].ToString());
                birDate = datetoDB(row["MNC_BDAY"].ToString());

                ssV.birth_day = birDate;
                ssV.branch_id = branchId;
                ssV.hcode = hcode;
                ssV.hcode_owner = row["PrakanCode"].ToString();
                ssV.hn_no = row["MNC_HN_NO"].ToString();
                ssV.hn_yr = row["MNC_HN_YR"].ToString();
                ssV.pid = row["MNC_ID_NO"].ToString();
                ssV.patient_fname = row["MNC_FNAME_T"].ToString();
                ssV.patient_lname = row["MNC_LNAME_T"].ToString();
                ssV.prefix = row["MNC_PFIX_DSC"].ToString();

                ssV.pre_no = row["mnc_pre_no"].ToString();
                ssV.sex = row["MNC_SEX"].ToString();
                ssV.ssdata_id = ssd.ssdata_id;
                ssV.visit_date = visitDate;
                ssV.visit_time = visitDate;
                ssV.vn = row["mnc_vn_no"].ToString()+"."+ row["mnc_vn_seq"].ToString() + "." + row["mnc_vn_sum"].ToString();
                ssV.vn_no = row["mnc_vn_no"].ToString();
                ssV.vn_seq = row["mnc_vn_seq"].ToString();
                ssV.vn_sum = row["mnc_vn_sum"].ToString();
                ssV.paid = row["mnc_sum_pri"].ToString();
                ssV.month_id = monthId;
                ssV.year_id = yearId;
                ssdVDB.insert(ssV);



            }
            conn.CloseConnectionSSData();
            pb1.Hide();
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
    }
}
