namespace B738_System
{
    public interface ISimConnector
    {
        public Dictionary<string, string> SimData { get; }

        public void Connect();
        public void Disconnect();

        public void RegisterData();
    }
}
