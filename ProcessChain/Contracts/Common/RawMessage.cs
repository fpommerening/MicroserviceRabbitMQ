namespace FP.MsRmq.ProcessChain.Contracts.Common
{
    public class RawMessage : Message
    {
        public override string Type { get { return "String"; } }

        public string Value { get; set; }
    }
}
