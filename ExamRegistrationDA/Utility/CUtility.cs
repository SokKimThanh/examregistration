using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRegistrationDA.Utility
{
    public class CUtility
    {
        public static bool ViewExists(string strViewName)
        {
            return FileExists("Views", Path.Combine(strViewName, strViewName + "View" + ".cshtml"));
        }

        public static bool FileExists(string strFolderName, string strFileName)
        {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), strFolderName, strFileName));
        }
    }
}
