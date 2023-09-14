using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B738_System
{
    public class RecvSimDataArgs : EventArgs
    {
        public string dataid;
        public object data;
    }

    public abstract class SimConnection
    {
        public abstract void Connect();
        public abstract void Disconnect();

        public abstract void SetHandle(IntPtr handle);

        public event EventHandler<RecvSimDataArgs> RecvSimData;
        public event EventHandler<RecvSimDataArgs> RecvSimUserData;
        public event EventHandler<RecvSimDataArgs> RecvSimSystemData;

        public virtual void OnRecvSimData(RecvSimDataArgs e)
        {
            RecvSimData?.Invoke(this, e);
        }

        public virtual void OnRecvSimUserData(RecvSimDataArgs e)
        {
            RecvSimUserData?.Invoke(this, e);
        }

        public virtual void OnRecvSimSystemData(RecvSimDataArgs e)
        {
            RecvSimSystemData?.Invoke(this, e);
        }

        public abstract bool IsConnected { get; }
        public abstract bool IsConnectorConnected { get; }
    }
}
