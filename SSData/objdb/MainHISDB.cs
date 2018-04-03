using FarPoint.Win.Spread;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        public BDrugCatalogueDB dCDB;
        TSsdataVisitBillDispItemsDB ssdVBIDB;
        TSsdataVisitBillDispDB ssdVBDB;
        BillTranDB btDB;

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
            dCDB = new BDrugCatalogueDB(conn);
            ssdVBIDB = new TSsdataVisitBillDispItemsDB(conn);
            ssdVBDB = new TSsdataVisitBillDispDB(conn);
            btDB = new BillTranDB(conn);

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
                        "patt01.mnc_vn_no, patt01.mnc_vn_seq, patt01.mnc_vn_sum, patt01.mnc_pre_no, fint01.mnc_doc_cd, fint01.mnc_doc_no, fint01.MNC_Doc_CD, " +
                        //"fint01.mnc_doc_yr, patt01.mnc_dot_cd, m26.MNC_DOT_FNAME,m26.MNC_DOT_LNAME,m021.MNC_PFIX_DSC as prefixdoc " +
                        "fint01.mnc_doc_yr, patt01.mnc_dot_cd  " +
                        //"fint01.mnc_doc_yr, patt01.mnc_dot_cd, phart01.mnc_req_dat " +
                        "FROM  dbo.FINANCE_M02 INNER JOIN dbo.FINANCE_T01 fint01 ON dbo.FINANCE_M02.MNC_FN_TYP_CD = fint01.MNC_FN_TYP_CD " +
                        "RIGHT OUTER JOIN dbo.PATIENT_M02 patm02 RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T01 patt01 LEFT OUTER JOIN " +
                        "dbo.PRAKUN_M01_TEMP RIGHT OUTER JOIN " +
                        "dbo.PATIENT_M01 patm01 ON dbo.PRAKUN_M01_TEMP.SocialID = patm01.MNC_ID_NO ON patt01.MNC_HN_YR = patm01.MNC_HN_YR AND " +
                        "patt01.MNC_HN_NO = patm01.MNC_HN_NO ON patm02.MNC_PFIX_CD = patm01.MNC_PFIX_CDT ON fint01.MNC_HN_YR = patt01.MNC_HN_YR AND " +
                        "fint01.MNC_HN_NO = patt01.MNC_HN_NO AND fint01.MNC_PRE_NO = patt01.MNC_PRE_NO AND fint01.MNC_DATE = patt01.MNC_DATE AND " +
                        "fint01.MNC_DOC_CD = 'ON3' " +
                        //"Left Join PHARMACY_T01 phart01 on patt01.MNC_HN_NO = phart01.MNC_HN_NO and patt01.MNC_PRE_NO = phart01.MNC_PRE_NO and patt01.MNC_DATE = phart01.MNC_DATE " +
                        //"Left join patient_m26 m26 ON patt01.MNC_DOT_CD = m26.MNC_DOT_CD " +
                        //"Left join patient_m02 m021 on m26.MNC_DOT_PFIX = m021.MNC_PFIX_CD " +                        
                        "WHERE     (patt01.MNC_ADM_FLG<> 'A') AND(patt01.MNC_DIAG_STS = 'Y') AND " +
                        "(fint01.MNC_DOC_STS = 'F') AND(dbo.FINANCE_M02.MNC_FN_STS = 'S') " +
                        whereHCODE +
                        "AND((patm01.MNC_ID_NO <> '' or patm01.MNC_ID_NO is not null)) AND " +
                        "(patt01.MNC_AMP_FLG <> 'Y')  " +
                        whereDate +
                        //"and(patm01.mnc_hn_no like :HNNo) " +
                        "GROUP BY patt01.MNC_HN_YR, patt01.MNC_HN_NO, patt01.MNC_DATE, patm01.MNC_FNAME_T, patm01.MNC_LNAME_T, patm01.MNC_ID_NO,  " +
                        "patm01.MNC_BDAY, patm01.MNC_SEX, dbo.PRAKUN_M01_TEMP.PrakanCode, patt01.MNC_REF_CD, fint01.MNC_PRAKUN_CODE,  " +
                        "patm02.MNC_PFIX_DSC, patt01.mnc_vn_no, patt01.mnc_vn_seq, patt01.mnc_vn_sum, patt01.mnc_pre_no, fint01.mnc_doc_cd, fint01.mnc_doc_no, " +
                        //"fint01.MNC_Doc_CD,fint01.mnc_doc_yr, patt01.mnc_dot_cd, m26.MNC_DOT_FNAME,m26.MNC_DOT_LNAME,m021.MNC_PFIX_DSC  " +
                        "fint01.MNC_Doc_CD,fint01.mnc_doc_yr, patt01.mnc_dot_cd  " +
                        "ORDER BY patt01.MNC_DATE, patt01.MNC_HN_NO, patt01.mnc_pre_no";

            dt = conn.selectData(conn.connMainHIS, sqlOPD);

            return dt;
        }
        public DataTable selectSSDataItem(String hn, String vnno, String preno, String visitDate, String dispid)
        {
            String sql = "", where="";
            //DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
            //dateEnd = dateEnd.AddDays(-1);
            //whereHCODE = whereHCODE.Equals("") ? "" : " AND (fint01.MNC_PRAKUN_CODE = '" + hcode + "' OR " + "fint01.MNC_PRAKUN_CODE IS NULL) " +
            //    "AND(dbo.PRAKUN_M01_TEMP.PrakanCode = '" + hcode + "' OR " + "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL) ";
            //startDate = yearId + "-" + monthId + "-01";
            //endDate = yearId + "-" + dateEnd.Month.ToString("00") + "-" + dateEnd.Day.ToString("00");
            where = " t01.mnc_hn_no = '"+ hn + "' and t01.mnc_vn_no = '"+ vnno + "' and t01.MNC_PRE_NO = '"+ preno + "' and  phart05.MNC_CFR_NO='"+dispid+"' ";

            DataTable dt = new DataTable();
            sql = "Select phart06.MNC_PH_CD, pharmacy_m01.MNC_PH_TN ,PHARMACY_M05.MNC_PH_PRI01,PHARMACY_M05.MNC_PH_PRI02,sum(phart06.MNC_PH_QTY) as qty," +
                "phart05.mnc_cfg_dat,phart06.mnc_ord_no " +
                "From PATIENT_T01 t01 " +
                "left join PHARMACY_T05 phart05 on t01.MNC_PRE_NO = phart05.MNC_PRE_NO and t01.MNC_date = phart05.mnc_date and t01.mnc_hn_no = phart05.mnc_hn_no " +
                "left join PHARMACY_T06 phart06 on phart05.MNC_CFR_NO = phart06.MNC_CFR_NO and phart05.MNC_CFG_DAT = phart06.MNC_CFR_dat " +
                "left join PHARMACY_M01 on phart06.MNC_PH_CD = pharmacy_m01.MNC_PH_CD " +
                "left join PHARMACY_M05 on PHARMACY_M05.MNC_PH_CD = PHARMACY_M01.MNC_PH_CD " +
                "where " +
                //"--t01.MNC_DATE BETWEEN '' AND '' and " +
                //"-- t01.MNC_FN_TYP_CD in ('44', '45', '46', '47', '48', '49') " + " and " +
                where+
                //"    t01.mnc_hn_no = '5085115' " +
                //"--and t01.MNC_DATE = '2014-08-17' " +
                //"--PHARMACY_M01.mnc_ph_typ_flg = 'P' " +
                //"and t01.mnc_vn_no = '58' and t01.MNC_PRE_NO = '61' " +
                "and phart05.MNC_CFR_STS = 'a' " +
                "Group By phart06.MNC_PH_CD, pharmacy_m01.MNC_PH_TN ,PHARMACY_M05.MNC_PH_PRI01,PHARMACY_M05.MNC_PH_PRI02,phart05.mnc_cfg_dat,phart06.mnc_ord_no " +
                "Order By phart06.mnc_ord_no, phart06.MNC_PH_CD " +
                "; ";

            dt = conn.selectData(conn.connMainHIS, sql);

            return dt;
        }
        public DataTable selectSSDataDispItem(String hn, String vnno, String preno, String visitDate, String dispid)
        {
            String sql = "", where = "";
            //DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
            //dateEnd = dateEnd.AddDays(-1);
            //whereHCODE = whereHCODE.Equals("") ? "" : " AND (fint01.MNC_PRAKUN_CODE = '" + hcode + "' OR " + "fint01.MNC_PRAKUN_CODE IS NULL) " +
            //    "AND(dbo.PRAKUN_M01_TEMP.PrakanCode = '" + hcode + "' OR " + "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL) ";
            //startDate = yearId + "-" + monthId + "-01";
            //endDate = yearId + "-" + dateEnd.Month.ToString("00") + "-" + dateEnd.Day.ToString("00");
            where = " t01.mnc_hn_no = '" + hn + "' and t01.mnc_vn_no = '" + vnno + "' and t01.MNC_PRE_NO = '" + preno + "' and  phart05.MNC_CFR_NO='" + dispid + "' ";

            DataTable dt = new DataTable();
            sql = "Select phart06.MNC_PH_CD, pharmacy_m01.MNC_PH_TN ,PHARMACY_M05.MNC_PH_PRI01,PHARMACY_M05.MNC_PH_PRI02,sum(phart06.MNC_PH_QTY) as qty," +
                "phart05.mnc_cfg_dat,phart06.mnc_ord_no " +
                "From PATIENT_T01 t01 " +
                "left join PHARMACY_T05 phart05 on t01.MNC_PRE_NO = phart05.MNC_PRE_NO and t01.MNC_date = phart05.mnc_date and t01.mnc_hn_no = phart05.mnc_hn_no " +
                "left join PHARMACY_T06 phart06 on phart05.MNC_CFR_NO = phart06.MNC_CFR_NO and phart05.MNC_CFG_DAT = phart06.MNC_CFR_dat " +
                "left join PHARMACY_M01 on phart06.MNC_PH_CD = pharmacy_m01.MNC_PH_CD " +
                "left join PHARMACY_M05 on PHARMACY_M05.MNC_PH_CD = PHARMACY_M01.MNC_PH_CD " +
                "where " +
                //"--t01.MNC_DATE BETWEEN '' AND '' and " +
                //"-- t01.MNC_FN_TYP_CD in ('44', '45', '46', '47', '48', '49') " + " and " +
                where +
                //"    t01.mnc_hn_no = '5085115' " +
                //"--and t01.MNC_DATE = '2014-08-17' " +
                //"--PHARMACY_M01.mnc_ph_typ_flg = 'P' " +
                //"and t01.mnc_vn_no = '58' and t01.MNC_PRE_NO = '61' " +
                "and phart05.MNC_CFR_STS = 'a' " +
                "Group By phart06.MNC_PH_CD, pharmacy_m01.MNC_PH_TN ,PHARMACY_M05.MNC_PH_PRI01,PHARMACY_M05.MNC_PH_PRI02,phart05.mnc_cfg_dat,phart06.mnc_ord_no " +
                "Order By phart06.mnc_ord_no, phart06.MNC_PH_CD " +
                "; ";

            dt = conn.selectData(conn.connMainHIS, sql);

            return dt;
        }
        public DataTable selectSSDataBillDisp(String hn, String vnno, String preno, String visitDate)
        {
            String sql = "", where = "";
            
            where = " t01.mnc_hn_no = '" + hn + "' and t01.mnc_vn_no = '" + vnno + "' and t01.MNC_PRE_NO = '" + preno + "' ";

            DataTable dt = new DataTable();
            sql = "Select phart05.mnc_cfg_dat , phart05.MNC_CFR_NO, sum(phart06.mnc_ph_pri * phart06.mnc_ph_qty) as amt, count(1) as cnt,sum(phart06.mnc_ph_pri) as pri, phart01.mnc_req_dat " +
                "From PATIENT_T01 t01 " +
                "left join pharmacy_t01 phart01 on t01.MNC_PRE_NO = phart01.MNC_PRE_NO and t01.MNC_date = phart01.mnc_date and t01.mnc_hn_no = phart01.mnc_hn_no " +
                "left join PHARMACY_T05 phart05 on t01.MNC_PRE_NO = phart05.MNC_PRE_NO and t01.MNC_date = phart05.mnc_date and t01.mnc_hn_no = phart05.mnc_hn_no  " +
                "left join PHARMACY_T06 phart06 on phart05.MNC_CFR_NO = phart06.MNC_CFR_NO and phart05.MNC_CFG_DAT = phart06.MNC_CFR_dat " +
                "where " +
                where +
                "and phart05.MNC_CFR_STS = 'a' " +
                "Group By phart05.mnc_cfg_dat , phart05.MNC_CFR_NO , phart01.mnc_req_dat " +  
                "Order By phart05.mnc_cfg_dat , phart05.MNC_CFR_NO " +
                "; ";

            dt = conn.selectData(conn.connMainHIS, sql);

            return dt;
        }
        public String selectPrescdt(String hn, String preno, String visitDate)
        {
            String sql = "", where = "", prescdt="";
            //DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
            //dateEnd = dateEnd.AddDays(-1);
            //whereHCODE = whereHCODE.Equals("") ? "" : " AND (fint01.MNC_PRAKUN_CODE = '" + hcode + "' OR " + "fint01.MNC_PRAKUN_CODE IS NULL) " +
            //    "AND(dbo.PRAKUN_M01_TEMP.PrakanCode = '" + hcode + "' OR " + "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL) ";
            //startDate = yearId + "-" + monthId + "-01";
            //endDate = yearId + "-" + dateEnd.Month.ToString("00") + "-" + dateEnd.Day.ToString("00");
            where = " phart01.mnc_hn_no = '" + hn + "' and phart01.mnc_date = '" + visitDate + "' and phart01.MNC_PRE_NO = '" + preno + "' ";

            DataTable dt = new DataTable();
            sql = "Select phart01.* " +
                "From  PHARMACY_T01 phart01  " +
                "where " +
                //"--t01.MNC_DATE BETWEEN '' AND '' and " +
                //"-- t01.MNC_FN_TYP_CD in ('44', '45', '46', '47', '48', '49') " + " and " +
                where +                
                "; ";

            dt = conn.selectData(conn.connMainHIS, sql);
            if (dt.Rows.Count > 0)
            {
                prescdt = dt.Rows[0]["mnc_req_dat"].ToString();
            }
            return prescdt;
        }
        public void insertDrugCat(FpSpread grd, ProgressBar pb1)
        {
            String re = "", drugId="";
            int colCode = 0, colProd = 1, colTmt = 2, colSpec = 3, colGene = 4, colTrad = 5, colDfs = 6, colDos = 7, colStr = 8, colCont = 9;
            int colDist = 10, colManu = 11, colIsed = 12, colNdc = 13, colUnitS = 14, colUnitP = 15, colUpF = 16, colDatC = 17, colDatU = 18, colDatE = 19, colID = 20;

            pb1.Show();

            conn.OpenConnectionMainHIS();
            conn.OpenConnectionSSData();

            pb1.Minimum = 1;
            pb1.Maximum = grd.Sheets[1].Rows.Count;
            for(int i=0; i< grd.Sheets[1].Rows.Count; i++)
            {
                if(i == 0) continue;
                BDrugCatalogue drug = new BDrugCatalogue();
                drug.hospdrugcode = grd.Sheets[1].Cells[i, colCode].Value == null ? "" : grd.Sheets[1].Cells[i, colCode].Value.ToString();
                drug.productcat = grd.Sheets[1].Cells[i, colProd].Value == null ? "" : grd.Sheets[1].Cells[i, colProd].Value.ToString();
                drug.tmtid = grd.Sheets[1].Cells[i, colTmt].Value == null ? "" : grd.Sheets[1].Cells[i, colTmt].Value.ToString();
                drug.specprep = grd.Sheets[1].Cells[i, colSpec].Value == null ? "" : grd.Sheets[1].Cells[i, colSpec].Value.ToString();
                drug.genericname = grd.Sheets[1].Cells[i, colGene].Value == null ? "" : grd.Sheets[1].Cells[i, colGene].Value.ToString();
                drug.tradename = grd.Sheets[1].Cells[i, colTrad].Value == null ? "" : grd.Sheets[1].Cells[i, colTrad].Value.ToString();
                drug.dfscode = grd.Sheets[1].Cells[i, colDfs].Value == null ? "" : grd.Sheets[1].Cells[i, colDfs].Value.ToString();
                drug.dosageform = grd.Sheets[1].Cells[i, colDos].Value == null ? "" : grd.Sheets[1].Cells[i, colDos].Value.ToString();
                drug.strength = grd.Sheets[1].Cells[i, colStr].Value == null ? "" : grd.Sheets[1].Cells[i, colStr].Value.ToString();
                drug.content1 = grd.Sheets[1].Cells[i, colCont].Value == null ? "" : grd.Sheets[1].Cells[i, colCont].Value.ToString();

                drug.distributor = grd.Sheets[1].Cells[i, colDist].Value == null ? "" : grd.Sheets[1].Cells[i, colDist].Value.ToString();
                drug.manufactrer = grd.Sheets[1].Cells[i, colManu].Value == null ? "" : grd.Sheets[1].Cells[i, colManu].Value.ToString();
                drug.ised = grd.Sheets[1].Cells[i, colIsed].Value == null ? "" : grd.Sheets[1].Cells[i, colIsed].Value.ToString();
                drug.ndc24 = grd.Sheets[1].Cells[i, colNdc].Value == null ? "" : grd.Sheets[1].Cells[i, colNdc].Value.ToString();
                drug.unitsize = grd.Sheets[1].Cells[i, colUnitS].Value == null ? "" : grd.Sheets[1].Cells[i, colUnitS].Value.ToString();
                drug.unitprice = grd.Sheets[1].Cells[i, colUnitP].Value == null ? "" : grd.Sheets[1].Cells[i, colUnitP].Value.ToString();
                drug.updateflag = grd.Sheets[1].Cells[i, colUpF].Value == null ? "" : grd.Sheets[1].Cells[i, colUpF].Value.ToString();
                drug.datechange = grd.Sheets[1].Cells[i, colDatC].Value == null ? "" : grd.Sheets[1].Cells[i, colDatC].Value.ToString();
                drug.dateupdate = grd.Sheets[1].Cells[i, colDatU].Value == null ? "" : grd.Sheets[1].Cells[i, colDatU].Value.ToString();
                drug.dateeffect = grd.Sheets[1].Cells[i, colDatE].Value == null ? "" : grd.Sheets[1].Cells[i, colDatE].Value.ToString();

                drug.drugcat_id = grd.Sheets[1].Cells[i, colID].Value == null ? "" : grd.Sheets[1].Cells[i, colID].Value.ToString();
                drug.genericname = grd.Sheets[1].Cells[i, colGene].Value == null ? "" : grd.Sheets[1].Cells[i, colGene].Value.ToString();

                drugId = dCDB.insertDrugCatalogue(drug);
                re = "";
                re = dCDB.updateHospDrugCode(drugId, drug.hospdrugcode);
                if (re.Equals(""))
                {
                    grd.Sheets[1].Rows[i].BackColor = Color.Red;
                }
                pb1.Value = i;
            }

            conn.CloseConnectionMainHIS();
            conn.CloseConnectionSSData();

            pb1.Hide();
        }
        public void insertTSSData(String hcode, String branchId, String yearId, String monthId, ProgressBar pb1, Label label1, Label label2)
        {
            label1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            pb1.Show();
            DataTable dt = new DataTable();
            DataTable dtItem = new DataTable();
            DataTable dtBillDisp = new DataTable();
            int rowNo = 0;

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
                String visitDate = "", id="", dispdt="", prescdt="", btId="";
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
                ssV.paid = "0.0";
                ssV.month_id = monthId;
                ssV.year_id = yearId;

                ssV.invno = setInvNO(row["mnc_doc_cd"].ToString(), row["mnc_doc_no"].ToString(), row["mnc_doc_yr"].ToString());
                ssV.billno = "";
                ssV.amount = row["MNC_SUM_PRI"].ToString();
                //ssV.paid = "paid";
                ssV.payplan = "80";
                ssV.claimamt = ssV.amount;
                ssV.otherpayplan = "";
                ssV.otherpay = "";
                ssV.prescdt = "";
                ssV.dispdt = "";
                ssV.itemcnt = "";
                ssV.prescb = row["MNC_dot_cd"].ToString();
                ssV.svid = ssV.vn;
                prescdt = selectPrescdt(row["MNC_HN_NO"].ToString(), row["mnc_pre_no"].ToString(), visitDate);
                prescdt = datetoDB(prescdt);

                id = ssdVDB.insert(ssV);

                BillTran bt = new BillTran();
                bt.amount = ssV.amount;
                bt.authcode = "";
                bt.billno = "";
                bt.billtran_id = "";
                bt.claimamt = bt.amount;
                bt.dttran = visitDate;
                bt.hcode = "";
                bt.hmain = "";
                bt.hn = ssV.hn_no;
                bt.invno = ssV.invno;
                bt.memberno = "";
                bt.name = ssV.pre_no+" " + ssV.patient_fname + " " + ssV.patient_lname;
                bt.otherpayplan = "";
                bt.paid = "";
                bt.payplan = "";
                bt.pid = ssV.pid;
                bt.ptherpay = "";
                bt.ssdata_id = ssV.ssdata_id;
                bt.ssdata_visit_id = id;
                bt.station = "";
                bt.tflag = "";
                bt.vercode = "";

                btId = btDB.insert(bt);

                dtBillDisp = selectSSDataBillDisp(ssV.hn_no, ssV.vn_no, ssV.pre_no, ssV.visit_date);
                foreach (DataRow rowB in dtBillDisp.Rows)
                {
                    rowNo = 0;
                    dtItem.Clear();
                    dtItem = selectSSDataItem(ssV.hn_no, ssV.vn_no, ssV.pre_no, ssV.visit_date, rowB["MNC_CFR_NO"].ToString());

                    String ssdvBId = "";
                    TSsdataVisitBillDisp ssdvB = new TSsdataVisitBillDisp();
                    ssdvB.benefitplan = "";
                    ssdvB.chargeamt = rowB["pri"].ToString();
                    ssdvB.claimamt = rowB["amt"].ToString();
                    ssdvB.daycover = "";
                    ssdvB.dispdt = datetoDB(rowB["mnc_req_dat"].ToString());//วัน-เวลา สั่งยา
                    ssdvB.dispestat = "";
                    ssdvB.dispid = rowB["MNC_CFR_NO"].ToString();
                    ssdvB.hn = ssV.hn_no;
                    ssdvB.invno = ssV.invno;
                    ssdvB.itemcnt = rowB["cnt"].ToString();
                    ssdvB.otherpay = "";
                    ssdvB.paid = rowB["amt"].ToString();
                    ssdvB.pid = ssV.pid;
                    ssdvB.prescb = row["MNC_dot_cd"].ToString();
                    ssdvB.prescdt = datetoDB(rowB["mnc_cfg_dat"].ToString());//วัน-เวลา รับยา
                    ssdvB.providerid = "";
                    ssdvB.reimburser = "";
                    ssdvB.ssdata_billdisp_id = "";
                    ssdvB.ssdata_id = ssd.ssdata_id;
                    ssdvB.ssdata_visit_id = id;
                    ssdvB.svid = ssV.vn;
                    ssdvB.active = "1";
                    ssdvBId = ssdVBDB.insert(ssdvB);

                    foreach (DataRow rowI in dtItem.Rows)
                    {
                        TSsdataVisitBillDispItems ssvI = new TSsdataVisitBillDispItems();
                        double price = 0, qty = 0, amt = 0;
                        Double.TryParse(dtItem.Rows[rowNo]["mnc_ph_pri01"].ToString(), out price);
                        Double.TryParse(dtItem.Rows[rowNo]["qty"].ToString(), out qty);
                        amt = price * qty;
                        ssvI.ssdata_id = ssd.ssdata_id;
                        ssvI.ssdata_visit_id = id;
                        ssvI.ssdata_billdisp_id = ssdvBId;
                        ssvI.invno = ssV.invno;
                        ssvI.svdate = datetoDB(dtItem.Rows[rowNo]["mnc_cfg_dat"].ToString());
                        ssvI.row_no = dtItem.Rows[rowNo]["mnc_ord_no"].ToString();
                        ssvI.svrefid = "";
                        ssvI.up = price.ToString();
                        ssvI.active = "";
                        ssvI.billmuad = "";
                        ssvI.chargeamt = amt.ToString();
                        ssvI.claimamount = ssvI.chargeamt;
                        ssvI.claimcat = "OP1";
                        ssvI.claimup = "";
                        ssvI.desc1 = dtItem.Rows[rowNo]["mnc_ph_tn"].ToString();
                        ssvI.llcode = dtItem.Rows[rowNo]["mnc_ph_cd"].ToString();
                        ssvI.qty = qty.ToString();
                        ssvI.stdcode = dtItem.Rows[rowNo]["mnc_ph_cd"].ToString();
                        //ssvI.ssdata_billdisp_id = "";
                        ssdVBIDB.insert(ssvI);
                        rowNo++;
                    }
                }
            }
            conn.CloseConnectionSSData();
            pb1.Hide();
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        public String setInvNO(String mnc_doc_cd, String mnc_doc_no, String mnc_doc_yr)
        {
            String invNO = "", doc="000000";
            if (mnc_doc_cd.Equals("ON3"))
            {
                doc = "000000" + mnc_doc_no;
                doc = doc.Substring(doc.Length - 6);
                invNO = "PO"+ mnc_doc_yr + doc;
            }
            return invNO;
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
