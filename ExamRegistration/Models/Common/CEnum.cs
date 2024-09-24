namespace ExamRegistration.Models.Common
{
    public class CEnum
    {
        private int iValue;
        private string strText;

        public CEnum()
        {
            iValue = 0;
            strText = "";
        }

        public int Value { get => iValue; set => iValue = value; }
        public string Text { get => strText; set => strText = value.Trim(); }
    }
}
