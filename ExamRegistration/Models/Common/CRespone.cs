namespace ExamRegistration.Models.Common
{
    public class CRespone
    {
        private int iValue;
        private string strText;
        private string strMessages;
        private string strRoute;
        public CRespone()
        {
            iValue = 0;
            strText = "";
            strMessages = "";
            strRoute = "";
        }

        public int Value { get => iValue; set => iValue = value; }
        public string Text { get => strText; set => strText = value.Trim(); }
        public string Messages { get => strText; set => strMessages = value.Trim(); }
        public string Route { get => strText; set => strRoute = value.Trim(); }


    }
}
