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
    }
}
