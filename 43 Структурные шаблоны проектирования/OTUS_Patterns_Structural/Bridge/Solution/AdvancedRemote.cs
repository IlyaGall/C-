namespace Bridge.Solution
{
    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device)
        {
            
        }
        
        public override void TogglePower()
        {
            if (!_device.IsEnabled())
            {
                _device.Disable();
            }
            else
            {
                _device.Enable();
            }
        }
    }
}