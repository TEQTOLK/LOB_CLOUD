using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public class GlobalData
    {
        public static string GUsername;
        public static int GUserID;
        public static string GCompName;
        public static int GCompID;
        public static string GMacAddress;
        public static string GServerName;
        public static MySqlConnection GCon;
        public static string GUserGroup;
        public static int GStockRoomID;
        public static string GAddress;
        public static string GTps;
        public static string GComAdd1;
        public static string GComAdd2;
        public static string GComTp1;
        public static string GComCity;

        public static int GCashACC;
        public static int GSaleACC;
        public static int GPurchaseACC;
        public static int GExpenseACC;
        public static int GCreditACC;

        StringBuilder gSB = new StringBuilder();
        MySqlDataReader sqlReader;
        DataSet dSet = new DataSet();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        
        //Connect SQL
        public MySqlConnection ConnectSQL()
        {      
            try
            {
                //MySqlConnection myCon = new MySqlConnection(@"Data Source = SERVER\SQL2008; Initial Catalog = myPOS; User ID = sa; Password = avmctechnologies@2018");
                MySqlConnection myCon = new MySqlConnection(@"server=localhost;port=3306;database=myPOS;uid=root;password='';persistsecurityinfo=True");
                myCon.Open();
                return myCon;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                
            }
        }

        public DataSet getDataSet(string cQuery, string cTableName)
        {
            try
            {             
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = cQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dSet = new DataSet();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dSet, cTableName);
                }

                return dSet;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void SayMessage(string cMessage, int cId, string cTag)
        {
            frmSuccessMessage frmMessage = new frmSuccessMessage();
            frmMessage.SayMessage(cMessage, cId, cTag);
            frmMessage.ShowDialog();
        }

        public void FillComboBoxALL(ComboBox comboBox, string cTableName, string cWhereClause)
        {
            try
            {
                string strQuery = " SELECT CustID, NameOF FROM " + cTableName + " " + cWhereClause;
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = strQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

                comboBox.Items.Clear();
                DataRow row = dataTable.NewRow();
                row["NameOF"] = "ALL";
                dataTable.Rows.InsertAt(row, 0);

                comboBox.DataSource = dataTable;
                comboBox.ValueMember = "CustID";
                comboBox.DisplayMember = "NameOF";

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dataTable = null;
            }
        }

        public string GetValue(string cQuery, string cField)
        {
            try
            {
                var result = "";
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = cQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

                foreach (DataRow dROW in dataTable.Rows)
                {
                    result = dROW[cField].ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                dataTable = null;
            }
        }

        public void FillComboBox(ComboBox comboBox, string cTableName, string cWhereClause)
        {
            comboBox.DataSource = getDataSet("SELECT CustID, NameOF FROM " + cTableName + " " + cWhereClause, cTableName).Tables[0];
            comboBox.ValueMember = "CustID";
            comboBox.DisplayMember = "NameOF";
        }

        public Boolean AlreadyExist(string cQuery)
        {
            Boolean isExist = false;
            try
            {
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = cQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }
                
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
                return isExist;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                dataTable = null;
            }
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nInterface = NetworkInterface.GetAllNetworkInterfaces();

            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nInterface)
            {
                if (sMacAddress == String.Empty)
                {
                    IPInterfaceProperties Properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public DataTable getDataTable(string cQuery)
        {
            try
            {
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = cQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public long getUniqueNumber(string cTranCode, int cCompID)
        {
            long gLastNo = 0;

            gSB.Clear();
            gSB.Append("SELECT LastID FROM tblLastID WHERE TranCode = '" + cTranCode + "' AND CompID = " + cCompID + " ");
            if(AlreadyExist(gSB.ToString()))
            {
                MySqlCommand command = new MySqlCommand("UPDATE tblLastID SET LastID = LastID + 1 WHERE TranCode = '" + cTranCode + "' AND CompID = " + cCompID + "", GCon);
                command.ExecuteNonQuery();
                gLastNo = Convert.ToInt64(GetValue(gSB.ToString(), "LastID"));

                return gLastNo;
            }
            else
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO tblLastID(LastID, TranCode, CompID) VALUES (1, '" + cTranCode + "', " + cCompID + ") ", GCon);
                command.ExecuteNonQuery();
                gLastNo = 1;
                return gLastNo;
            }
        }

      
        public DateTime getFirstDate(ComboBox cComboFDate)
        {
            string tmpVal = "";
            switch (cComboFDate.SelectedIndex)
            {
                case 0:
                    tmpVal = "01-Jan-" + DateTime.Now.Year;
                    break;
                case 1:
                    tmpVal = DateTime.Now.ToShortDateString();
                    break;
                case 2:
                    tmpVal = "01-" + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month).ToString() + "-" + DateTime.Now.Year;
                    break;
                case 3:
                    tmpVal = "01-" + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.AddMonths(-1).Month).ToString() + "-" + DateTime.Now.Year;
                    break;
                case 4:
                    tmpVal = "01-Jan-" + DateTime.Now.Year;
                    break;
                default:
                    break;
            }

            return Convert.ToDateTime(tmpVal);
        }

        public DateTime getLastDate(ComboBox cComboFDate, DateTime cFDate)
        {
            string tmpVal = "";
            switch (cComboFDate.SelectedIndex)
            {
                case 0:
                    tmpVal = "31-Dec-" + DateTime.Now.Year;
                    break;
                case 1:
                    tmpVal = DateTime.Now.ToShortDateString();
                    break;
                case 2:
                    tmpVal = DateTime.Now.ToShortDateString();
                    break;
                case 3:
                    tmpVal = cFDate.AddMonths(1).AddDays(-1).ToShortDateString();
                    break;
                case 4:
                    tmpVal = DateTime.Now.ToShortDateString();
                    break;
                default:
                    break;
            }

            return Convert.ToDateTime(tmpVal);
        }
    }
}