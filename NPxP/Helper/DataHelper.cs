using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace NPxP.Helper
{
    public class DataHelper
    {
        /// 執行 DataTable 中的查詢返回新的 DataTable
        /// </summary>
        /// <param name="dt">來源資料 DataTable</param>
        /// <param name="condition">查詢條件</param>
        /// <returns></returns>
        public DataTable QueryDataTable(DataTable dt, string condition, string sortstr)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition, sortstr);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;
        }

        /// <summary>
        /// 判斷 DataTable 欄位是否有空值
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool HasNull(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                if (table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)))
                    return true;
            }

            return false;
        }

        public void GetFlawDataFromDb(ref DataTable dtbFlaws, string connectString)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                string queryString = @"Select lFlawId, dCD, dMD,
                                                          dArea, dtTime, sName,
                                                          lID, dLength, dWidth,
                                                          iImage, lStation
                                                   From dbo.Jobs T1,
                                                        dbo.Flaw T2,
                                                        dbo.FlawClass T3,
                                                        dbo.Image T4
                                                   Where T1.klKey = T2.klJobKey AND
                                                         T2.klJobKey = T3.fkJobKey AND
                                                         T2.lFlawClassType = T3.lID AND
                                                         T2.pklFlawKey = T4.klFlawKey AND
                                                         T1.JobID = @JobID
                                                   Order by lFlawId";

                SqlCommand cmd = new SqlCommand(queryString, cn);
                cmd.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                SqlDataReader sd = cmd.ExecuteReader();

                while (sd.Read())
                {
                    WriteHelper.Log(String.Format("Flaw ID: {0}, CD: {1}, MD: {2}, Area: {3}, FlawType: {4}, Length: {5}, Width: {6}",
                        sd["lFlawId"], sd["dCD"], sd["dMD"], sd["dArea"], sd["lID"], sd["dLength"], sd["dWidth"]));
                    DataRow dr = dtbFlaws.NewRow();
                    dr["FlawID"] = sd["lFlawId"];
                    // 2012-10-19 : 使用 cdOffset 變數調整 cd 數值
                    dr["CD"] = (double)sd["dCD"]; // Notice: DataTable 和 PxPInfo.Width, Height 資料保持單位 公尺
                    dr["MD"] = sd["dMD"];
                    dr["Area"] = sd["dArea"];
                    dr["DateTime"] = sd["dtTime"];
                    dr["FlawClass"] = sd["sName"];
                    dr["FlawType"] = sd["lID"];
                    dr["Length"] = sd["dLength"];
                    dr["Width"] = sd["dWidth"];

                    dtbFlaws.Rows.Add(dr);
                }
            }
        }
    }
}
