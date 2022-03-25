namespace ChristmasLib.Modules
{
    public class ChristmasModule
    {
        private static string ModuleName = "Base Module";

        public virtual string GetName()
        {
            return ModuleName;
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