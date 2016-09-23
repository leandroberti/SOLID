namespace LMB.SOLID.DIP.Solution.Contracts
{
    public interface IEmailServices
    {
        bool IsValid(string email);
        bool Send(string to, string subject, string message);
    }
}