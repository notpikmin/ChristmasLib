namespace ChristmasLib.Modules
{
    public class ChristmasModule
    {
        public string ModuleName = "Base Module";

        ChristmasModule(string name = "Base Module")
        {
            ModuleName = name;
        }
        
        public virtual void OnEnable()
        {
        }

        public virtual void OnDisable()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnLeaveWorld()
        {
        }

        public virtual void OnJoinWorld()
        {
        }

        public virtual void OnSettingsLoad()
        {
        }

        public virtual void UiInit()
        {
        }
    }
}