using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WRPlugIn;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using NPxP.Model;

namespace NPxP.Helper
{
    public class DataHelper
    {
        private string _dbConnectString = JobHelper.DbConnectString;

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

        public void GetFlawDataFromDb(ref DataTable dtbFlaws, double cdOffset, double mdBegin, double mdEnd)
        {
            dtbFlaws.Clear();
            using (SqlConnection cn = new SqlConnection(_dbConnectString))
            {
                cn.Open();
                string queryString = @"Select lFlawId, dCD, dMD,
                                              dArea, dtTime, sName,
                                              lID, dLength, dWidth
                                       From dbo.Jobs T1,
                                            dbo.Flaw T2,
                                            dbo.FlawClass T3
                                       Where T1.klKey = T2.klJobKey AND
                                             T2.klJobKey = T3.fkJobKey AND
                                             T2.lFlawClassType = T3.lID AND
                                             T1.JobID = @JobID AND
                                             T2.dMD > @MdBegin AND
                                             T2.dMD < @MdEnd
                                       Order by lFlawId";

                SqlCommand cmd = new SqlCommand(queryString, cn);
                cmd.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                cmd.Parameters.AddWithValue("@MdBegin", mdBegin);
                cmd.Parameters.AddWithValue("@MdEnd", mdEnd);
                SqlDataReader sd = cmd.ExecuteReader();

                while (sd.Read())
                {
                    WriteHelper.Log(String.Format("Flaw ID: {0}, CD: {1}, MD: {2}, Area: {3}, FlawType: {4}, Length: {5}, Width: {6}",
                        sd["lFlawId"], sd["dCD"], sd["dMD"], sd["dArea"], sd["lID"], sd["dLength"], sd["dWidth"]));
                    DataRow dr = dtbFlaws.NewRow();
                    dr["FlawID"] = sd["lFlawId"];
                    // Notice: DataTable 資料保持單位 公尺
                    dr["CD"] = (double)sd["dCD"] - cdOffset; // 2012-11-01 : 使用 cdOffset 變數調整 cd 數值(於工單畫面設定)
                    dr["MD"] = (double)sd["dMD"] - mdBegin; // 2012-11-01 : 計算相對 md 值
                    dr["Area"] = sd["dArea"];
                    dr["DateTime"] = sd["dtTime"];
                    dr["FlawClass"] = sd["sName"];
                    dr["FlawType"] = sd["lID"];
                    dr["Length"] = sd["dLength"];
                    dr["Width"] = sd["dWidth"];
                    int opv;
                    if (JobHelper.SeverityInfo.Count > 0)
                    {
                        dr["Priority"] = JobHelper.SeverityInfo[0].Flaws.TryGetValue((int)sd["lID"], out opv) ? opv : 0;
                    }
                    else
                    {
                        dr["Priority"] = 0;
                    }

                    // Get flaw images
                    using (SqlConnection cn2 = new SqlConnection(_dbConnectString))
                    {
                        cn2.Open();
                        string queryString2 = @"Select iImage, lStation 
                                    From dbo.Jobs T1,
                                         dbo.Flaw T2,
                                         dbo.Image T3
                                    Where T1.klKey = T2.klJobKey AND
                                          T2.pklFlawKey = T3.klFlawKey AND
                                          T1.JobID = @JobID AND
                                          T2.lFlawId = @FlawID";
                        SqlCommand cmd2 = new SqlCommand(queryString2, cn2);
                        cmd2.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                        cmd2.Parameters.AddWithValue("@FlawID", dr["FlawID"]);
                        SqlDataReader sd2 = cmd2.ExecuteReader();

                        bool blnShowImg = false;
                        int intW = 0;
                        int intH = 0;
                        IList<IImageInfo> imgList = new List<IImageInfo>();
                        while (sd2.Read())
                        {
                            byte[] images = (Byte[])sd2["iImage"];
                            int station = (int)sd2["lStation"];

                            intW = images[0] + images[1] * 256;
                            intH = images[4] + images[5] * 256;

                            if (intW == 0 & intH == 0)
                            {
                                intW = 1;
                                intH = 1;
                                blnShowImg = false;
                            }
                            else
                            {
                                blnShowImg = true;
                            }
                            Bitmap bmpShowImg = new Bitmap(intW, intH);

                            if (blnShowImg)
                            {
                                bmpShowImg = ToGrayBitmap(images, intW, intH);
                            }

                            IImageInfo tmpImg = new ImageInfo(bmpShowImg, station);
                            imgList.Add(tmpImg);
                        }
                        dr["Images"] = imgList;
                    }

                    dtbFlaws.Rows.Add(dr);
                }
            }
        }

        public int GetFlawQuantity(double mdBegin, double mdEnd)
        {
            int flawQuantity = 0;
            using (SqlConnection cn = new SqlConnection(_dbConnectString))
            {
                cn.Open();
                string queryString = @"Select count(lFlawId) as FlawCount
                                       From dbo.Jobs T1,
                                            dbo.Flaw T2,
                                            dbo.FlawClass T3
                                       Where T1.klKey = T2.klJobKey AND
                                             T2.klJobKey = T3.fkJobKey AND
                                             T2.lFlawClassType = T3.lID AND
                                             T1.JobID = @JobID AND
                                             T2.dMD > @MdBegin AND
                                             T2.dMD < @MdEnd";
                SqlCommand cmd = new SqlCommand(queryString, cn);
                cmd.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                cmd.Parameters.AddWithValue("@MdBegin", mdBegin);
                cmd.Parameters.AddWithValue("@MdEnd", mdEnd);
                SqlDataReader sd = cmd.ExecuteReader();

                sd.Read();
                flawQuantity = (int)sd["FlawCount"];
            }
            return flawQuantity;
        }

        public void GetEachFlawQuantity(ref Dictionary<string, int> jobDoffNum, string mdRange)
        {
            using (SqlConnection cn = new SqlConnection(_dbConnectString))
            {
                cn.Open();
                string queryString = @"Select lID, sName as FlawName, count(lFlawId) as Quantity
                                       From dbo.Jobs T1,
                                            dbo.Flaw T2,
                                            dbo.FlawClass T3
                                       Where T1.klKey = T2.klJobKey AND
                                             T2.klJobKey = T3.fkJobKey AND
                                             T2.lFlawClassType = T3.lID AND
                                             T1.JobID = @JobID AND ";
                queryString += string.Format("{0} Group by lID, sName Order by lID", mdRange);

                SqlCommand cmd = new SqlCommand(queryString, cn);
                cmd.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                SqlDataReader sd = cmd.ExecuteReader();

                jobDoffNum.Clear();
                while (sd.Read())
                {
                    jobDoffNum.Add((string)sd["FlawName"], (int)sd["Quantity"]);
                }
            }
        }

        // Function of Image
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            // Declare bitmap variable and lock memory
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Get image parameter
            int stride = bmpData.Stride;  // Width of scan line
            int offset = stride - width;  // Display width and the scan line width of the gap
            IntPtr iptr = bmpData.Scan0;  // Get bmpData start position in memory
            int scanBytes = stride * height;  // Size of the memory area

            // Convert the original display size of the byte array into an array of bytes actually stored in the memory
            int posScan = 0, posReal = 0;  // Declare two pointer, point to source and destination arrays
            byte[] pixelValues = new byte[scanBytes];  // Declare array size
            for (int x = 0; x < height; x++)
            {
                // Emulate line scanning
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;  //Line scan finished
            }

            // Using Marshal.Copy function copy pixelValues to BitmapData
            Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  // Unlock memory

            // Change 8 bit bitmap index table to Grayscale
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;
            return bmp;
        }
    }
}
