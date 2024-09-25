using ExamRegistration.Models.Common;
using ExamRegistration.Tools;
using ExamRegistrationDA.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ExamRegistration.Controllers
{
    public class ExamRegistrationController<T> : Controller
    {
        private string strEntity_Name = "";

        CCommonFunction objCommon = new();

        public ExamRegistrationController()
        {
            objCommon = new();
            strEntity_Name = typeof(T).Name.Replace("Model", "");
        }

		/// <summary>
		/// Func này luôn định tuyến về thư mục chứa view
		/// </summary>
		/// <returns></returns>
		public IActionResult RouteToPathDefautlView()
        {
            CRespone objRespone = new();
            try
            {
                objRespone = objCommon.CheckLoadView(HttpContext.Session);

                if (objRespone.Value == (int)ERespone_HTTPS_Status.Redirect)
                {
                    return View(objRespone.Route);
                }

                // Kiểm tra view của controller có tồn tại không
                if (CUtility.ViewExists(strEntity_Name) == false)
                    return NotFound($"View {strEntity_Name} not found");

                return View(strEntity_Name + "View");
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                return StatusCode(objRespone.Value, "An error occurred: " + ex.Message);
            }
        }


        /// <summary>
        /// Định tuyến bằng đường dẫn
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public IActionResult RouteToPathAnotherView(string strPath)
        {
            CRespone objRespone = new();
            try
            {
                objRespone = objCommon.CheckLoadView(HttpContext.Session);

                //Nếu là định tuyến view khác thì lấy theo view
                if (objRespone.Value == (int)ERespone_HTTPS_Status.Redirect)               
                    return View(objRespone.Route);
                
                //Check view của controller đó có tồn tại hay không
                if (CUtility.ViewExists(strPath) == false)
                    return NotFound($"View {strPath} not found");

                // Gọi AnotherView.cshtml
                return View(Path.Combine("~/Views,", strPath));
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                return StatusCode(objRespone.Value, "An error occurred: " + ex.Message);
            }
        }
    }
}
