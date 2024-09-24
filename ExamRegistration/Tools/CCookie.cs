using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ExamRegistration.Tools
{
    public class CCookie
    {
        private CookieOptions objCookieOptions;

        public CCookie(CookieOptions objCookieOptions)
        {
            this.objCookieOptions = objCookieOptions;
        }

        public void SetCookie(HttpResponse response, string strKey, object objValue, int iExpireDays)
        {
            if (objValue == null)
            {
                throw new ArgumentNullException(nameof(objValue), "The value cannot be null.");
            }

            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }

            // Chuyển giá trị thành chuỗi JSON
            string strJsonString = JsonConvert.SerializeObject(objValue);

            // Thiết lập thời gian hết hạn cho cookie
            objCookieOptions.Expires = DateTimeOffset.UtcNow.AddDays(iExpireDays);

            // Thêm cookie vào response
            response.Cookies.Append(strKey, strJsonString, objCookieOptions);
        }

        public string? GetCookie(HttpRequest request, string strKey)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }
            // Lấy giá trị cookie từ request
            request.Cookies.TryGetValue(strKey, out string? strValue);
            return strValue;
        }

        public void DeleteCookie(HttpResponse response, string strKey)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException(nameof(strKey), "The value cannot be null.");
            }
            // Xóa cookie
            response.Cookies.Delete(strKey);
        }
    }
}
