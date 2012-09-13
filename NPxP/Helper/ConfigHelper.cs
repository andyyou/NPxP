using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;
using NPxP.Model;
using System.Windows.Forms;

namespace NPxP.Helper
{
    public class ConfigHelper
    {
        // method using for get data from xml
        //--------------------------------------------------------------------------------------//

        // 取得 PxPTab.cs/dgvFlaw 要使用的欄位且排序完成.
        public List<Column> GetdgvFlawColumns()
        {
            List<Column> columns = new  List<Column>();

            string system_config_path = PathHelper.SystemConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(system_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//dgv_flaw/column");
                while (node.MoveNext())
                {
                    int index = Convert.ToInt32(node.Current.SelectSingleNode("index").Value);
                    string columnName = node.Current.SelectSingleNode("name").Value;
                    int width = Convert.ToInt32(node.Current.SelectSingleNode("width").Value);
                    Column column = new Column(index, columnName, width);
                    columns.Add(column);
                }
                columns.Sort((x, y) => x.Index.CompareTo(y.Index));
                return columns;
            }
        }
        // 取得 PxPTab.cs/tlpFlawImages 幾列(預設)
        public int GettlpFlawImagesRows()
        {
            string map_config_path = PathHelper.MapConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int row = Convert.ToInt32(navigator.SelectSingleNode("/config/pxptab/image_grid_rows").Value);

                return row;
            }
        }
        // 取得 PxPTab.cs/tlpFlawImages 幾列(使用檔名)
        public int GettlpFlawImagesRows(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int rows = Convert.ToInt32(navigator.SelectSingleNode("/config/pxptab/image_grid_rows").Value);

                return rows;
            }
        }
        // 取得 PxPTab.cs/tlpFlawImages 幾攔(預設)
        public int GettlpFlawImagesColumns()
        {
            string map_config_path = PathHelper.MapConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int columns = Convert.ToInt32(navigator.SelectSingleNode("/config/pxptab/image_grid_columns").Value);

                return columns;
            }
        }
        // 取得 PxPTab.cs/tlpFlawImages 幾攔(使用檔名)
        public int GettlpFlawImagesColumns(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int columns = Convert.ToInt32(navigator.SelectSingleNode("/config/pxptab/image_grid_columns").Value);

                return columns;
            }
        }
        // 取得 PxPTab.cs/dgvFlaw 排序的欄位名稱
        public string GetSortByColumnName()
        {
            string system_config_path = PathHelper.SystemConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(system_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string column = navigator.SelectSingleNode("//dgv_flaw/orderby").Value;

                return column;
            }
        }
        // 取得 目前 Map config file name
        public string GetDefaultMapConfigName()
        {
            string system_config_path = PathHelper.SystemConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(system_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string filename = navigator.SelectSingleNode("/system/map_conf_name").Value;

                return filename;
            }
        }
        // 取得 MapSetup.cs Map 格線是否開啟
        public bool GetIsDisplayMapGrid(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/grid_line_display").Value);
                if (value == 0)
                    return false;
                else
                    return true;
            }
        }
        // 取得 MapSetup.cs 格線顯示模式 0->FixCellSize, 1-> EachCellCount
        public bool GetIsFixCellSizeMode(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/grid_line_mode").Value);
                if (value == 0)
                    return true;
                else
                    return false;
            }
        }
        // 取得 FixCellSize 時 symbol
        public string GetFixCellSizeSmybol(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string value = navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/fix/symbol").Value;
                return value;
            }
        }
        // 取得 FixCellSize 時 CD
        public double GetFixCellSizeCD(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                double value = Convert.ToDouble(navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/fix/cd").Value);
                return value;
            }
        }
        // 取得 FixCellSize 時 MD
        public double GetFixCellSizeMD(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                double value = Convert.ToDouble(navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/fix/md").Value);
                return value;
            }
        }
        // 取得 CountSize 時 CD
        public int GetCountSizeCD(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/cd").Value);
                return value;
            }
        }
        // 取得 CountSize 時 MD
        public int GetCountSizeMD(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/md").Value);
                return value;
            }
        }
        // 取得 Bottom Axes 
        public string GetBottomAxes(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string value = navigator.SelectSingleNode("//map_window/map_chart/bottom_axes").Value;
                return value;
            }
        }
        // 取得 MD 是否反轉(垂直翻轉)
        public bool IsMdInver_Y(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//map_window/map_chart/md_inver").Value);

                return value;
            }
        }
        // 取得 CD 是否反轉(水平翻轉)
        public bool IsCdInver_X(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//map_window/map_chart/cd_inver").Value);

                return value;
            }
        }
        // 取得 Map Control 的 X 比例(X:Y)
        public int GetMapProportion_X(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/map_proportion[@name='x']").Value);

                return value;
            }
        }
        // 取得 Map Control 的 Y 比例(X:Y)
        public int GetMapProportion_Y(string fileName)
        {
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("//map_window/map_chart/map_proportion[@name='y']").Value);

                return value;
            }
        }
        // method using for save data to xml
        //--------------------------------------------------------------------------------------//
        
        // 儲存 dgvFlaw 欄位排序和調整的 Width
        public bool SavedgvFlawColumns(DataGridView dgv)
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();

            lock (dgv)
            {
                if (dgv.Columns.Count != 8)
                {
                    return false;
                }
                for (int i = 0; i < dgv.Columns.Count - 1; i++)
                {
                    string xpath_index = String.Format("//dgv_flaw/column[name='{0}']/index", dgv.Columns[i].Name);
                    navigator.SelectSingleNode(xpath_index).SetValue(dgv.Columns[i].DisplayIndex.ToString());

                    string xpath_width = String.Format("//dgv_flaw/column[name='{0}']/width", dgv.Columns[i].Name);
                    navigator.SelectSingleNode(xpath_width).SetValue(dgv.Columns[i].Width.ToString());
                }
            }
            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SavedgvFlawColumns()");
                return false;
            }
            return true;
        }
        // 儲存 dgvFlaw OrderBy column
        public bool SavedgvFlawOrderByColumn(string columnName)
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();
            navigator.SelectSingleNode("//dgv_flaw/orderby").SetValue(columnName);
            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SavedgvFlawColumns()");
                return false;
            }
            return true;
        }
        // 儲存 tlpFlawImages Rows * Columns
        public bool SavetlpFlawImagesLayout(string xmlFile, int columns, int rows)
        {
            string path = PathHelper.MapConfigFolder + xmlFile + ".xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();

            navigator.SelectSingleNode("//pxptab/image_grid_rows").SetValue(rows.ToString());
            navigator.SelectSingleNode("//pxptab/image_grid_columns").SetValue(columns.ToString());

            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SavetlpFlawImagesLayout()");
                return false;
            }
            return true;
        }
        

    }
}
