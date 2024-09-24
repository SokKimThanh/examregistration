using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRegistrationDA.Utility
{
    public enum ERespone_HTTPS_Status
    {
        None = 0,              // Không có phản hồi
        Success = 200,         // Thao tác thành công
        Failure = 500,         // Lỗi máy chủ nội bộ
        NotFound = 404,        // Tài nguyên không được tìm thấy
        Unauthorized = 401,    // Người dùng không được ủy quyền
        Forbidden = 403,       // Người dùng bị cấm truy cập
        BadRequest = 400,      // Yêu cầu không hợp lệ
        Redirect = 302         // Chuyển hướng đến một địa chỉ khác
    }

}
