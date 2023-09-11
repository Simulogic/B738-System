using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B738_System
{
    public class RecvSimDataArgs : EventArgs
    {
        public object data;
    }

    public abstract class SimConnection
    {
        public abstract void Connect();
        public abstract void Disconnect();

        public abstract void SetHandle(IntPtr handle);

        public event EventHandler<RecvSimDataArgs> RecvSimData;

        protected virtual void OnRecvSimData(RecvSimDataArgs e)
        {
            RecvSimData?.Invoke(this, e);
        }
    }
}
