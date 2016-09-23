namespace LMB.SOLID.ISP.Solution.Contracts
{
    public interface ICustomer
    {
        string ValidateData();
        string SaveData();
        string SendEmail();
    }
}