using ExamRegistration.Models.Common;
using ExamRegistrationDA.Utility;

namespace ExamRegistration.Tools
{
    public sealed class CCommonFunction
    {
        public CRespone CheckLogin(ISession session)
        {
            CRespone objRespone = new();
            try
            {
                // Kiểm tra giá trị session nếu rỗng thì định tuyến về trang đăng nhập và clear session đi (tránh lỗi vớ vẫn)
                string strERUserName = CSession.GetSession(session, "ERUserName");
                if (strERUserName == "")
                {
                    objRespone.Value = (int)ERespone_HTTPS_Status.Redirect;
                    objRespone.Messages = "Vui lòng đăng nhập lại";
                    objRespone.Route = "~/View/Login/LoginView.cshtml";
                }

                return objRespone;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CRespone CheckLoadView(ISession session)
        {
            CRespone objRespone = new();
            try
            {
                objRespone = CheckLogin(session);

                if (objRespone.Value == (int)ERespone_HTTPS_Status.Failure ||
                    objRespone.Value == (int)ERespone_HTTPS_Status.NotFound ||
                    objRespone.Value == (int)ERespone_HTTPS_Status.Unauthorized ||
                    objRespone.Value == (int)ERespone_HTTPS_Status.Forbidden ||
                    objRespone.Value == (int)ERespone_HTTPS_Status.BadRequest
                    )
                    throw new Exception(objRespone.Messages);

                objRespone.Value = (int) ERespone_HTTPS_Status.Success;
                return objRespone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
