using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using QJcms.Common;
using System.Data;
using JRO;

namespace QJcms.Web.admin.settings
{
    public partial class data_back : Web.UI.ManagePage
    {
        Model.siteconfig config = new BLL.siteconfig().loadConfig();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("file_name", typeof(string))); //文件名称
            dt.Columns.Add(new DataColumn("file_size", typeof(string))); //文件大小
            dt.Columns.Add(new DataColumn("upload_date", typeof(DateTime))); //备份时间

            string dirPath = Utils.GetMapPath(config.webpath + "back/");
            if (Directory.Exists(dirPath))
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                FileInfo[] arrFiles = dir.GetFiles();
                foreach (FileInfo f in arrFiles)
                {
                    dr = dt.NewRow();
                    dr[0] = f.Name;
                    dr[1] = Utils.CountFileSize(f.Length);
                    dr[2] = f.LastWriteTime;
                    dt.Rows.Add(dr);
                }
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "upload_date desc";
            rptList.DataSource = dv.ToTable();
            rptList.DataBind();
            if (QJKey.DatabaseType == "0") { lbtnCompr.Visible = true; }
            else { lbtnCompr.Visible = false; }
        }
        #endregion

        //备份数据库
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.Back.ToString()); //检查权限
            string str_filename = Common.Utils.GetRamCode();
            string backpath = Utils.GetMapPath(config.webpath + "back/");
            string filename = backpath + str_filename + ".bak";
            if (!Directory.Exists(backpath))
                Directory.CreateDirectory(backpath);

            switch (QJKey.DatabaseType)
            {
                case "0":
                    try
                    {
                        File.Copy(QJKey.dbPathAcc, filename, true);
                        AddAdminLog(QJEnums.ActionEnum.Back.ToString(), "备份数据库：" + filename); //记录日志
                        JscriptMsg("数据备份成功！", "data_back.aspx", "Success");
                    }
                    catch
                    {
                        JscriptMsg("备份失败！文件无法读取或写入！", "data_back.aspx", "Error");
                    }
                    break;
                case "1":
                    try
                    {
                        string dbCstring = DBUtility.DbHelperSQL.connectionString;
                        string dbName = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbName");
                        string Sql = "backup DATABASE [" + dbName + "] to disk='" + filename + "' with format";
                        DBUtility.DbHelperSQL.ExecuteSql(Sql);

                        AddAdminLog(QJEnums.ActionEnum.Back.ToString(), "备份数据库：" + filename); //记录日志
                        JscriptMsg("数据备份成功！", "data_back.aspx", "Success");
                    }
                    catch (Exception ex)
                    {
                        JscriptMsg("备份失败！数据库与网站须同一服务器！", "data_back.aspx", "Error");
                    }
                    break;
                default: break;
            }
        }
        //数据库收缩（Access下生效）
        protected void lbtnCompr_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.Back.ToString()); //检查权限
            string DbPath1, DbPath2, DbConn1, DbConn2;

            DbPath1 = QJKey.dbPathAcc;//原数据库路径
            DbPath2 = Utils.GetMapPath("~/App_Data/DataBaseCompress.config");//压缩后的数据库路径
            DbConn1 = QJKey.ConnectionString;// "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath1;
            DbConn2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath2 + ";Jet OLEDB:Database PassWord=" + DESEncrypt.Decrypt(QJKey.dbPwdAcc);

            try
            {
                JetEngine DatabaseEngin = new JetEngine();
                DatabaseEngin.CompactDatabase(DbConn1, DbConn2);//压缩

                File.Copy(DbPath2, DbPath1, true);//将压缩后的数据库覆盖原数据库
                File.Delete(DbPath2);//删除压缩后的数据库

                AddAdminLog(QJEnums.ActionEnum.Back.ToString(), "数据库压缩"); //记录日志
                JscriptMsg("数据库压缩成功！", "data_back.aspx", "Success");
            }
            catch
            {
                JscriptMsg("数据库压缩失败！", "data_back.aspx", "Error");
            }

        }

        //下载与删除
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string filename = ((HiddenField)e.Item.FindControl("hidFileName")).Value;
            string backpath = Utils.GetMapPath(config.webpath + "back/") + filename;
            switch (e.CommandName)
            {
                case "lbtnRestore":
                    ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.Restore.ToString()); //检查权限
                    AddAdminLog(QJEnums.ActionEnum.Restore.ToString(), "下载备份文件：" + filename); //记录日志
                    //string dbCstring = DBUtility.DbHelperSQL.connectionString;
                    //string[] a_dbNamestring = dbCstring.Split(';');
                    //string[] a_dbNameS = a_dbNamestring[3].ToString().Split('=');
                    //string databasename = a_dbNameS[1].ToString();
                    ////杀死所有连接数据库的进程
                    //string strSQL = "select spid from master..sysprocesses where dbid=db_id( '" + databasename + "')";
                    //DataTable spidTable = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
                    //for (int iRow = 0; iRow <= spidTable.Rows.Count - 1; iRow++)
                    //{
                    //    string commandtext = "kill " + spidTable.Rows[iRow][0].ToString();   //强行关闭用户进程 
                    //    DBUtility.DbHelperSQL.ExecuteSql(commandtext);
                    //}
                    ////--------------------------------------------------------------------
                    //string sql = "backup log " + databasename + " to disk='" + backpath + "' restore database " + databasename + " from disk='" + backpath + "'";
                    //DBUtility.DbHelperSQL.ExecuteSql(sql);

                    FileStream fileStream = new FileStream(backpath, FileMode.Open);
                    long fileSize = fileStream.Length;
                    byte[] fileBuffer = new byte[fileSize];
                    fileStream.Read(fileBuffer, 0, (int)fileSize);
                    fileStream.Close();
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                    Response.AddHeader("Content-Length", fileSize.ToString());
                    Response.BinaryWrite(fileBuffer);
                    Response.End();
                    Response.Close();
                    break;
                case "lbtnDelete":
                    ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.Delete.ToString()); //检查权限
                    if (File.Exists(backpath))
                    {
                        File.Delete(backpath);
                        AddAdminLog(QJEnums.ActionEnum.Delete.ToString(), "删除备份文件：" + filename); //记录日志
                    }
                    JscriptMsg("删除数据成功！", "data_back.aspx", "Success");
                    break;
            }
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_baseback", QJEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string filename = ((HiddenField)rptList.Items[i].FindControl("hidFileName")).Value;
                string backpath = Utils.GetMapPath(config.webpath + "back/") + filename;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (File.Exists(backpath))
                    {
                        File.Delete(backpath);
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(QJEnums.ActionEnum.Delete.ToString(), "删除数据库备份文件" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "data_back.aspx", "Success");

        }
    }
}