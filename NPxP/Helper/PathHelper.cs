using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace NPxP.Helper
{
    public static class PathHelper
    {
        static string folder_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\..\\Parameter Files\\NPxP";
        public static string SystemConfigFolder
        {
            get
            {

                string system_path = folder_path + "\\system\\";
                return system_path;
            }
        }

        public static string MapConfigFolder
        {
            get
            {
                string map_config_path = folder_path + "\\map\\";
                return map_config_path;
            }
        }

        public static string GradeConfigFolder
        {
            get
            {
                string grade_config_path = folder_path + "\\grade\\";
                return grade_config_path;
            }
        }

        public static string MapConfigXmlSchema
        {
            get {
                string map_config_xsd_path = folder_path + "\\map\\map.xsd";
                return map_config_xsd_path;
            }
        }
    }
}
