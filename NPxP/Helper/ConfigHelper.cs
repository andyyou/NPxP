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
using System.Xml.Schema;

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
        // 取得 MapWindow Filter Type
        public string GetFilterType()
        {
            string system_config_path = PathHelper.SystemConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(system_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                int value = Convert.ToInt32(navigator.SelectSingleNode("/system/filter_display").Value);
                // 顯示項目 0:All, 1:Pass, 2:Fail
                string result;
                switch (value)
                { 
                    case 0:
                        result = "All";
                        break;
                    case 1:
                        result = "Pass";
                        break;
                    case 2:
                        result = "Fail";
                        break;
                    default:
                        result = "All";
                        break;
                }
                return result;
            }
        }
        // 取得 目前 Grade config file name
        public string GetDefaultGradeConfigName()
        {
            string system_config_path = PathHelper.SystemConfigFolder + "default.xml";
            using (FileStream stream = new FileStream(system_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string filename = navigator.SelectSingleNode("/system/grade_conf_name").Value;

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
                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//map_window/map_chart/grid_line_display").Value);

                return value;
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
        // 取得 Map Setup FlawLegend List
        public List<string> GetPrevFlawLegendList(string fileName)
        {
            List<string> legends = new List<string>();
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//map_window/flaw_legend");
                while (node.MoveNext())
                {
                    string name = node.Current.SelectSingleNode("name").Value;
                    legends.Add(name);
                }
                return legends;
            }
        }
        // 取得 Map Setup FlawLegend Dictionary (key=ClassID)
        public Dictionary<int,string> GetPrevFlawLegendDictionary(string fileName)
        {
            Dictionary<int, string> legends = new Dictionary<int, string>();
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//map_window/flaw_legend");
                while (node.MoveNext())
                {
                    int flawtype = Convert.ToInt32(node.Current.SelectSingleNode("flaw_type").Value);
                    string name = node.Current.SelectSingleNode("name").Value;
                    legends.Add(flawtype, name);
                }
                return legends;
            }
        }
        // 取得 Map Setup FlawLegend Dictionary (key=ClassName)
        public Dictionary<string, int> GetPrevFlawLegendDictionaryID(string fileName)
        {
            Dictionary<string, int> legends = new Dictionary<string, int>();
            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//map_window/flaw_legend");
                while (node.MoveNext())
                {
                    int flawtype = Convert.ToInt32(node.Current.SelectSingleNode("flaw_type").Value);
                    string name = node.Current.SelectSingleNode("name").Value;
                    legends.Add(name, flawtype);
                }
                return legends;
            }
        }
        // 取得 Map Setup FlawLegend(FlawType) DataTable
        public DataTable GetDataTablePrevFlawLegend(string fileName)
        {
            DataTable dtb = new DataTable("FlawLegends");
            dtb.Columns.Add("FlawType", typeof(int));
            dtb.Columns.Add("Name", typeof(string));
            dtb.Columns.Add("Shape", typeof(string));
            dtb.Columns.Add("Color", typeof(string));

            string map_config_path = PathHelper.MapConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(map_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//map_window/flaw_legend");
                while (node.MoveNext())
                {
                    int flawType = Convert.ToInt32(node.Current.SelectSingleNode("flaw_type").Value);
                    string name = node.Current.SelectSingleNode("name").Value;
                    string color = node.Current.SelectSingleNode("color").Value;
                    string shape = node.Current.SelectSingleNode("shape").Value;
                    DataRow dr = dtb.NewRow();
                    dr["FlawType"] = flawType;
                    dr["Name"] = name;
                    dr["Shape"] = shape;
                    dr["Color"] = color;

                    dtb.Rows.Add(dr);
                }
                return dtb;
            }

        }
        // 取得 Grade Mode 
        public string GetGradeNoRoiMode(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                string value = navigator.SelectSingleNode("//roi/mode").Value;

                return value;
            }
        }
        // 取得 Grade Column Size
        public int GetGradeColumns(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                int value = Convert.ToInt32(navigator.SelectSingleNode("//roi/columns/size").Value);

                return value;
            }
        }
        // 取得 Grade Rows Size
        public int GetGradeRows(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                int value = Convert.ToInt32(navigator.SelectSingleNode("//roi/rows/size").Value);

                return value;
            }
        }
        // 取得 GradeSetup.cs/dgvColumns DataTable 設定資料
        public DataTable GetDataTableOfdgvColumns(string fileName)
        {
            DataTable dtb = new DataTable("Columns");
            dtb.Columns.Add("Name", typeof(string));
            dtb.Columns.Add("Start", typeof(double));
            dtb.Columns.Add("End", typeof(double));

            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//config/roi/columns/column");
                while (node.MoveNext())
                {
                    string name = node.Current.SelectSingleNode("name").Value;
                    double start = Convert.ToDouble(node.Current.SelectSingleNode("start").Value);
                    double end = Convert.ToDouble(node.Current.SelectSingleNode("end").Value);
                    DataRow dr = dtb.NewRow();
                    dr["Name"] = name;
                    dr["Start"] = start;
                    dr["End"] = end;

                    dtb.Rows.Add(dr);
                }
                return dtb;
            }
        }
        // 取得 GradeSetup.cs/dgvRows DataTable 設定資料
        public DataTable GetDataTableOfdgvRows(string fileName)
        {
            DataTable dtb = new DataTable("Columns");
            dtb.Columns.Add("Name", typeof(string));
            dtb.Columns.Add("Start", typeof(double));
            dtb.Columns.Add("End", typeof(double));

            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//config/roi/rows/row");
                while (node.MoveNext())
                {
                    string name = node.Current.SelectSingleNode("name").Value;
                    double start = Convert.ToDouble(node.Current.SelectSingleNode("start").Value);
                    double end = Convert.ToDouble(node.Current.SelectSingleNode("end").Value);
                    DataRow dr = dtb.NewRow();
                    dr["Name"] = name;
                    dr["Start"] = start;
                    dr["End"] = end;

                    dtb.Rows.Add(dr);
                }
                return dtb;
            }
        }
        // 取得 Grade / point is enable
        public bool IsGradePointEnable(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//grade/points/enable").Value);

                return value;
            }
        }
        // 取得 GradeSetup.cs/ points subpiece name list
        public List<string> GetSubPointsNameList(string fileName)
        {
            List<string> subpieces = new List<string>();
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//grade/points/sub_piece/name");
                while (node.MoveNext())
                {
                    string name = node.Current.Value;

                    subpieces.Add(name);
                }
                return subpieces;
            }
        }
        // 取得 GradeSetup.cs/ grade(marks) subpiece name list
        public List<string> GetSubMarksNameList(string fileName)
        {
            List<string> subpieces = new List<string>();
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select("//grade/marks/sub_piece/name");
                while (node.MoveNext())
                {
                    string name = node.Current.Value;

                    subpieces.Add(name);
                }
                return subpieces;
            }
        }
        // 取得 所有 GradeSetup.cs/ dgvPoint DataTable (All, ROI-11, ROI-12...) All in one table.
        public DataTable GetDataTabledgvPoints(string fileName)
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("SubpieceName", typeof(string));
            dtb.Columns.Add("ClassName", typeof(string));
            dtb.Columns.Add("Score", typeof(int));

            Dictionary<int, string> flawTypeNames = GetPrevFlawLegendDictionary(fileName); //<flawtype, name> ex : <0, Not Classified>

            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string expr = String.Format("//config/grade/points/sub_piece");
                XPathNodeIterator node = navigator.Select(expr);
                while (node.MoveNext())
                {
                    string subpieceName = node.Current.SelectSingleNode("name").Value;
                    XPathNodeIterator subNode = node.Current.Select("flawtype_score");
                    while (subNode.MoveNext())
                    {
                        int flawtypeID = int.TryParse(subNode.Current.SelectSingleNode("@id").Value, out flawtypeID) ? flawtypeID : 0;
                        string flawtypeName = flawTypeNames[flawtypeID];
                        int score = Convert.ToInt32(subNode.Current.Value);
                        DataRow dr = dtb.NewRow();
                        dr["SubpieceName"] = subpieceName;
                        dr["ClassName"] = flawtypeName;
                        dr["Score"] = score;

                        dtb.Rows.Add(dr);
                    }
                }
                return dtb;
            }
        }
        // 取得 所有 GradeSetup.cs/ dgvGrade DataTable (All, ROI-11, ROI-12...) All in one table.
        public DataTable GetDataTabledgvGrade(string fileName)
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("SubpieceName", typeof(string));
            dtb.Columns.Add("ClassName", typeof(string));
            dtb.Columns.Add("Score", typeof(int));

            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                string expr = String.Format("//config/grade/marks/sub_piece");
                XPathNodeIterator node = navigator.Select(expr);
                while (node.MoveNext())
                {
                    string subpieceName = node.Current.SelectSingleNode("name").Value;
                    XPathNodeIterator subNode = node.Current.Select("mark");
                    while (subNode.MoveNext())
                    {
                        string flawtypeID = subNode.Current.SelectSingleNode("@id").Value;
                        int score = Convert.ToInt32(subNode.Current.Value);
                        DataRow dr = dtb.NewRow();
                        dr["SubpieceName"] = subpieceName;
                        dr["ClassName"] = flawtypeID;
                        dr["Score"] = score;

                        dtb.Rows.Add(dr);
                    }
                }
                return dtb;
            }
        }
        // 取得 Grade / marks(grade) is enable
        public bool IsGradeMarksEnable(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//grade/marks/enable").Value);

                return value;
            }
        }
        // 取得 Grade / pass_fail 
        public bool IsGradePassFailEnable(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                bool value = Convert.ToBoolean(navigator.SelectSingleNode("//grade/pass_fail/enable").Value);

                return value;
            }
        }
        // 取得 Grade / pass_fail / score
        public int GetPassFailScore(string fileName)
        {
            string grade_config_path = PathHelper.GradeConfigFolder + fileName + ".xml";
            using (FileStream stream = new FileStream(grade_config_path, FileMode.Open))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();

                int value = Convert.ToInt32(navigator.SelectSingleNode("//grade/pass_fail/score").Value);

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
                WriteHelper.ErrorLog("ConfigHelper.cs:SavedgvFlawOrderByColumn()");
                return false;
            }
            return true;
        }
        // 儲存 FilterType 
        public bool SaveFilterType(string type)
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();
            // 顯示項目 0:All, 1:Pass, 2:Fail
            string value = "0";
            switch(type.ToLower().Trim())
            {
                case "all":
                    value = "0";
                    break;
                case "pass":
                    value = "1";
                    break;
                case "fail":
                    value = "2";
                    break;
                default:
                    value = "0";
                    break;
            }
            navigator.SelectSingleNode("//system/filter_display").SetValue(value);
            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SaveFilterType()");
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
        // 儲存 MapSetup Config Name to System Config
        public bool SaveMapSetupConfigFile(string fileName)
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();
            navigator.SelectSingleNode("//system/map_conf_name").SetValue(fileName);
            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SaveMapSetupConfigFile()");
                return false;
            }
            return true;
        }
        //儲存 GradeSetup Config Name to System Config
        public bool SaveGradeSetupConfigFile(string fileName)
        {
            string path = PathHelper.SystemConfigFolder + "default.xml";
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XPathNavigator navigator = document.CreateNavigator();
            navigator.SelectSingleNode("//system/grade_conf_name").SetValue(fileName);
            try
            {
                document.Save(path);
            }
            catch
            {
                WriteHelper.ErrorLog("ConfigHelper.cs:SaveGradeSetupConfigFile()");
                return false;
            }
            return true;
        }
    }
}
