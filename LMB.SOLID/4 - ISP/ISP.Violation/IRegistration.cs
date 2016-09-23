namespace LMB.SOLID.ISP.Violation
{
    public interface IRegistration
    {
        void ValidateData();
        void SaveData();
        void SendEmail();
    }
}