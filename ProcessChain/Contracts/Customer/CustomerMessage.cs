namespace FP.MsRmq.ProcessChain.Contracts.Customer
{
    public class CustomerMessage : Message
    {
        public override string Type
        {
            get {return "Customer";}
        }
    }
}
