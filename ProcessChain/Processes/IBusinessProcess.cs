using System;
using EasyNetQ;

namespace FP.MsRmq.ProcessChain.Processes
{
    public interface IBusinessProcess : IDisposable
    {
        void ConnectToBus(IBus bus);
    }
}
