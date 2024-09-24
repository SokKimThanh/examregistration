using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;

namespace ExamRegistration.Tools
{
    public class CSession
    {
        public static void SetSession(ISession session, string strKey, object? objValue)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }
            // Chuyển giá trị thành chuỗi JSON
            string strJsonString = JsonConvert.SerializeObject(objValue);

            session.SetString(strKey, strJsonString);
        }

        public static string? GetSession(ISession session, string strKey)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }

            // Lấy chuỗi JSON từ session
            string strJsonString = session.GetString(strKey);

            return strJsonString;
        }

        public static void DeleteSession(ISession session, string strKey)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }
            session.Remove(strKey);
        }
    }
}
