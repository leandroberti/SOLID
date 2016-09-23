namespace LMB.SOLID.ISP.Violation
{
    public class ProductRegistration: IRegistration
    {
        public void ValidateData()
        {
            // Validate de Product Quantity and Value
        }

        public void SaveData()
        {
            // Save the Product into Database...
        }

        public void SendEmail()
        {
            // Product do no send emails...
            throw new System.NotImplementedException("Product don't have email address...");
        }
    }
}