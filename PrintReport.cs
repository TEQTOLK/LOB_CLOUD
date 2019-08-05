using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace LOB
{
    public class PrintReport
    {
        StringBuilder gSB = new StringBuilder();
        DataSet dSet = new DataSet();
        DataSet dSub = new DataSet();
        ReportDocument rptDoc = new ReportDocument();
        ReportDocument rptSub = new ReportDocument();

        public void RoadToPrintReport(string cQuery, string cReport)
        {
            dSet.Clear();
            MySqlCommand cmd = new MySqlCommand(cQuery, GlobalData.GCon);
            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter.Fill(dSet);
            rptDoc.Load(cReport);
            rptDoc.Database.Tables[0].SetDataSource(dSet.Tables[0]);
            rptDoc.SetParameterValue("txtCompanyName", GlobalData.GCompName);
            rptDoc.SetParameterValue("txtAddress", GlobalData.GAddress);
            rptDoc.SetParameterValue("txtTps", GlobalData.GTps);
            rptDoc.SetParameterValue("txtUsername", GlobalData.GUsername);
            //rptDoc.Refresh();
            rptDoc.SetDatabaseLogon("sa", "avmctechnologies@2018", @"SERVER\SQL2008", "myPOS", false);
            rptDoc.PrintToPrinter(1, true, 0, 0);
        }

        public void RoadToPrintReport(string cQuery, string cReport, CrystalReportViewer crystalReportViewer)
        {
            dSet.Clear();
            MySqlCommand cmd = new MySqlCommand(cQuery, GlobalData.GCon);
            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter.Fill(dSet);
            rptDoc.Load(cReport);
            rptDoc.Database.Tables[0].SetDataSource(dSet.Tables[0]);
            rptDoc.SetParameterValue("txtCompanyName", GlobalData.GCompName);
            rptDoc.SetParameterValue("txtAddress", GlobalData.GAddress);
            rptDoc.SetParameterValue("txtTps", GlobalData.GTps);
            rptDoc.SetParameterValue("txtUsername", GlobalData.GUsername);
            //rptDoc.Refresh();
            rptDoc.SetDatabaseLogon("sa", "avmctechnologies@2018", @"SERVER\SQL2008", "myPOS", false);
            crystalReportViewer.ReportSource = rptDoc;
        }

        public void RoadToPrintReport(string cQuery, string cReport, CrystalReportViewer crystalReportViewer, string cParam, double cCSH, double cCHQ, double cCCS, double cCRE)
        {
            dSet.Clear();
            MySqlCommand cmd = new MySqlCommand(cQuery, GlobalData.GCon);
            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter.Fill(dSet);
            rptDoc.Load(cReport);
            rptDoc.Database.Tables[0].SetDataSource(dSet.Tables[0]);
            rptDoc.SetParameterValue("txtCompanyName", GlobalData.GCompName);
            rptDoc.SetParameterValue("txtAddress", GlobalData.GAddress);
            rptDoc.SetParameterValue("txtTps", GlobalData.GTps);
            rptDoc.SetParameterValue("txtUsername", GlobalData.GUsername);
            if(cParam == "P")
            {
                rptDoc.SetParameterValue("txtCSHTotal", cCSH);
                rptDoc.SetParameterValue("txtCHQTotal", cCHQ);
                rptDoc.SetParameterValue("txtCCSTotal", cCCS);
                rptDoc.SetParameterValue("txtCRETotal", cCCS);
            }
            //rptDoc.Refresh();
            rptDoc.SetDatabaseLogon("sa", "avmctechnologies@2018", @"SERVER\SQL2008", "myPOS", false);
            crystalReportViewer.ReportSource = rptDoc;
        }

        public void RoadToPrintReportSub(string cQuery, string cReport, string cSubQuery)
        {
            dSet.Clear();
            MySqlCommand cmd = new MySqlCommand(cQuery, GlobalData.GCon);
            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter.Fill(dSet);
            rptDoc.Load(cReport);
            rptDoc.Database.Tables[0].SetDataSource(dSet.Tables[0]);
            LogonSubReport(rptDoc, cSubQuery);
            rptDoc.SetParameterValue("txtCompanyName", GlobalData.GCompName);
            rptDoc.SetParameterValue("txtAddress", GlobalData.GAddress);
            rptDoc.SetParameterValue("txtTps", GlobalData.GTps);
            rptDoc.SetParameterValue("txtUsername", GlobalData.GUsername);
            //rptDoc.Refresh();
            rptDoc.SetDatabaseLogon("sa", "avmctechnologies@2018", @"SERVER\SQL2008", "myPOS", false);
            rptDoc.PrintToPrinter(1, true, 0, 0);
        }

        private void SetDBForLogon(ReportDocument rptDoc, string cSubQuery)
        {
            dSub.Clear();
            MySqlCommand cmd = new MySqlCommand(cSubQuery, GlobalData.GCon);
            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter.Fill(dSub);
            rptDoc.Database.Tables[0].SetDataSource(dSub.Tables[0]);
        }

        public void LogonSubReport(ReportDocument rptDoc, string cSubQuery)
        {
            Sections sections = rptDoc.ReportDefinition.Sections;
            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;
                foreach (ReportObject reportObject in reportObjects)
                {
                    if(reportObject.Kind == CrystalDecisions.Shared.ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        rptDoc = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        SetDBForLogon(rptDoc, cSubQuery);
                        return;
                    }
                }
            }
        }
    }
}
