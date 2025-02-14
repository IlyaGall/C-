namespace Bridge.Solution
{
    public class Remote
    {
        protected IDevice _device;

        public Remote(IDevice device)
        {
            _device = device;
        }
        
        public virtual void TogglePower()
        {
            if (_device.IsEnabled())
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