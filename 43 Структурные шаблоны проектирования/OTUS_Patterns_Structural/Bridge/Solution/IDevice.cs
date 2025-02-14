namespace Bridge.Solution
{
    public interface IDevice
    {
        public bool IsEnabled();
        public void Enable();
        
        public void Disable();
    }
}