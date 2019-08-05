using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace LOB
{
    public class MasterFiles
    {
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        public string Code { get; set; }
        public string NameOF { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }
        public string BrandName { get; set; }
        public double Cost { get; set; }
        public double SellingPrice { get; set; }
        public double WholeSalePrice { get; set; }
        public double Discount { get; set; }
        public double ProfitMargin { get; set; }
        public string IsActive { get; set; }
        public int CustID { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string Tp1 { get; set; }
        public string Tp2 { get; set; }
        public string Tp3 { get; set; }
        public string OfficeNo { get; set; }
        public string EmailID { get; set; }
        public string Note { get; set; }
        public string DescriptionOf { get; set; }
        public int BinID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int CompID { get; set; }
        public string CompName { get; set; }
        public string PerformedBy { get; set; }
        public int UserGroupID { get; set; }
        public string BackupCode { get; set; }
        public int ScaleID { get; set; }
        public int AreaID { get; set; }

        public long SaveProduct()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblItem ( " +
                " Code, NameOF, SupplierID, CategoryID, ModelNo, SerialNo, BrandName, " +
                " Cost, SellingPrice, WholeSalePrice, Discount, ProfitMargin, IsActive, BinID, ScaleID ) " +
                " VALUES ( " +
                " @Code, @NameOF, @SupplierID, @CategoryID, @ModelNo, @SerialNo, @BrandName, " +
                " @Cost, @SellingPrice, @WholeSalePrice, @Discount, @ProfitMargin, @IsActive, @BinID, @ScaleID); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.Parameters.AddWithValue("@ModelNo", ModelNo);
                cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
                cmd.Parameters.AddWithValue("@BrandName", BrandName);
                cmd.Parameters.AddWithValue("@Cost", Cost);
                cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                cmd.Parameters.AddWithValue("@WholeSalePrice", WholeSalePrice);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@ProfitMargin", ProfitMargin);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@BinID", BinID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@ScaleID", ScaleID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateProduct()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblItem SET " +
                " NameOF = @NameOF, SupplierID = @SupplierID, CategoryID = @CategoryID, ModelNo = @ModelNo, SerialNo = @SerialNo, BrandName = @BrandName, " +
                " Cost = @Cost, SellingPrice = @SellingPrice, WholeSalePrice = @WholeSalePrice, Discount = @Discount, ProfitMargin = @ProfitMargin, IsActive =  @IsActive, BinID = @BinID, ScaleID = @ScaleID " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.Parameters.AddWithValue("@ModelNo", ModelNo);
                cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
                cmd.Parameters.AddWithValue("@BrandName", BrandName);
                cmd.Parameters.AddWithValue("@Cost", Cost);
                cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                cmd.Parameters.AddWithValue("@WholeSalePrice", WholeSalePrice);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@ProfitMargin", ProfitMargin);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@BinID", BinID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@ScaleID", ScaleID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }

        }

        public void FillProduct(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblItem WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                SupplierID = Convert.ToInt32(dROW["SupplierID"]);
                ModelNo = dROW["ModelNo"].ToString();
                SerialNo = dROW["SerialNo"].ToString();
                BrandName = dROW["BrandName"].ToString();
                Cost = Convert.ToDouble(dROW["Cost"]);
                SellingPrice = Convert.ToDouble(dROW["SellingPrice"]);
                WholeSalePrice = Convert.ToDouble(dROW["WholeSalePrice"]);
                Discount = Convert.ToDouble(dROW["Discount"]);
                ProfitMargin = Convert.ToDouble(dROW["ProfitMargin"]);
                IsActive = dROW["IsActive"].ToString();
                BinID = Convert.ToInt32(dROW["BinID"]);
                ScaleID = Convert.ToInt32(dROW["ScaleID"]);
                CategoryID = Convert.ToInt32(dROW["CategoryID"]);
            }
            dataTable = null;
        }

        public long SaveSupplier()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblSupplier ( " +
                " Code, NameOF, Add1, Add2, City, Tp1, Tp2, Tp3, " +
                " OfficeNo, EmailID, Note, IsActive, AreaID ) " +
                " VALUES ( " +
                " @Code, @NameOF, @Add1, @Add2, @City, @Tp1, @Tp2, @Tp3, " +
                " @OfficeNo, @EmailID, @Note, @IsActive, @AreaID); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@AreaID", AreaID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateSupplier()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblSupplier SET " +
                " NameOF = @NameOF, Add1 = @Add1, Add2 = @Add2, City = @City, Tp1 = @Tp1, Tp2 = @Tp2, Tp3 = @Tp3, " +
                " OfficeNo = @OfficeNo, EmailID = @EmailID, Note = @Note, IsActive = @IsActive, AreaID = @AreaID " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@AreaID", AreaID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void FillSupplier(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblSupplier WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                Add1 = dROW["Add1"].ToString();
                Add2 = dROW["Add2"].ToString();
                City = dROW["City"].ToString();
                Tp1 = dROW["Tp1"].ToString();
                Tp2 = dROW["Tp2"].ToString();
                Tp3 = dROW["Tp3"].ToString();
                OfficeNo = dROW["OfficeNo"].ToString();
                EmailID = dROW["EmailID"].ToString();
                Note = dROW["Note"].ToString();
                IsActive = dROW["IsActive"].ToString();
                AreaID = Convert.ToInt32(dROW["AreaID"]);
            }
            dataTable = null;
        }

        public long SaveCustomer()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblCustomer ( " +
                " Code, NameOF, Add1, Add2, City, Tp1, Tp2, Tp3, " +
                " OfficeNo, EmailID, Note, IsActive, AreaID ) " +
                " VALUES ( " +
                " @Code, @NameOF, @Add1, @Add2, @City, @Tp1, @Tp2, @Tp3, " +
                " @OfficeNo, @EmailID, @Note, @IsActive, @AreaID); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@AreaID", AreaID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateCustomer()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblCustomer SET " +
                " NameOF = @NameOF, Add1 = @Add1, Add2 = @Add2, City = @City, Tp1 = @Tp1, Tp2 = @Tp2, Tp3 = @Tp3, " +
                " OfficeNo = @OfficeNo, EmailID = @EmailID, Note = @Note, IsActive = @IsActive, AreaID = @AreaID " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@AreaID", AreaID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void FillCustomer(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblCustomer WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                Add1 = dROW["Add1"].ToString();
                Add2 = dROW["Add2"].ToString();
                City = dROW["City"].ToString();
                Tp1 = dROW["Tp1"].ToString();
                Tp2 = dROW["Tp2"].ToString();
                Tp3 = dROW["Tp3"].ToString();
                OfficeNo = dROW["OfficeNo"].ToString();
                EmailID = dROW["EmailID"].ToString();
                Note = dROW["Note"].ToString();
                IsActive = dROW["IsActive"].ToString();
                AreaID = Convert.ToInt32(dROW["AreaID"]);
            }
            dataTable = null;
        }

        public long SaveCompany()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblCompany ( " +
                " Code, NameOF, Add1, Add2, City, Tp1, Tp2, Tp3, " +
                " OfficeNo, EmailID, Note, IsActive ) " +
                " VALUES ( " +
                " @Code, @NameOF, @Add1, @Add2, @City, @Tp1, @Tp2, @Tp3, " +
                " @OfficeNo, @EmailID, @Note, @IsActive); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateCompany()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblCompany SET " +
                " NameOF = @NameOF, Add1 = @Add1, Add2 = @Add2, City = @City, Tp1 = @Tp1, Tp2 = @Tp2, Tp3 = @Tp3, " +
                " OfficeNo = @OfficeNo, EmailID = @EmailID, Note = @Note, IsActive = @IsActive " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void FillCompany(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblCompany WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                Add1 = dROW["Add1"].ToString();
                Add2 = dROW["Add2"].ToString();
                City = dROW["City"].ToString();
                Tp1 = dROW["Tp1"].ToString();
                Tp2 = dROW["Tp2"].ToString();
                Tp3 = dROW["Tp3"].ToString();
                OfficeNo = dROW["OfficeNo"].ToString();
                EmailID = dROW["EmailID"].ToString();
                Note = dROW["Note"].ToString();
                IsActive = dROW["IsActive"].ToString();
            }
            dataTable = null;
        }

        public long SaveCommon(string cTableName)
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO "+ cTableName + " ( " +
                " Code, NameOF, DescriptionOf ) " +
                " VALUES ( " +
                " @Code, @NameOF, @DescriptionOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@DescriptionOf", DescriptionOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateCommon(string cTableName)
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE " + cTableName + " SET " +
                " NameOF = @NameOF, DescriptionOf = @DescriptionOf " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@DescriptionOf", DescriptionOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void FillCommon(string cCode, string cTableName)
        {
            string tmpHolder = "SELECT * FROM " + cTableName + " WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                DescriptionOf = dROW["DescriptionOf"].ToString();
            }
            dataTable = null;
        }
       
        public long SaveSysUser()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblSysUsers ( " +
                " Code, UserName, Password, Email, Mobile, CompID, ServerName, " +
                " IsActive, PerformedBy, UserGroupID, PinCode, NameOf ) " +
                " VALUES ( " +
                " @Code, @UserName, @Password, @Email, @Mobile, @CompID, @ServerName, " +
                " @IsActive, @PerformedBy, @UserGroupID, @PinCode, @NameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", EmailID);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@CompID", CompID);
                cmd.Parameters.AddWithValue("@ServerName", CompName);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@PerformedBy", PerformedBy);
                cmd.Parameters.AddWithValue("@UserGroupID", UserGroupID);
                cmd.Parameters.AddWithValue("@PinCode", BackupCode);
                cmd.Parameters.AddWithValue("@NameOf", UserName);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateSysUser(string cCode)
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblSysUsers SET  " +
                " UserName = @UserName, Password = @Password, Email = @Email, Mobile = @Mobile, CompID = @CompID, ServerName = @ServerName, " +
                " IsActive = @IsActive, PerformedBy = @PerformedBy, UserGroupID = @UserGroupID, PinCode = @PinCode " +
                " WHERE Code = '" + cCode + "' ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", EmailID);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@CompID", CompID);
                cmd.Parameters.AddWithValue("@ServerName", CompName);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@PerformedBy", PerformedBy);
                cmd.Parameters.AddWithValue("@UserGroupID", UserGroupID);
                cmd.Parameters.AddWithValue("@PinCode", BackupCode);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }

        }

        public void FillSysUsers(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblSysUsers WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                Code = dROW["Code"].ToString();
                UserName = dROW["UserName"].ToString();
                Password = dROW["Password"].ToString();
                EmailID = dROW["Email"].ToString();
                Mobile = dROW["Mobile"].ToString();
                UserGroupID = Convert.ToInt32(dROW["UserGroupID"]);
                CompID = Convert.ToInt32(dROW["CompID"]);
                BackupCode = dROW["PinCode"].ToString();
            }
            dataTable = null;
        }

        public long SaveBank()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblBankAccount ( " +
                " Code, NameOF, Add1, Add2, City, Tp1, Tp2, Tp3, " +
                " OfficeNo, EmailID, Note, IsActive ) " +
                " VALUES ( " +
                " @Code, @NameOF, @Add1, @Add2, @City, @Tp1, @Tp2, @Tp3, " +
                " @OfficeNo, @EmailID, @Note, @IsActive); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public long UpdateBank()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("UPDATE tblBankAccount SET " +
                " NameOF = @NameOF, Add1 = @Add1, Add2 = @Add2, City = @City, Tp1 = @Tp1, Tp2 = @Tp2, Tp3 = @Tp3, " +
                " OfficeNo = @OfficeNo, EmailID = @EmailID, Note = @Note, IsActive = @IsActive " +
                " WHERE Code = @Code ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@NameOF", NameOF);
                cmd.Parameters.AddWithValue("@Add1", Add1);
                cmd.Parameters.AddWithValue("@Add2", Add2);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Tp1", Tp1);
                cmd.Parameters.AddWithValue("@Tp2", Tp2);
                cmd.Parameters.AddWithValue("@Tp3", Tp3);
                cmd.Parameters.AddWithValue("@OfficeNo", OfficeNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void FillBank(string cCode)
        {
            string tmpHolder = "SELECT * FROM tblBankAccount WHERE Code= '" + cCode + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                CustID = Convert.ToInt32(dROW["CustID"]);
                NameOF = dROW["NameOF"].ToString();
                Add1 = dROW["Add1"].ToString();
                Add2 = dROW["Add2"].ToString();
                City = dROW["City"].ToString();
                Tp1 = dROW["Tp1"].ToString();
                Tp2 = dROW["Tp2"].ToString();
                Tp3 = dROW["Tp3"].ToString();
                OfficeNo = dROW["OfficeNo"].ToString();
                EmailID = dROW["EmailID"].ToString();
                Note = dROW["Note"].ToString();
                IsActive = dROW["IsActive"].ToString();
            }
            dataTable = null;
        }
    }
}
