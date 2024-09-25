using ExamRegistration.Models.Common;
using ExamRegistrationDA.Utility;

namespace ExamRegistration.Tools
{
	public sealed class CCommonFunction
	{
		public void CheckLogin(ISession session, CRespone objRes)
		{
			try
			{
				// Kiểm tra giá trị session nếu rỗng thì định tuyến về trang đăng nhập và clear session đi (tránh lỗi vớ vẫn)
				string strERUserName = CSession.GetSession(session, CConfig.SessionERUserName);
				if (strERUserName == "")
				{
					objRes.Value = (int)ERespone_HTTPS_Status.Redirect;
					objRes.Messages = "Vui lòng đăng nhập lại";
					objRes.Route = "~/Views/Login/LoginView.cshtml";
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		public CRespone CheckLoadView(ISession session)
		{
			CRespone objRes = new();
			try
			{
				objRes.Value = (int)ERespone_HTTPS_Status.Success;
				objRes.Messages = "Thành công";
				objRes.Route = "";

				CheckLogin(session, objRes);

				if (objRes.Value == (int)ERespone_HTTPS_Status.Failure ||
					objRes.Value == (int)ERespone_HTTPS_Status.NotFound ||
					objRes.Value == (int)ERespone_HTTPS_Status.Unauthorized ||
					objRes.Value == (int)ERespone_HTTPS_Status.Forbidden ||
					objRes.Value == (int)ERespone_HTTPS_Status.BadRequest
					)
					throw new Exception(objRes.Messages);

				return objRes;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
