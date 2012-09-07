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

        // 取得 dgvFlaw 要使用的欄位且排序完成.
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
        // 取得 tlpFlawImages 幾列(預設)
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
        // 取得 tlpFlawImages 幾列(使用檔名)
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
        // 取得 tlpFlawImages 幾攔(預設)
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
        // 取得 tlpFlawImages 幾攔(使用檔名)
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
                WriteHelper.Log("ERROR::SavedgvFlawColumns");
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
                WriteHelper.Log("ERROR::SavetlpFlawImagesLayout");
                return false;
            }
            return true;
        }
    }
}
