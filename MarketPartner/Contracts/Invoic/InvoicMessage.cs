namespace FP.MsRmq.ProcessChain.Contracts.Invoic
{
    public class InvoicMessage : Message
    {
        public override string Type
        {
            get { return "Invoic"; }
        }
    }
}
