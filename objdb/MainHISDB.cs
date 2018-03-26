using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class MainHISDB
    {
        String sqlOPD = "";
        String sqlIPD = "";
        String sqlCronic = "";

        ConnectDB conn;
        public MainHISDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sqlOPD = "SELECT     TOP 100 PERCENT patt01.MNC_HN_YR, patt01.MNC_HN_NO, patt01.MNC_DATE, patm01.MNC_FNAME_T, patm01.MNC_LNAME_T, " +
                        "patm01.MNC_ID_NO, patm01.MNC_BDAY, patm01.MNC_SEX, dbo.PRAKUN_M01_TEMP.PrakanCode, SUM(fint01.MNC_SUM_PRI) AS MNC_SUM_PRI, " +
                        "patt01.MNC_REF_CD, fint01.MNC_PRAKUN_CODE, patm02.MNC_PFIX_DSC " +
                        "FROM         dbo.FINANCE_M02 INNER JOIN " +
                        "dbo.FINANCE_T01 fint01 ON dbo.FINANCE_M02.MNC_FN_TYP_CD = fint01.MNC_FN_TYP_CD RIGHT OUTER JOIN " +
                        "dbo.PATIENT_M02 patm02 RIGHT OUTER JOIN " +
                        "dbo.PATIENT_T01 patt01 LEFT OUTER JOIN " +
                        "dbo.PRAKUN_M01_TEMP RIGHT OUTER JOIN " +
                        "dbo.PATIENT_M01 patm01 ON dbo.PRAKUN_M01_TEMP.SocialID = patm01.MNC_ID_NO ON patt01.MNC_HN_YR = patm01.MNC_HN_YR AND " +
                        "patt01.MNC_HN_NO = patm01.MNC_HN_NO ON patm02.MNC_PFIX_CD = patm01.MNC_PFIX_CDT ON fint01.MNC_HN_YR = patt01.MNC_HN_YR AND " +
                        "fint01.MNC_HN_NO = patt01.MNC_HN_NO AND fint01.MNC_PRE_NO = patt01.MNC_PRE_NO AND fint01.MNC_DATE = patt01.MNC_DATE AND " +
                        "fint01.MNC_DOC_CD = 'ON3' " +
                        "WHERE     (patt01.MNC_ADM_FLG<> 'A') AND(patt01.MNC_DIAG_STS = 'Y') AND " +
                        "(fint01.MNC_DOC_STS = 'F') AND(dbo.FINANCE_M02.MNC_FN_STS = 'S') AND(fint01.MNC_PRAKUN_CODE = :HOSID OR " +
                        "fint01.MNC_PRAKUN_CODE IS NULL) AND(dbo.PRAKUN_M01_TEMP.PrakanCode = :HOSID1 OR " +
                        "dbo.PRAKUN_M01_TEMP.PrakanCode IS NULL)  AND((patm01.MNC_ID_NO<> '' or patm01.MNC_ID_NO is not null)) AND " +
                        "(patt01.MNC_AMP_FLG<> 'Y')  AND(patt01.MNC_DATE BETWEEN :Fromdate AND :Todate) and(patm01.mnc_hn_no like :HNNo) " +
                        "GROUP BY patt01.MNC_HN_YR, patt01.MNC_HN_NO, patt01.MNC_DATE, patm01.MNC_FNAME_T, patm01.MNC_LNAME_T, patm01.MNC_ID_NO,  " +
                        "patm01.MNC_BDAY, patm01.MNC_SEX, dbo.PRAKUN_M01_TEMP.PrakanCode, patt01.MNC_REF_CD, fint01.MNC_PRAKUN_CODE,  " +
                        "patm02.MNC_PFIX_DSC " +
                        "ORDER BY patt01.MNC_DATE, patt01.MNC_HN_NO";
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
        public DataTable selectSSData(String yearId, String monthId)
        {
            DataTable dt = new DataTable();

            dt = conn.selectData(conn.connMainHIS, sqlOPD);

            return dt;
        }
    }
}
