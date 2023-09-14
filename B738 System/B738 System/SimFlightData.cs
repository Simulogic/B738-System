namespace B738_System
{
    public abstract class SimFlightData
    {
        public abstract void RegisterData(object simConnection);
        public abstract bool ProcessData(object data);
        public abstract bool ProcessUserData(object data);
        public abstract bool ProcessSystemState(object data);

        public abstract void Disconnect();
    }
}
