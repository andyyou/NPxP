using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
    }
}
