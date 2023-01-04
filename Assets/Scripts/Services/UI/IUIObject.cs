using System;

namespace Services.UI
{
    public interface IUIObject
    {
        public event Action<IUIObject> PanelOpen;
        public event Action<IUIObject> PanelClose;

        void Initialize();

        public void Open();

        public void Close();

    }
}