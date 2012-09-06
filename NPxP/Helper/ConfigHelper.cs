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
        public bool SavedgvFlawColumns()
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();

            // Remove old relative_table for add new record
            if (navigator.Select("//dgv_flaw/*").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//relative_table/*[1]");
                XPathNavigator last = navigator.SelectSingleNode("//relative_table/*[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }

            //lock (dgv)
            //{
            //    for (int i = 0; i < dgv.Rows.Count - 1; i++)
            //    {
            //        string source = dgv.Rows[i].Cells[0].Value.ToString();
            //        string target = dgv.Rows[i].Cells[1].Value.ToString();
            //        navigator.SelectSingleNode("//relative_table").AppendChildElement(string.Empty, "column", string.Empty, null);
            //        // Move to last column element and add source , target value.
            //        navigator.SelectSingleNode("//relative_table/column[last()]").AppendChildElement(string.Empty, "source", string.Empty, source.ToUpper());
            //        navigator.SelectSingleNode("//relative_table/column[last()]").AppendChildElement(string.Empty, "target", string.Empty, target.ToUpper());

            //    }
            //}
            document.Save(path); 
            return true;
        }
    }
}
