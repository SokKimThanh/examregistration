using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRegistrationDA.Utility
{
    public class CConfig
    {
        public static List<string> ViewBlanks()
        {
            return new List<string>()
            {
                "/Login",
                "/Register",
            }.Select(it => it + "/RouteToPathDefautlView").ToList();
        }

        public static string SessionERUserName = "ERUserName";

    }
}
